using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Models
{
    public class Universal_Discount
    {
        public int upc { get; set; }
        public double discount { get; set; }
        public bool applyBeforeTaxes { get; set; }
        public Universal_Discount(int upc,double discount, bool applyBeforeTaxes)
        {
            this.upc = upc;
            this.discount = discount;
            this.applyBeforeTaxes = applyBeforeTaxes;
        }
    }
}
