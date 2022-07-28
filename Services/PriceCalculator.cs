using PriceCalculatorKata2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Services
{
    public class PriceCalculator : IPriceCalculator
    {
        public Product product { get; set; }
        public ICalculateTax taxCalculator { get; set; }
        public double finalPrice { get; set; }
        public Receipt receipt { get { return GetReceipt(); } set { this.receipt = value; } }


        public PriceCalculator(ICalculateTax taxCalculator,Product product)
        {
            this.taxCalculator = taxCalculator; 
            this.product = product;
            
        }
        private double CalculateFinalPrice()
        {
            finalPrice += taxCalculator.priceAfterTax;
            return finalPrice;
        }
        public Receipt GetReceipt()
        {
            Receipt receipt = new Receipt();
            receipt.taxPercentage = taxCalculator.taxPercentage;
            receipt.tax = taxCalculator.taxAmount;
            receipt.priceAfter = CalculateFinalPrice();
            receipt.product = product;
            return receipt;
        }
    }
}
