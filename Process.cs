using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    // Butun proses bu classdan instance alinaraq class-daki metodlarla idare olunub.
    // Satishlar uchun yaradilan siyahi ve butun mehsullarin siyahisi da bu class-in ichindedir.
    // Yeni satishlar ve mehsullar hemin siyahilara elave olunur.
    // Class partial olaraq 3 hisseye bolunub. Bu hisse satish ve mehsul siyahilari,
    // metodlarda istifade etmek uchun yaradilan deyishenler ve Predictable type-a uygun metodlari ehtiva edir.

    partial class Process : IMarketable
    {
        // Satish ve mehsul siyahilari

        List<Sale> sales = new List<Sale>();
        List<Product> products = new List<Product>();

        // Ashagidaki StringBuilder-lar ve diger deyishenler user-in mehsul
        // detallari uchun daxil edeceyi input-lari yoxlayib duzgun formada
        // menimsetmek uchun istifade olunub. Yalniz bu class-daki metodlarda
        // istifade edildikleri uchun xususi access modifier qeyd olunmayib.

        StringBuilder input = new StringBuilder();
        StringBuilder oldCodeInput = new StringBuilder();
        StringBuilder newCodeInput = new StringBuilder();
        StringBuilder minPriceInput = new StringBuilder();
        StringBuilder maxPriceInput = new StringBuilder();

        double price;
        int count;
        bool category = false;

        double minPrice;
        double maxPrice;

        // Ashagidaki metodlar mehsul ve satish axtarish metodlarinda Predictable type
        // callback metodlar kimi istifade olunub.

        public bool FindProduct(Product product)
        {
            return product.Code == oldCodeInput.ToString();
        }

        public bool AmendProduct(Product product)
        {
            return product.Code == newCodeInput.ToString();
        }

        // Ashagidaki metodlar benzer if statement ve switch case-lerde istifade etmek uchun yaradilib.

        public bool InputCheck(string item)
        {
            return String.IsNullOrEmpty(item) || String.IsNullOrWhiteSpace(item);
        }

        public bool PriceCheck(string item)
        {
            return !double.TryParse(item, out price) || price <= 0;
        }

        public bool CountCheck(string item)
        {
            return item.Contains('.') || !int.TryParse(item, out count) || count <= 0;
        }

        public void CategoryCheck(string item, Predicate<Product> method)
        {
            switch (item)
            {
                case "1":
                    products.Find(method).Category = Category.Shirniyyat;
                    category = true;
                    break;
                case "2":
                    products.Find(method).Category = Category.Et_Mehsullari;
                    category = true;
                    break;
                case "3":
                    products.Find(method).Category = Category.Sud_Mehsullari;
                    category = true;
                    break;
                case "4":
                    products.Find(method).Category = Category.Meishet_Avadanligi;
                    category = true;
                    break;
                case "5":
                    products.Find(method).Category = Category.Ichki;
                    category = true;
                    break;
                case "6":
                    products.Find(method).Category = Category.Meyve_Terevez;
                    category = true;
                    break;
                default:
                    Console.WriteLine("Duzgun kateqoriya indeksi daxil edin.");
                    break;
            }
        }
    }
}
