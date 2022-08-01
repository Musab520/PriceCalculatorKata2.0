using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Models
{
    
    public class UPC_Discount
    {
        public int upc { get; set; }
        public double discount { get; set; }   
        public bool isPercent { get; set; }
        public UPC_Discount(int upc,double discount,bool isPercent)
        {
            this.upc = upc;
            this.isPercent = isPercent;
            this.discount = discount;
        }
    }
}
