using BudgetPlanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestCar
    {
        [TestMethod]
        public void TestCalcCarCost()  // used to test if the calcCarCost method in the Car class works
        {
            double expected = 2125; // if the values below are entered below are entered by the user, the value that should be returned is 2125
            Car c = new Car("Toyota", 50000, 5000, 10, 1000);   
            double actual = c.calcCarCost();  // method called from Car class to retrieve monthly car cost

            // assertion
            Assert.AreEqual(expected, actual);  // checks if expected value and actual value match

        }
    }
}
