namespace DevorLimeHeros.Application.Providers.Tests
{
    [TestClass()]
    public class RandomProviderTests
    {
        RandomProvider provider = new RandomProvider();

        [TestMethod()]
        public void GetIntValue_Int_ReturnsTrue()
        {

            var number = provider.GetIntValue(5);

            Assert.IsTrue(number > 0 && number < 5);
        }

        [TestMethod()]
        public void GetDoubleValue_Double_ReturnsTrue()
        {
            var number = provider.GetDoubleValue();

            Assert.IsTrue(number > 0.0 && number < 1.0);
        }
    }
}