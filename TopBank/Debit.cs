using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopBank
{
    class Debit
    {
        string name { get; set; }

        public currency Currency;

        int _Amount;
        public int Amount
        {
            get { return _Amount; }
            set
            {
                if (value >= 1)
                    _Amount = value;
                else throw new Exception("Wrong value for Debit");
            }
        }

        int _Percent;
        public int Percent
        {
            get { return _Percent; }
            set
            {
                if (value >= 1 && value <= 100)
                    _Percent = value;
                else throw new Exception("Percent has to be 0 - 100");
            }
        }


        public DateTimeOffset StartDay { get; set; }
        public int DurationMonths { get; set; }
        public int Months { get; set; }
        int _reverce;
        public int Reverce
        {
            get { return _reverce; }
            set { _reverce = this.Amount * this.Percent / 100; }
        }


    }
}
