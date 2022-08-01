
using PriceCalculatorKata2._0.Models;
using PriceCalculatorKata2._0.Repositories;
using PriceCalculatorKata2._0.Services;

class Program{
    public static void Main()
    {
        ProductRepository productRepository = new ProductRepository();
        Product product = productRepository.productList[0];
        double taxPercentage = 0.2;
        double discountPercentage = 0.15;
        ICalculate taxCalculator = new TaxCalculator(taxPercentage, product.price);
        ICalculate discountCalculator = new TaxCalculator(discountPercentage,  product.price);
        IPriceCalculator priceCalculator = new PriceCalculator(taxCalculator,discountCalculator,product);
        IPrintReceipt receiptPrinter=new ReceiptPrinter();
        receiptPrinter.printReceiptTaxInfo(priceCalculator.receipt);
        Console.WriteLine("*****");
        receiptPrinter.printReceiptTaxAndDiscountInfo(priceCalculator.receipt);
    }
}