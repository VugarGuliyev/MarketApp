using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    // Bu hisse satishlar uzerinde aparilacaq emeliyyatlara uygun metodlari ehtiva edir.

    partial class Process : IMarketable
    {
        public void AddNewSale()
        {
            if (products.Count == 0 || products.TrueForAll(x => x.Count == 0))
            {
                Console.WriteLine("Mehsul siyahisi boshdur. Satish legv olundu");
                return;
            }

            sales.Add(new Sale());
            Console.WriteLine("Emeliyyati dayandirmaq uchun satish tarixine # daxil ede bilersiniz.");
            Console.WriteLine(Environment.NewLine + "Yeni satishin tarixini ve mehsul kodlarini daxil edin.");
            saleID = sales[sales.Count - 1].ID;

            while (true)
            {
                Console.Write("Tarix (format: ay/gun/il): ");
                NewInput(input);

                if (input.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi");
                    sales.Remove(sales[sales.Count - 1]);
                    return;
                }

                try
                {
                    sales.Find(CheckID).Date = DateTime.Parse(input.ToString());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun tarix daxil edin.");
                }
            }

            // Mehsul koduna 0 daxil edildikde satish yekunlashir ve yeni
            // satishin detallari ekrana chixarilir.

            Console.WriteLine(Environment.NewLine + "Movcud mehsullarin siyahisi ashagidadir");
            Console.WriteLine("Satishi yekunlashdirmaq uchun mehsul koduna 0 daxil ede bilersiniz." + Environment.NewLine);
            ShowAllProducts();
            Console.WriteLine(Environment.NewLine);

            while (true)
            {
                Console.Write("Mehsul kodu: ");
                NewInput(oldCodeInput);

                if (oldCodeInput.ToString() == "0")
                {
                    Console.WriteLine(Environment.NewLine + "Yeni satish elave edildi.");
                    Console.WriteLine(sales.Find(CheckID));
                    return;
                }

                if (InputCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun mehsul kodu daxil edin.");
                    continue;
                }

                if (products.Find(FindProduct) == null)
                {
                    Console.WriteLine("Bu koda uygun mehsul tapilmadi. Novbeti mehsul kodunu daxil.");
                    continue;
                }

                if (products.Find(FindProduct).Count == 0)
                {
                    Console.WriteLine("Bu mehsul bitib. Novbeti mehsul kodunu daxil edin.");
                    continue;
                }

                Console.WriteLine(Environment.NewLine + $"Bu mehsulun movcud sayi: {products.Find(FindProduct).Count}");
                Console.WriteLine("Alish miqdarini teyin edin.");

                while (true)
                {
                    Console.Write("Miqdar: ");
                    NewInput(input);

                    if (input.ToString().Contains('.') || !int.TryParse(input.ToString(), out count) || count < 0)
                    {
                        Console.WriteLine("Musbet tam eded daxil edin.");
                        continue;
                    }

                    // Istenilen miqdar movcud mehsul sayindan choxdursa, icaze verilmir.

                    if (products.Find(FindProduct).Count < count)
                    {
                        Console.WriteLine("Istediyiniz miqdar movcud saydan choxdur. Yeni miqdar daxil edin.");
                        continue;
                    }

                    // Her shey qaydasindadirsa, yeni satisha yeni mehsul elave edilir.
                    // Satishin meblegi artirilir. (mehsulun kodu ile miqdarin hasili)
                    // Daha sonra ise mehsul siyahisindaki hemin mehsuldan istenilen miqdar chixilir.

                    sales.Find(CheckID).list.Add(new SaleItem(products.Find(FindProduct), count));
                    sales.Find(CheckID).TotalAmount += sales.Find(CheckID).list.Find(x => x.Product == products.Find(FindProduct)).Product.Price * count;
                    products.Find(FindProduct).Count -= count;
                    Console.WriteLine("Mehsul elave edildi. Novbeti mehsul kodunu daxil edin.");
                    break;
                }
            }
        }

        public void ExactDateSale()
        {
            throw new NotImplementedException();
        }

        public void RemoveIDBasedSale()
        {
            throw new NotImplementedException();
        }

        public void RemoveSale()
        {
            throw new NotImplementedException();
        }

        public void ReturnProduct()
        {
            throw new NotImplementedException();
        }

        public void ShowAllSales()
        {
            throw new NotImplementedException();
        }

        public void ShowAmountBasedSales()
        {
            throw new NotImplementedException();
        }

        public void ShowDateBasedSales()
        {
            throw new NotImplementedException();
        }
    }
}
