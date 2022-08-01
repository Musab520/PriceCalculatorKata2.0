using PriceCalculatorKata2._0.Models;
using PriceCalculatorKata2._0.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Services
{
    public class UPCDiscountCalculator : ICalculate
    {
        public double percentage { get; set; }
        public double amount { get; set; }
        public double priceAfter { get; set; }
        public bool applyBeforeTaxes { get; set; } = false;
        public UPCDiscountCalculator(DiscountRepository upcRepository, int upc,double price)
        {
           UPC_Discount? upcDiscount = checkForDiscount(upcRepository, upc);
            if (upcDiscount!=null)
            {
                    applyBeforeTaxes = upcDiscount.applyBeforeTaxes;
                    percentage = upcDiscount.IsPercent ? upcDiscount.discount : 0;
                    amount = !upcDiscount.IsPercent ? upcDiscount.discount : calculateAmount(price);
            }
            else
            {
                percentage = 0;
                amount = 0; 
            }
        }
        public double calculateAmount(double price)
        {
            double discount = (percentage) * price;
            return Math.Round(discount, 2);
        }

        public double calculatePriceAfter(double price)
        {
            return Math.Round(price - amount, 2);
        }
        public UPC_Discount? checkForDiscount(DiscountRepository upcRepository,int upc)
        {
            UPC_Discount? upcDiscount = (UPC_Discount?)upcRepository.uPC_Discounts.Where( discount => discount.upc == upc).Select(discount=> discount).SingleOrDefault();
            return upcDiscount;

        }
    }
}
