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
        public ICalculate taxCalculator { get; set; }
        public ICalculate discountCalculator { get; set; }
        public double finalPrice { get; set; }
        public Receipt receipt { get { return GetReceipt(); } set { this.receipt = value; } }


        public PriceCalculator(ICalculate taxCalculator,ICalculate discountCalculator,Product product)
        {
            this.taxCalculator = taxCalculator;
            this.discountCalculator = discountCalculator;
            this.product = product;
            finalPrice = product.price;


        }
        public double CalculateFinalPrice()
        {
            finalPrice += taxCalculator.amount;
            finalPrice-= discountCalculator.amount;
            return Math.Round(finalPrice,2);
        }
        public Receipt GetReceipt()
        {
            Receipt receipt = new Receipt();
            receipt.taxPercentage = taxCalculator.percentage;
            receipt.tax = taxCalculator.amount;
            receipt.discountPercentage = discountCalculator.percentage;
            receipt.discount=discountCalculator.amount;
            receipt.priceAfter = CalculateFinalPrice();
            receipt.product = product;
            finalPrice = product.price;
            return receipt;
        }
    }
}
