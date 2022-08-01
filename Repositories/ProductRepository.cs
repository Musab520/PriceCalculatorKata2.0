using PriceCalculatorKata2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Repositories
{
    public class ProductRepository
    {
       public List<Product> productList = new List<Product>
        {
           new Product("Game1",12345,20.25),new Product("Game2",12346,18),new Product("Game3",12347,10)
        };
    }
}
