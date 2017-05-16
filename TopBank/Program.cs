using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            Console.WriteLine($"banks name?");
            bank.Name = Console.ReadLine();

            Console.WriteLine($"{bank.Name}'s Amount? ( 999 - 10000000)");
            try
            {
                bank.Amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }            

            Console.WriteLine($"{bank.Name}'s Minimum credit? (1000 - {bank.Amount/2})");
            try
            {
                bank.MinCredit = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine($"{bank.Name}'s Maximum credit? 1000 - {bank.Amount}");
            try
            {
            bank.MaxCredit = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine($"{bank.Name}'s Minimum debit? (1000 - {bank.Amount / 2})");
            try
            {
             bank.MinDebit = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine($"{bank.Name}'s Maximum debit? 1000 - {bank.Amount})");

            try
            {
            bank.MaxDebit = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Customer customer = new Customer();

            Console.WriteLine("Customer's name?");
            customer.name = Console.ReadLine();


            Console.WriteLine($"{customer.name}'s Salary? (0 - 1000)");
            try
            {
                
                customer.Salary = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine($"{customer.name}'s Wealth?  0 - 1 000 000");
            try
            {

                customer.wealth = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }


            Credit credit = new Credit(bank,customer);

            Console.WriteLine("credit name?");
            credit.name = Console.ReadLine();

            Console.WriteLine($"{credit.name}'s amount? ({bank.MinCredit} - {bank.MaxCredit})");
            try
            {

                credit.Amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine($"{credit.name}'s percent?");
            try
            {

                credit.Percent = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }


            Console.WriteLine($"{credit.name}'s Duration (in months, 1-36)?");
            try
            {

                credit.DurationMonths = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

           
            try { bank.GiveCredit(credit, customer); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            bank.CalculateCreditBalance(credit, customer);

           

            if (bank.CreditCustomerList.Contains(customer)){
                Console.WriteLine($"{bank.Name} gives {credit.Amount} {credit.name} to {customer.name} for {credit.DurationMonths} months");
            }
            


            Console.ReadKey();
           
        }
    }
}
