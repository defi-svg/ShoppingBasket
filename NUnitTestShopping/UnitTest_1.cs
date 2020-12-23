using NUnit.Framework;
using Shopping.Business;

namespace NUnitTestShopping
{
    public class Tests
    {
        private BasketBLL _basket;
        [SetUp]
        public void Setup()
        {
            _basket = new BasketBLL();
        }

        [TestCase(1)]
        public void ShoppingListScenarioTest_1(int value)
        {
            var result = _basket.ShoppingList(value);

            Assert.IsTrue(result==2.95M);
        }
        [TestCase(2)]
        public void ShoppingListScenarioTest_2(int value)
        {
            var result = _basket.ShoppingList(value);

            Assert.IsTrue(result == 3.10M);
        }
        [TestCase(3)]
        public void ShoppingListScenarioTest_3(int value)
        {
            var result = _basket.ShoppingList(value);

            Assert.IsTrue(result == 3.45M);
        }
        [TestCase(4)]
        public void ShoppingListScenarioTest_4(int value)
        {
            var result = _basket.ShoppingList(value);

            Assert.IsTrue(result == 9.00M);
        }

       
    }
}