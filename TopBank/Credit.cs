using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopBank
{
    class Credit
    {
        private Bank _bank;
        private Customer _customer;
        public string name { get; set; }

        public currency Currency;

        int _Amount;
        public int Amount
        {
            get { return _Amount; }
            set { if (value >= 1 && value <= _bank.Amount)
                    _Amount = value;
                else throw new Exception("Wrong value for Credit");
            }
        }

        int _Percent;
        public int Percent
        {
            get { return _Percent; }
            set { if (value >= 1 && value <= 100)
                    _Percent = value;
                else throw new Exception("Percent has to be 0 - 100"); }
        }

        public Credit(Bank bank, Customer customer)
        {
            _bank = bank;
            _customer = customer;
        }
        
        public DateTimeOffset StartDay { get; set; }

        int _durationMonths;
        public int DurationMonths
        {
            get { return _durationMonths; }
            set {  if (value >= 0 && value <= 36)
                    _durationMonths = value;
                else throw new Exception($"{this.name}'s Duration must be 1 - 36 months");
                 }

        }

        public int Months { get; set; }
        int _reverce;
        public int Reverce
        {
            get { return _reverce; }
            set { _reverce = this.Amount * this.Percent / 100; }
        }
        
    }
}