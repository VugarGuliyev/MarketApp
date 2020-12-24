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
        public DateTime Date { get; set; }
        public double TotalAmount { get; set; }
        public int TotalProduct { get; set; }

        public List<SaleItem> list = new List<SaleItem>();

        public Sale()
        {
            ID = ++_id;
            TotalAmount = 0;
        }

        public override string ToString()
        {
            return $"Nomre: {ID} | Tarix: {Date.ToString("MM/dd/yyyy")} | Cheshid sayi: {list.Count} | Toplam mehsul sayi: {SumProducts()} | Mebleg: {TotalAmount}";
        }
        
        // SumProducts metodu umumi mehsul siyahisini ekrana yazdirmaq uchun yaradilib.

        public int SumProducts()
        {
            for (int i = 0; i < list.Count; i++)
                TotalProduct += list[i].Count;

            return TotalProduct;
        }
    }
}
