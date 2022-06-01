using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    class Rent : Expense
    {
        public Rent()
        {
            // default constructor
        }

        override public double monthlyRent()
        {
            double rentCost = 0;
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEnter monthly rental amount > R");
                rentCost = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n| Error. Please enter a number (e.g. 3000). |\n");
                monthlyRent();
            }

            return rentCost;
        }  // get monthly rent cost

        override public double homeLoan(double income)
        {
            double monthlyLoanRepayment = 0;
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nEnter the following values for a home loan: ");
                Console.Write("Purchase price of the property > R");
                double price = Convert.ToDouble(Console.ReadLine()); // stores total price of home loan

                Console.Write("Total deposit > R");
                double deposit = Convert.ToDouble(Console.ReadLine());// stores deposit

                Console.Write("Interest rate (percentage) > ");
                double interestRate = Convert.ToDouble(Console.ReadLine());// stores interest rate

                Console.Write("Number of months to repay (between 240 and 360) > ");
                int noOfMonthsRepay = Convert.ToInt32(Console.ReadLine()); // stores number of months to repay loan

                if (noOfMonthsRepay < 240)  // checks if the user entered a value that is in range
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n| Error. Please enter a value between 240 and 360 for the number of months to repay the home loan. |\n");
                    homeLoan(income);
                }
                if (noOfMonthsRepay > 360)  // checks if the user entered a value that is in range
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n| Error. Please enter a value between 240 and 360 for the number of months to repay the home loan. |\n");
                    homeLoan(income);
                }

                // monthly home loan repayment calculation

                /* Formula for monthly home loan repayment:
                 * monthlyLoanRepayment = ( price * interestRate * ( 1 + interestRate ) raised to the exponent noOfMonthsRepay ) divided by ( 1 + interestRate ) raised to the exponent noOfMonthsRepay - 1
                 */

                //calc
                price = price - deposit;  // to get total price of loan after deposit is paid
                interestRate = interestRate / 100;  // converts user's answer to a valid value for interest (percentage)

                //calculation
                monthlyLoanRepayment = price * interestRate / 12 * Math.Pow(1 + interestRate / 12, noOfMonthsRepay) / Math.Pow(1 + interestRate / 12, noOfMonthsRepay) - 1;

                if (monthlyLoanRepayment > (1 / 3 * income))  // notifies user if loan repayment is more than a third of user's income
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n| ALERT: the approval of the home loan is unlikely because it costs more than a third of your monthly income. |");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n| Error. Please enter a number (e.g. 500 000,95) |\n");
                homeLoan(income);
            }

            return monthlyLoanRepayment;
        }  // get monthly home loan cost

    }
}
