using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Models
{
    
    public class UPC_Discount : Universal_Discount
    {

        public bool IsPercent { get; set; }
        public UPC_Discount(int upc, double discount, bool isPercent, bool applyBeforeTaxes) : base(upc,discount, applyBeforeTaxes)
        {
            this.IsPercent = isPercent;
        }


    }
}
