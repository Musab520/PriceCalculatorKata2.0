using PriceCalculatorKata2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Services
{
    public interface IPriceCalculator
    {
        public Product product { get; set; }
        public ICalculateTax taxCalculator { get; set; }
        public double finalPrice { get; set; }
        public Receipt receipt { get; set; }
    }
}
