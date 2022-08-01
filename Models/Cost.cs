using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Models
{
    public class Cost
    {
        public string description { get; set; }
        public  double cost { get; set; }
        public bool IsPercent { get; set; } 
        public Cost(string description,double cost,bool isPercent)
        {
            this.description = description;
            this.cost = cost;
            this.IsPercent = isPercent;
        }
    }
}
