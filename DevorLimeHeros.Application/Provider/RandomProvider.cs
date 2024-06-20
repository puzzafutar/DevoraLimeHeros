using DevoraLimeHeros.Application.Provider.Interface;

namespace DevorLimeHeros.Application.Providers
{
    public class RandomProvider : IRandomProvider
    {
        private readonly Random _random;

        public RandomProvider()
        {
            _random = new Random();
        }

        public int GetIntValue(int maxValue)
        {
            return _random.Next(0, maxValue);
        }

        public double GetDoubleValue()
        {
            return _random.NextDouble();
        }
    }
}
