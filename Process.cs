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
    }
}
