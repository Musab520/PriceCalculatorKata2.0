using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Models
{
    public class Cap
    {
        public double cap;
        public bool IsPercent;
        public Cap(double cap,bool IsPercent)
        {
            this.IsPercent = IsPercent;
            this.cap=  cap;

        }
    }
}
