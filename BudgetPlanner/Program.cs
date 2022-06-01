// PROG POE Part 2
// Student number: ST10084621
// Name: Tyreece Ryley Pillay
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    //delegates

    public delegate void welcomeMsgDelegate(int load);
    public delegate void notifyUserDelegate();

    public class Program
    {
        // global var

        private static double income;
        private static double tax;

        private static double rentCost;
        private static double homeloanCost;
        private static double totExpen;
        private static double leftOver;

        private static List<double> expenses = new List<double>();  // expense List<T>

        private static string model;
        private static double price;
        private static double deposit;
        private static double interest;
        private static double insurance;
        private static double montlyCarCost;

        static void Main(string[] args)
        {
            // lambda delegate
            welcomeMsgDelegate wmd = (load) =>
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Loading . . . ");
                //loop
                for (int i = load; i > 0; i--)     //decrementing for loop
                {
                    Console.Write(i + "\t");    //type Write only to make it verticle output
                                                //pause
                    Thread.Sleep(1000);        //max 5000 miliseconds   //using System.Threading is the import

                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\n \t\t Welcome to the Budget Planner app! "
                    + "\n====================================================================");
                //pause
                Thread.Sleep(1000);
            };
            wmd.Invoke(3); // call delegate

            // user enters income and tax
            getIncomeAndTax();

            // user enters expenses
            getExpenses();

            // give user option between rent and home loan
            rentOrBuyProperty();

            // calculate total expenses
            calcTotalExpenses();

            // notify user if user total expenses exceed 75%
            notifyUserDelegate nud = new notifyUserDelegate(notifyUser);  // pass method to delegate
            nud.Invoke();  // call delegate

            // give user option to choose car
            buyCarOrNot();

            // calculate income minus expenses
            calcLeftOverMoney();

            // display expenses in descending 
            displayDesc();

            Console.ReadLine();  // keep console open
        }

        //methods

        public static void getIncomeAndTax()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n* * * Income * * *");
                Console.WriteLine("\nHelp us understand your budget by entering the following values: ");
                Console.Write("Enter your gross monthly income > R");
                income = Convert.ToDouble(Console.ReadLine());  // store user's income

                Console.Write("Enter your estimated monthly tax deduction > R");
                tax = Convert.ToDouble(Console.ReadLine());  // store user's monthly tax reduction
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n| Error. Please enter a number (e.g. 3 000,50) |\n");
                getIncomeAndTax();
            }
        }

        public static void getExpenses()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n====================================================================");
                Console.WriteLine("\n* * * Expenses * * *");
                Console.WriteLine("\nEnter your monthly expenditures in each of the following categories: ");
                Console.Write("Groceries > R");
                expenses.Add(Convert.ToDouble(Console.ReadLine()));  // adds user's grocery cost to expenses list

                Console.Write("Water and Electricity > R");
                expenses.Add(Convert.ToDouble(Console.ReadLine()));  // adds user's water and electricity cost to expenses list

                Console.Write("Travel costs (including petrol) > R");
                expenses.Add(Convert.ToDouble(Console.ReadLine()));  // adds user's travel cost to expenses list

                Console.Write("Cellphone and telephone > R");
                expenses.Add(Convert.ToDouble(Console.ReadLine()));  // adds user's phone cost to expenses list

                Console.Write("Other expenses > R");
                expenses.Add(Convert.ToDouble(Console.ReadLine()));  // adds user's other costs to expenses list
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n| Error. Please enter a number (e.g. 1 000,99) |\n");
                getExpenses();
            }
            
        }

        public static void rentOrBuyProperty()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n====================================================================");
                Console.WriteLine("\n* * * Accomodation * * * ");

                Console.WriteLine("\nPlease select one of the following options for accomodation: (type the number only) ");
                Thread.Sleep(1000);
                Console.WriteLine("1 - Rent a property \n2 - Purchase a property");
                Console.Write("Select option number > ");
                int ans = Convert.ToInt32(Console.ReadLine());  // stores user's option
                Rent r = new Rent();

                switch (ans)
                {
                    case 1: rentCost = r.monthlyRent(); break;  // calls method to get monthly rental amount
                    case 2: homeloanCost = r.homeLoan(income); break; // calls method to get home loan info
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n| Error: Please enter 1 or 2 |\n");
                rentOrBuyProperty();
            }
        }

        public static void calcTotalExpenses()
        {
            foreach (int i in expenses)  // add up all expenses
            {
                totExpen += i;  // adds each value in the expenses list and stores it in totExpen
            }

            totExpen += homeloanCost;  // add home loan to total expenses
        }

        public static void notifyUser()
        {
            if (totExpen > (income*3/4) )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n====================================================================");
                Console.WriteLine("\n\tNOTE: Your total expenses exceed 75% of your income.");  // notify user if their total expenses exceed 75% of their income
            }
        }

        public static void buyCarOrNot()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n====================================================================");
                Console.WriteLine("\n* * * Car * * * ");

                Console.WriteLine("\nSelect whether you would like to buy a car or not: (type the number only) ");
                Thread.Sleep(1000);
                Console.WriteLine("1 - Buy a car \n2 - Continue program");
                Console.Write("Select option number > ");
                int ans = Convert.ToInt32(Console.ReadLine());  // stores user's option

                switch (ans)
                {
                    case 1: buyCar(); break;  // calls method calculate car cost
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n| Error. Please enter 1 or 2 |\n");
                buyCarOrNot();
            }    
        }

        public static void buyCar()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nEnter the following values to buy a car: ");
                Console.Write("Model and Make of the car > ");
                model = Console.ReadLine(); // stores model and make of car

                Console.Write("Purchase price of the car > R");
                price = Convert.ToDouble(Console.ReadLine());  // stores the purchase price of the car

                Console.Write("Deposit > R");
                deposit = Convert.ToDouble(Console.ReadLine());  // stores the deposit

                Console.Write("Interest rate (percentage) > ");
                interest = Convert.ToDouble(Console.ReadLine());  // stores interest rate

                Console.Write("Estimated insurance premium > ");
                insurance = Convert.ToInt32(Console.ReadLine());  // stores insurance premium

                Car c = new Car(model, price, deposit, interest, insurance);  // passes values to Car class
                montlyCarCost = c.calcCarCost();  // stores calculated monthly car cost using method from Car class
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n| Error. Please enter a number (e.g. 1 000,99) |\n");
                buyCar();
            }
            
        }

        public static void calcLeftOverMoney()
        {
            leftOver = income - ( tax + totExpen + rentCost + montlyCarCost);  // income minus total expenses
        }

        public static void displayDesc()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            expenses.Sort();
            expenses.Reverse();

            Console.WriteLine("\n====================================================================");
            Console.WriteLine("\nList of expenses:");
            Console.WriteLine();
            int num = 1;
            foreach (int i in expenses)  // display expenses in descending
            {
                Console.WriteLine(num + ": R" + i);
                num++;
            }

            if (rentCost > 0)
            {
                Console.WriteLine("\nMonthly rent cost:\tR" + rentCost);
            }

            if (homeloanCost > 0)
            {
                Console.WriteLine("\nMonthly home loan cost:\tR" + homeloanCost);
            }

            if (montlyCarCost > 0)
            {
                Console.WriteLine("\nMonthly car cost:\tR" + montlyCarCost);
            }

            Console.WriteLine("\n====================================================================");
            Console.WriteLine("\nMoney left over after deductions:\tR" + leftOver);
            Console.WriteLine("\n====================================================================");
            Console.WriteLine("\n* * * End of program * * *");
            Console.WriteLine("\n--------------------------------------------------------------------");
        }

    }
}
