using PriceCalculatorKata2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Repositories
{
    public class UPCDiscountRepository
    {
        public List<UPC_Discount> uPC_Discounts = new List<UPC_Discount>
        {
            new UPC_Discount(12345,0.07,true),new UPC_Discount(12346,4,false)
        };
    }
}
