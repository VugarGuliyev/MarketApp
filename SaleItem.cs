﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    class SaleItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }

        // Satish yaradilanda Sale Class-inin ichindeki SaleItem tipinden olan List-e birbasha bu constructorla yeni
        // SaleItem-lar gonderilir. Istifadechinin daxil etdiyi mehsul kodu ve sayi arqument kimi bu constructorda
        // istifade olunur.
        public SaleItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }
    }
}
