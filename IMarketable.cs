using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    interface IMarketable
    {
        void AddNewProduct();
        void ChangeProductDetails();
        void RemoveProduct();
        void ShowAllProducts();
        void ShowCategoryBasedProducts();
        void ShowPriceBasedProducts();
        void ShowNameBasedProducts();

        void AddNewSale();
        void ReturnProduct();
        void RemoveSale();
        void ShowAllSales();
        void ShowDateBasedSales();
        void ShowAmountBasedSales();
        void ExactDateSale();
        void ShowIDBasedSale();
    }
}
