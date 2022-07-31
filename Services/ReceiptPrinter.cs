using PriceCalculatorKata2._0.Models;
using PriceCalculatorKata2._0.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Services
{
    public class ReceiptPrinter : IPrintReceipt
    {

        public void printReceiptTaxInfo(Receipt receipt) {

            Console.WriteLine($"Sample product: Book with name = “{receipt.product.Name}”, UPC = {receipt.product.UPC}, price ={receipt.product.currency}{receipt.product.price}." +
                 $"\nProduct price reported as {receipt.product.currency} {receipt.product.price} before tax and {receipt.product.currency} {receipt.priceAfter} after {receipt.taxPercentage *100} % tax.");
        }
        public void printReceiptTaxAndDiscountInfo(Receipt receipt)
        {
            Console.WriteLine($"Sample product: Book with name = “{receipt.product.Name}”, UPC = {receipt.product.UPC}, price = {receipt.product.currency} {receipt.product.price}." +
                $"\nTax = {receipt.taxPercentage*100} %, discount = {receipt.discountPercentage*100} % Tax amount = {receipt.product.currency} {receipt.tax}; Discount amount = {receipt.product.currency} {receipt.universalDiscount}" +
                $"\nPrice before = {receipt.product.currency} {receipt.product.price}, price after = {receipt.product.currency} {receipt.priceAfter}");
        }
        public void printReceiptReport(Receipt receipt)
        {
            string descriptions = "";
            CostRepository costRepository = new CostRepository();
            List<Cost> costs = costRepository.costs.Select(cost => cost).ToList();
            foreach (Cost cost in costs)
            {
                descriptions +="\n"+cost.description + ": "+receipt.product.currency+" "+ cost.cost;
            }
            Console.WriteLine($"Sample product: Title = “{receipt.product.Name}”, UPC={receipt.product.UPC}, price= {receipt.product.currency} {receipt.product.price}." +
                $"\nTax = {receipt.taxPercentage * 100} %, " +
                $"\nUniversal Discount = {receipt.discountPercentage * 100} %" +
                $"" +descriptions+
                $"\nUPC Discount = {receipt.product.currency} {Math.Round(receipt.upcDiscountPercentage*100,2)}"+
                $"\nprice= {receipt.product.currency} {receipt.priceAfter}" +
                $"\nTotal discount= {receipt.product.currency} {receipt.universalDiscount + receipt.upcDiscount}");
        }
    }
}
