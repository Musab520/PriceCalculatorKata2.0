﻿using PriceCalculatorKata2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Services
{
    public class ReceiptPrinter : IPrintReceipt
    {
        public Receipt receipt { get ; set ; }

        public void printReceiptTaxInfo(Receipt receipt) {

            Console.WriteLine($"Sample product: Book with name = “{receipt.product.Name}”, UPC = {receipt.product.UPC}, price ={receipt.product.price}." +
                 $"\nProduct price reported as ${receipt.product.price} before tax and ${receipt.priceAfter} after {receipt.taxPercentage *100} % tax.");
        }
        public void printReceiptTaxAndDiscountInfo(Receipt receipt)
        {

            Console.WriteLine($"Sample product: Book with name = “{receipt.product.Name}”, UPC = {receipt.product.UPC}, price ={receipt.product.price}." +
                $"\nTax = {receipt.taxPercentage*100} %, discount = {receipt.discountPercentage*100} % Tax amount = ${receipt.tax}; Discount amount = ${receipt.discount}" +
                $"\nPrice before = ${receipt.product.price}, price after = ${receipt.priceAfter}");
        }
        public void printReceiptReport(Receipt receipt)
        {
            Console.WriteLine($"Sample product: Title = “{receipt.product.Name}”, UPC={receipt.product.UPC}, price=${receipt.product.price}." +
                $"Tax = {receipt.taxPercentage * 100} %, " +
                $"discount = {receipt.discountPercentage * 100} %" +
                $"price= ${receipt.priceAfter}" +
                $"Total discount= ${receipt.discount}");
        }
    }
}
