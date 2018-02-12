using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03GreedyTimes
{
    class Cash
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public Cash(string name, int amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
    }
}
