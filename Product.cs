using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    public enum Category { Shirniyyat, Et_Mehsullari, Sud_Mehsullari, Un_Memulatlari, Meishet_Avadanligi, Ichki, Meyve_Terevez }
    
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int Code { get; }
        public Category Category { get; set; }

        public Product(string name, double price, int count, int code, Category category)
        {
            Name = name;
            Price = price;
            Count = count;
            Code = code;
            Category = category;
        }
    }
}
