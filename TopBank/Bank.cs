using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopBank
{
    class Bank
    {
        

    public string Name { get; set; }

        public currency Currency;

        int _Amount;
        public int Amount
        {
            get { return _Amount; }
            set
            {
                if (value <= 10000000 && value >= 1000)
                    _Amount = value;
                else throw new Exception($"Amount has to be 999 - 10000000 {this.Currency}");
            }
        }

        int _MinCredit;
        public int MinCredit
        {
            get { return _MinCredit; }
            set { if (value >= 1000 && value <= this.Amount/2) _MinCredit = value;
                else throw new Exception($"Minimal cradit has to be 1000 - {this.Amount/2}");
            }
        }
        int _MaxCredit;
        public int MaxCredit
        {
            get { return _MaxCredit; }
            set { if (value >= 1000 && value <= this.Amount && value > this.MinCredit)
                    _MaxCredit = value;
                else throw new Exception($"Maximal credit has tu be 1000 - {this.Amount}");
                        }
        }

        int _MinDebit;
        public int MinDebit
        {
            get { return _MinDebit; }
            set
            {
                if (value >= 1000 && value <= this.Amount / 2) _MinDebit = value;
                else throw new Exception($"Minimal cradit has to be 1000 - {this.Amount / 2}");
            }
        }
        int _MaxDebit;
        public int MaxDebit
        {
            get { return _MaxDebit; }
            set
            {
                if (value >= 1000 && value <= this.Amount && value > this.MinDebit)
                    _MaxCredit = value;
                else throw new Exception($"Maximal credit has tu be 1000 - {this.Amount}");
            }
        }

        public List<Customer> WhiteList = new List<Customer>();
        public List<Customer> ValidationList = new List<Customer>();
        public List<Customer> BlackList = new List<Customer>();
        public List<Customer> CreditCustomerList = new List<Customer>();
        public List<Customer> DebitCustomerList = new List<Customer>();
       
        public Credit GiveCredit (Credit credit, Customer customer)
        {   if (credit.Amount <= this.MaxCredit && credit.Amount >= this.MinCredit)
            {
                if (!this.BlackList.Contains(customer) || customer.wealth >= 1000 || customer.Salary >= 500)
                {

                    this.Amount -= credit.Amount;
                    customer.wealth += credit.Amount;
                    this.CreditCustomerList.Add(customer);
                    credit.StartDay = DateTimeOffset.Now;
                }
                else
                {
                    this.ValidationList.Add(customer);
                    throw new Exception("We will answer you soon");
                }
            }
            else throw new Exception($"Your credit has to be {this.MinCredit} - {this.MaxCredit}");
            
            return credit;
        }
     //   public List<Customer> Validation(Customer customer)
       // {
         //   if (this.ValidationList.Contains(customer) && !this.BlackList.Contains(customer) && customer.Salary >= 1000)
           //     this.WhiteList.Add(customer);
           // else
            //{
           //     this.BlackList.Add(customer);
             //   throw new Exception($"{customer.name} is in Black List of {this.Name}");
           // }
            //return this.WhiteList;
        //}

        public int CalculateCreditBalance(Credit credit, Customer customer)
        {
            credit.Months = Convert.ToInt32(DateTimeOffset.Now.Month - credit.StartDay.Month);
            int EveryTimePay = credit.Reverce / credit.DurationMonths;
            for (int i = 0; i < credit.DurationMonths; i++)
            {
                this.Amount += EveryTimePay;
                customer.wealth -= EveryTimePay;
            }
            return credit.Months;
        }

        public Debit GiveDebit (Debit debit, Customer customer)
        {
            if (debit.Amount <= this.MaxDebit && debit.Amount >= this.MinDebit)
            {
                if (this.WhiteList.Contains(customer))
                {

                    this.Amount += debit.Amount;
                    customer.wealth -= debit.Amount;
                    this.DebitCustomerList.Add(customer);
                }
                else
                {
                    this.ValidationList.Add(customer);
                    throw new Exception("We will answer you soon");
                }
            }
            else throw new Exception($"Your debit has to be {this.MinDebit} - {this.MaxDebit}");

            return debit ;
        }
        public List<Customer> ValidationDebit(Customer customer)
        {
            if (this.ValidationList.Contains(customer) && !this.BlackList.Contains(customer) && customer.Salary >= 1000)
                this.WhiteList.Add(customer);
            else
            {
                this.BlackList.Add(customer);
                throw new Exception($"{customer.name} is in Black List of {this.Name}");
            }
            return this.WhiteList;
        }

        public int CalculateDebittBalance(Debit debit, Customer customer)
        {
            debit.Months = Convert.ToInt32(DateTimeOffset.Now.Month - debit.StartDay.Month);
            int EveryTimePay = debit.Reverce / debit.DurationMonths;
            for (int i = 0; i < debit.DurationMonths; i++)
            {
                this.Amount -= EveryTimePay;
            }
            return debit.Months;
        }
        public int paying (Debit debit, Customer customer)
        {
            customer.wealth += debit.Reverce;
            this.Amount -= debit.Reverce;
            return this.Amount;           
        }


    }
}
