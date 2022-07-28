using PriceCalculatorKata2._0.Models;
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
    }
}
