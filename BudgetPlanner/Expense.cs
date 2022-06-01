using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    abstract class Expense
    {
        private List<double> expenses = new List<double>();  // List<T> collection instead of array

        public void setExpenses (List<double> userExpen)
        {
            expenses = userExpen;
        }

        public abstract double monthlyRent();  // abstract method

        public abstract double homeLoan(double income);  // abstract method

    }
}
