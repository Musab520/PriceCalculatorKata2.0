using PriceCalculatorKata2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Repositories
{
    public class CostRepository
    {
        public List<Cost> costs = new List<Cost>
        {
            new Cost("Packaging Cost",0.01,true),new Cost("Transport Cost",2.2,false)
        };
    }
}
