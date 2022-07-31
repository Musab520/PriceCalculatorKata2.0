using PriceCalculatorKata2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Repositories
{
    public class DiscountRepository
    {
        public List<Universal_Discount> uPC_Discounts = new List<Universal_Discount>
        {
            new UPC_Discount(12345,0.07,true,true),new UPC_Discount(12346,4,false,true)
        };
    }
}