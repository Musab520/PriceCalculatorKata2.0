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
        public Cap cap;
        public PriceCalculator(ICalculate taxCalculator,ICalculate universalDiscountCalculator, ICalculate upcDiscountCalculator,Product product,Cap cap)
        {
            this.taxCalculator = taxCalculator;
            this.universalDiscountCalculator = universalDiscountCalculator;
            this.upcDiscountCalculator = upcDiscountCalculator;
            this.product = product;
            this.cap = cap;
            finalPrice = product.price;
        }
        public double CalculateFinalPrice()
        {
            double capDiscount= cap.IsPercent ? cap.cap*product.price : cap.cap;
            double totalDiscounts = 0;
            if (upcDiscountCalculator.applyBeforeTaxes)
            {
                finalPrice -= capDiscount > upcDiscountCalculator.amount ? upcDiscountCalculator.amount : 0;
                totalDiscounts += upcDiscountCalculator.amount;
                double tmpPrice=finalPrice;
                finalPrice -= capDiscount > upcDiscountCalculator.amount ? universalDiscountCalculator.calculateAmount(tmpPrice) : 0;
                totalDiscounts += universalDiscountCalculator.calculateAmount(tmpPrice);
                finalPrice = capDiscount>totalDiscounts ? finalPrice : tmpPrice-capDiscount;

                finalPrice += taxCalculator.calculateAmount(tmpPrice);
            }
            else
            {
                finalPrice -= capDiscount > upcDiscountCalculator.amount ? upcDiscountCalculator.amount : 0;
                finalPrice -= capDiscount > upcDiscountCalculator.amount ? universalDiscountCalculator.amount : 0;
                totalDiscounts += universalDiscountCalculator.amount + upcDiscountCalculator.amount;
                finalPrice = capDiscount > totalDiscounts ? finalPrice : product.price-capDiscount;
                finalPrice += taxCalculator.amount;
            }
            CostRepository costRepository = new CostRepository();
            List<Cost> costs=costRepository.costs.Select(cost => cost).ToList();
            foreach (Cost cost in costs)
            {
                finalPrice += cost.IsPercent? cost.cost*product.price : cost.cost;
            }
            return Math.Round(finalPrice,4);
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
