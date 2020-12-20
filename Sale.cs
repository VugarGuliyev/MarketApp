using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    class Sale
    {
        private static int _id = 0;
        public readonly int ID;
        public readonly DateTime Time;
        public double TotalAmount;

        List<SaleItem> saleItems = new List<SaleItem>();

        public Sale()
        {
            ID = ++_id;
            Time = DateTime.Now;
            TotalAmount = 0;
        }
    }
}
