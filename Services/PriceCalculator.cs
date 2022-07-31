using PriceCalculatorKata2._0.Models;
using PriceCalculatorKata2._0.Repositories;
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
        public ICalculate universalDiscountCalculator { get; set; }
        public ICalculate upcDiscountCalculator { get; set; }
        public bool applyDiscountsBefore { get; set; } = false;
        public double finalPrice { get; set; }

        public PriceCalculator(ICalculate taxCalculator,ICalculate universalDiscountCalculator, ICalculate upcDiscountCalculator,Product product)
        {
            this.taxCalculator = taxCalculator;
            this.universalDiscountCalculator = universalDiscountCalculator;
            this.upcDiscountCalculator = upcDiscountCalculator;
            this.product = product;
            finalPrice = product.price;
        }
        public double CalculateFinalPrice()
        {
            if (upcDiscountCalculator.applyBeforeTaxes)
            {
                finalPrice -= upcDiscountCalculator.amount;
                double tmpPrice=finalPrice;
                finalPrice -= universalDiscountCalculator.calculateAmount(tmpPrice);
                finalPrice += taxCalculator.calculateAmount(tmpPrice);
            }
            else
            {
                finalPrice -= upcDiscountCalculator.amount;
                finalPrice -= universalDiscountCalculator.amount;
                finalPrice += taxCalculator.amount;
            }
            CostRepository costRepository = new CostRepository();
            List<Cost> costs=costRepository.costs.Select(cost => cost).ToList();
            foreach (Cost cost in costs)
            {
                finalPrice += cost.IsPercent? cost.cost*product.price : cost.cost;
            }
            return Math.Round(finalPrice,2);
        }
        public Receipt GetReceipt()
        {
            Receipt receipt = new Receipt();
            receipt.taxPercentage = taxCalculator.percentage;
            receipt.tax = taxCalculator.amount;
            receipt.discountPercentage = universalDiscountCalculator.percentage;
            receipt.universalDiscount= universalDiscountCalculator.amount;
            receipt.upcDiscountPercentage = upcDiscountCalculator.percentage;
            receipt.upcDiscount = upcDiscountCalculator.amount;
            receipt.priceAfter = CalculateFinalPrice();
            receipt.product = product;
            finalPrice = product.price;
            return receipt;
        }
    }
}
