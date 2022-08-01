using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PriceCalculatorKata2._0.Services
{
    public class TaxCalculator : ICalculate
    {
        public double percentage { get; set; } = 0;
        public double amount { get; set; } = 0;
        public double priceAfter { get; set; } = 0;
        public bool applyBeforeTaxes { get; set; }
        public TaxCalculator(double percentage,double price)
        {
            this.percentage = percentage;
            amount = calculateAmount(price);
        }
        public double calculateAmount(double price)
        {
            double tax = (percentage) * price;
            return Math.Round(tax,2);
        }

        public double calculatePriceAfter(double price)
        {
            return Math.Round(price + amount,2);
        }
    }
}
