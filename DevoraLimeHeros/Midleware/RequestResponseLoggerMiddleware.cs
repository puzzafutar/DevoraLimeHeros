using DevoraLimeHeros.Controllers;
using System.Diagnostics;

namespace DevorLimeHeros.Middleware
{
        /// <summary>
        /// Kilogolja a kérést és a választ
        /// </summary>
        public class RequestResponseLoggerMiddleware
        {
            private readonly ILogger<HerosController> _logger;
            private readonly RequestDelegate _next;

            private const string RequestLogTemplate =
                "{middleware}: {traceId} | METHOD {httpmethod} | PATH {path} | QUERY {querystring} | SCHEME {scheme}";

            private const string ResponseLogTemplate =
                "{middleware}: {traceId} | METHOD {httpmethod} | PATH {path} | QUERY {querystring} | SCHEME {scheme} | STATUS {status} | {elapsedtime}";

            public RequestResponseLoggerMiddleware(RequestDelegate next, ILogger<HerosController> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                var timer = new Stopwatch();

                try
                {
                    timer!.Start();

                    var requestLog = CreateRequestLog(context);
                    _logger.LogInformation(requestLog);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(RequestResponseLoggerMiddleware)}: A logolás hibára futott");
                }

                await _next(context);

                try
                {
                    timer!.Stop();

                    _logger.LogInformation(CreateResponseLog(context, timer!.ElapsedMilliseconds));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(RequestResponseLoggerMiddleware)}: A logolás hibára futott");
                }
                finally
                {
                    timer = null;
                }
            }

            private static string CreateRequestLog(HttpContext context)
            {
                var mw = nameof(RequestResponseLoggerMiddleware);
                var traceId = context.TraceIdentifier;
                var method = context.Request.Method;
                var path = context.Request.Path;
                var queryString = context.Request.QueryString;
                var scheme = context.Request.Scheme;

            return RequestLogTemplate
                .Replace("{traceId}", traceId)
                .Replace("{middleware}", mw)
                .Replace("{httpmethod}", method)
                .Replace("{path}", path)
                .Replace("{querystring}", queryString.ToString())
                .Replace("{scheme}", scheme);
            }

            private static string CreateResponseLog(HttpContext context, long elapsedTime)
            {
                var mw = nameof(RequestResponseLoggerMiddleware);
                var traceId = context.TraceIdentifier;
                var method = context.Request.Method;
                var path = context.Request.Path;
                var queryString = context.Request.QueryString;
                var scheme = context.Request.Scheme;
                var status = context.Response.StatusCode;

                return ResponseLogTemplate
                    .Replace("{middleware}", mw)
                    .Replace("{traceId}", traceId)
                    .Replace("{httpmethod}", method)
                    .Replace("{path}", path)
                    .Replace("{querystring}", queryString.ToString())
                    .Replace("{scheme}", scheme)
                    .Replace("{status}", status.ToString())
                    .Replace("{elapsedtime}", $"finished in {elapsedTime} ms");
            }
        }
    }

