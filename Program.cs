
using PriceCalculatorKata2._0.Models;
using PriceCalculatorKata2._0.Repositories;
using PriceCalculatorKata2._0.Services;

class Program{
    public static void Main()
    {
        ProductRepository productRepository = new ProductRepository();
        Product product = productRepository.productList[0];
        ICalculateTax taxCalculator = new TaxCalculator(0.2,product.price);
        IPriceCalculator priceCalculator = new PriceCalculator(taxCalculator,product);
        IPrintReceipt receiptPrinter=new ReceiptPrinter();
        receiptPrinter.printReceiptTaxInfo(priceCalculator.receipt);
    }
}