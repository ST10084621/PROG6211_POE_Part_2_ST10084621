using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    public class Car
    {
        // Car attributes
        private string model;
        private double price;
        private double deposit;
        private double interest;
        private double insurance;

        // constructor
        public Car(string model, double price, double deposit, double interest, double insurance)
        {
            this.model = model;
            this.price = price;
            this.deposit = deposit;
            this.interest = interest;
            this.insurance = insurance;
        }

        public double calcCarCost()
        {
            double monthlyCost = 0;
            double cost = 0;

            price = price - deposit;  // amount after deposit has been paid
            interest = interest / 100;  // interest in correct form

            cost = price * ( 1 + (interest * 5) );  // formula to calculate monthly cost of car
            monthlyCost = cost / 60;  // gets monthly cost -- 5 years = 60 months
            monthlyCost += insurance;  // subtract insurance premium from monthly cost

            return monthlyCost;
        }  // calculate monthly car cost
    }
}
