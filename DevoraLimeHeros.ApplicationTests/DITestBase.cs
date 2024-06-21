using DevoraLimeHeros.Application.Factory.Interface;
using DevoraLimeHeros.Application.Factory;
using DevoraLimeHeros.Application.Manager;
using DevoraLimeHeros.Application.Manager.Interface;
using DevoraLimeHeros.Application.Provider.Interface;
using DevoraLimeHeros.Application.Service;
using DevoraLimeHeros.Application.Service.Interface;
using DevorLimeHeros.Application.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace DevoraLimeHeros.ApplicationTests
{
    public class DITestBase
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public DITestBase()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register application services
            services.AddSingleton<IArenaManager, ArenaManager>();
            services.AddSingleton<IHeroFactory, HeroFactory>();
            services.AddSingleton<IArenaService, ArenaService>();
            services.AddSingleton<IHeroService, HeroService>();
            services.AddSingleton<IRandomProvider, RandomProvider>();
        }
    }
}
