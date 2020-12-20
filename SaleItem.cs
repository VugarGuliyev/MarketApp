using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    class SaleItem
    {
        private static int _itemIndex = 0;
        public readonly int ItemIndex;
        public Product Product { get; set; }
        public int Count { get; set; }

        public SaleItem()
        {
            ItemIndex = ++_itemIndex;
        }

        public SaleItem(Product product, int count) : this()
        {
            Product = product;
            Count = count;
        }
    }
}
