
using PriceCalculatorKata2._0.Models;
using PriceCalculatorKata2._0.Repositories;
using PriceCalculatorKata2._0.Services;

class Program{
    public static void Main()
    {
        ProductRepository productRepository = new ProductRepository();
        DiscountRepository uPCDiscountRepository = new DiscountRepository();

        Product product = productRepository.productList[0];
        double taxPercentage = 0.21;
        double discountPercentage = 0.15;
        ICalculate taxCalculator = new TaxCalculator(taxPercentage, product.price);
        ICalculate discountCalculator = new UniversalDiscountCalculator(discountPercentage,  product.price);
        ICalculate upcDiscountCalculator = new UPCDiscountCalculator(uPCDiscountRepository,product.UPC,product.price);
        Cap cap = new Cap(0.2, true);
        IPriceCalculator priceCalculator = new PriceCalculator(taxCalculator,discountCalculator,upcDiscountCalculator,product,cap);
        IPrintReceipt receiptPrinter=new ReceiptPrinter();
        receiptPrinter.printReceiptTaxInfo(priceCalculator.GetReceipt());
        Console.WriteLine("*****");
        receiptPrinter.printReceiptTaxAndDiscountInfo(priceCalculator.GetReceipt());
        Console.WriteLine("*****");
        receiptPrinter.printReceiptReport(priceCalculator.GetReceipt());
    }
}