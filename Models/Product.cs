﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Models
{
    public class Product
{

    public string Name { get; set; }
    public int UPC { get; set; }
    public double price { get; set; }
    public string currency { get; set; }
    public Product(string name, int upc, double price,string currency)
    {
        Name = name;
        UPC = upc;
        this.price = price;
        this.currency = currency;
    }
    public override string ToString()
    {
        return "Name:" + Name + ", UPC:" + UPC + ",price:" + price;
    }
}
}


