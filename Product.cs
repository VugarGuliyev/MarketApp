﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    public enum Category { Shirniyyat = 1, Et_Mehsullari, Sud_Mehsullari, Meishet_Avadanligi, Ichki, Meyve_Terevez }
    
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Code { get; set; }
        public Category Category { get; set; }

        public Product()
        {
        }

        public override string ToString()
        {
            return $"Ad: {Name} | Qiymet: {Price} | Say: {Count} | Kod: {Code} | Kateqoriya: {Category}";
        }
    }
}
