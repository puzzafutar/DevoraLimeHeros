using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevorLimeHeros.Application.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void GetDoubleValueTest()
        {
            var number = provider.GetDoubleValue();

            Assert.IsTrue(number > 0.0 && number < 1.0);
        }
    }
}