using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculatorKata2._0.Models;
namespace PriceCalculatorKata2._0.Services
{
    public interface IPrintReceipt
    {
        public void printReceiptTaxInfo(Receipt receipt);
        public void printReceiptTaxAndDiscountInfo(Receipt receipt);
        void printReceiptReport(Receipt receipt);
    }
}
