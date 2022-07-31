﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Services
{
    public class UniversalDiscountCalculator : ICalculate
    {
        public double percentage { get; set ; }
        public double amount { get ; set ; }
        public double priceAfter { get ; set ; }
        public bool applyBeforeTaxes { get ; set; }

        public UniversalDiscountCalculator(double percentage, double price)
        {
            this.percentage = percentage;
            amount = calculateAmount(price);

        }
        public double calculateAmount(double price)
        {
            double discount = (percentage) * price;
            return Math.Round(discount, 4);
        }

        public double calculatePriceAfter(double price)
        {
            return Math.Round(price - amount, 4);
        }
    }
}
