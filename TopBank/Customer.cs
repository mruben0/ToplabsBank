using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopBank
{
    class Customer
    {
        public string name { get; set; }
        int _salary;
        public int Salary
        {
            get { return _salary; }
            set { if (value <= 1000 && value >= 0)
                    _salary = value;
                else throw new Exception("your salary doesn't approved");
            }
        
        }
        int _wealth;
        public int wealth
        {
            get { return _wealth; }
            set { if (value >= 0 && value <= 1000000)
                    _wealth = value;
                else throw new Exception($"Wrong wealth,  {this.name}'s wealth has to be number 0 - 1000000");
            }
        }
        
    }
}
