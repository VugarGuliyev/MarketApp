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
            if (products.Count == 0 || !products.Exists(x => x.Count != 0))
            {
                Console.WriteLine("Mehsul siyahisi boshdur.");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun satish tarixine # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Yeni satishin tarixini ve mehsul kodlarini daxil edin.");

            while (true)
            {
                Console.Write("Tarix (format: ay/gun/il): ");
                NewInput(input);

                if (input.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi");
                    Console.Write(Environment.NewLine);
                    return;
                }

                try
                {
                    sales.Add(new Sale(DateTime.Parse(input.ToString())));
                    saleID = sales[sales.Count - 1].ID;
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun tarix daxil edin.");
                }
            }

            // Mehsul koduna 0 daxil edildikde satish yekunlashir ve yeni
            // satishin detallari ekrana chixarilir.

            Console.Write(Environment.NewLine);
            Console.WriteLine("Movcud mehsullarin siyahisi ashagidadir");
            Console.WriteLine("Satishi yekunlashdirmaq uchun mehsul koduna 0 daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            ShowAllProducts();

            while (true)
            {
                Console.Write("Mehsul kodu: ");
                NewInput(oldCodeInput);

                if (oldCodeInput.ToString() == "0")
                {
                    if (sales.Find(CheckID).TotalAmount == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Satishin meblegi 0 oldugu uchun yaradilmadi.");
                        Console.Write(Environment.NewLine);
                        sales.Remove(sales.Find(CheckID));
                        return;
                    }

                    Console.Clear();
                    Console.WriteLine("Yeni satish elave edildi.");
                    Console.WriteLine(sales.Find(CheckID));
                    Console.Write(Environment.NewLine);
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

                if (sales.Find(CheckID).list.Find(x => x.Product == products.Find(FindProduct)) != null)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Bu mehsuldan artiq elave etmisiniz. Mehsul miqdarini berpa etmek uchun + daxil edin");
                    Console.WriteLine("Novbeti mehsula kechmek uchun her hansi bir herf, reqem, yaxud simvol daxil edin.");
                    Console.Write("Sechim: ");
                    NewInput(input);

                    if (input.ToString() != "+")
                        continue;
                    else
                        sales.Find(CheckID).list.Remove(sales.Find(CheckID).list.Find(x => x.Product == products.Find(FindProduct)));
                }

                Console.Write(Environment.NewLine);
                Console.WriteLine($"Bu mehsulun movcud sayi: {products.Find(FindProduct).Count}");

                while (true)
                {
                    Console.Write("Miqdari daxil edin: ");
                    NewInput(input);

                    // Her mehsuldan minimum 1 eded elave edilmelidir.

                    if (CountCheck(input.ToString()))
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
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Mehsul elave edildi. Novbeti mehsul kodunu daxil edin.");
                    break;
                }
            }
        }

        public void ReturnProduct()
        {
            if (sales.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun mehsul nomresine # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            ShowAllSales();
            Console.WriteLine("Qaytarmaq istediyiniz mehsulun yer aldigi satishin nomresini daxil edin.");

            while (true)
            {
                Console.Write("Satish nomresi: ");
                NewInput(input);

                if (input.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi.");
                    Console.Write(Environment.NewLine);
                    return;
                }

                if (input.ToString().Contains('.') || !int.TryParse(input.ToString(), out saleID) || saleID <= 0)
                {
                    Console.WriteLine("Nomre musbet tam eded olmalidir.");
                    continue;
                }

                if (sales.Find(CheckID) == null)
                {
                    Console.WriteLine("Satish tapilmadi. Yeni satish nomresi daxil edin.");
                    continue;
                }

                break;
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine("Satishin cari veziyyeti:");

            Console.WriteLine(sales.Find(CheckID));

            Console.WriteLine("Terkibindeki mehsul siyahisi:");
            foreach (SaleItem item in sales.Find(CheckID).list)
                Console.WriteLine(item);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Qaytarmaq istediyiniz mehsul kodunu daxil edin.");

            while (true)
            {
                Console.Write("Kod: ");
                NewInput(oldCodeInput);

                if (sales.Find(CheckID).list.Find(x => x.Product == products.Find(FindProduct)) == null)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Satishda bu koda uygun mehsul yoxdur. Bashqa kod daxil edin.");
                    continue;
                }

                break;
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine("Qaytarmaq istediyiniz miqdari daxil edin.");

            while (true)
            {
                Console.Write("Miqdar: ");
                NewInput(input);

                if (CountCheck(input.ToString()))
                {
                    Console.WriteLine("Musbet tam eded daxil edin.");
                    continue;
                }

                if (sales.Find(CheckID).list.Find(x => x.Product == products.Find(FindProduct)).Count < count)
                {
                    Console.WriteLine("Satishda bu qeder mehsul movcud deyil. Bashqa miqdar daxil edin.");
                    continue;
                }

                break;
            }

            // Qaytarilan miqdar satish item-inin sayindan chixilir ve mehsul siyahisina elave edilir.

            sales.Find(CheckID).list.Find(x => x.Product == products.Find(FindProduct)).Count -= count;
            sales.Find(CheckID).TotalAmount -= sales.Find(CheckID).list.Find(x => x.Product == products.Find(FindProduct)).Product.Price * count;
            products.Find(FindProduct).Count += count;

            // Mehsul qaytarildiqdan sonra satish item-inin sayi 0-a dushurse hemin item avtomatik silinir.

            sales.Find(CheckID).list.Remove(sales.Find(CheckID).list.Find(x => x.Count == 0));

            Console.Clear();
            Console.WriteLine("Mehsul qaytarildi.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Satishin yeni detallari:");
            Console.WriteLine(sales.Find(CheckID));
            Console.Write(Environment.NewLine);
        }

        public void RemoveSale()
        {
            if (sales.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun satish nomresine # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Silmek istediyiniz satishin nomresini daxil edin.");

            while (true)
            {
                Console.Write("Nomre: ");
                NewInput(input);

                if (input.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi");
                    Console.Write(Environment.NewLine);
                    return;
                }

                if (input.ToString().Contains('.') || !int.TryParse(input.ToString(), out saleID) || saleID <= 0)
                {
                    Console.WriteLine("Musbet tam eded daxil edin.");
                    continue;
                }

                if (sales.Find(CheckID) == null)
                {
                    Console.WriteLine("Nomreye uygun satish tapilmadi. Yeni satish nomresi daxil edin.");
                    continue;
                }

                sales.Remove(sales.Find(CheckID));
                Console.Clear();
                Console.WriteLine("Satish silindi");
                Console.Write(Environment.NewLine);
                return;
            }
        }

        public void ShowAllSales()
        {
            if (sales.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Umumi satish siyahisi:");

            foreach (Sale item in sales)
                Console.WriteLine(item);

            Console.Write(Environment.NewLine);
        }

        public void ShowDateBasedSales()
        {
            if (sales.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Tarix araligi daxil edin. (format: ay/gun/il)");

            while (true)
            {
                try
                {
                    Console.Write("Bashlangic: ");
                    date1 = DateTime.Parse(Console.ReadLine());
                    Console.Write("Son: ");
                    date2 = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun tarixler daxil edin.");
                }
            }

            Console.Clear();

            if (sales.Find(x => x.Date >= date1 && x.Date <= date2) == null)
            {
                Console.WriteLine("Bu tarix araligina uygun satish movcud deyil");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Daxil etdiyiniz tarixlere uygun gelen satishlar bunlardir:");

            foreach (Sale item in sales.FindAll(x => x.Date >= date1 && x.Date <= date2))
                Console.WriteLine(item);

            Console.Write(Environment.NewLine);
        }

        public void ShowAmountBasedSales()
        {
            if (sales.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun mebleglere # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Mebleg araligi daxil edin.");

            while (true)
            {
                Console.Write("Minimum: ");
                NewInput(minPriceInput);

                if (minPriceInput.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi");
                    Console.Write(Environment.NewLine);
                    return;
                }

                Console.Write("Maximum: ");
                NewInput(maxPriceInput);

                if (maxPriceInput.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi");
                    Console.Write(Environment.NewLine);
                    return;
                }

                if (PriceCompare())
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Duzgun qiymet araligi daxil edin.");
                    continue;
                }

                break;
            }

            Console.Clear();

            if (sales.Find(x => x.TotalAmount >= minPrice && x.TotalAmount <= maxPrice) == null)
            {
                Console.WriteLine("Bu qiymet araligina uygun satish movcud deyil");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Daxil etdiyiniz qiymet araligina uygun gelen satishlar ashagidakilardir:");

            foreach (Sale item in sales.FindAll(x => x.TotalAmount >= minPrice && x.TotalAmount <= maxPrice))
                Console.WriteLine(item);

            Console.Write(Environment.NewLine);
        }

        public void ExactDateSale()
        {
            if (sales.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.Write("Tarix daxil edin. (format: ay/gun/il): ");

            while (true)
            {
                try
                {
                    date1 = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun tarix daxil edin.");
                }
            }

            Console.Clear();

            if (sales.Find(x => x.Date == date1) == null)
            {
                Console.WriteLine("Bu tarixe uygun satish movcud deyil");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Daxil etdiyiniz tarixe uygun gelen satish(lar) ashagidakilardir:");

            foreach (Sale item in sales.FindAll(x => x.Date == date1))
                Console.WriteLine(item);

            Console.Write(Environment.NewLine);
        }

        public void ShowIDBasedSale()
        {
            if (sales.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun mehsul nomresine # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Detallarini gormek istediyiniz satishin nomresini daxil edin.");

            while (true)
            {
                Console.Write("Nomre: ");
                NewInput(input);

                if (input.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi.");
                    Console.Write(Environment.NewLine);
                    return;
                }

                if (input.ToString().Contains('.') || !int.TryParse(input.ToString(), out saleID) || saleID <= 0)
                {
                    Console.WriteLine("Nomre musbet tam eded olmalidir.");
                    continue;
                }

                if (sales.Find(CheckID) == null)
                {
                    Console.WriteLine("Satish tapilmadi. Yeni satish nomresi daxil edin.");
                    continue;
                }

                break;
            }

            Console.Clear();

            Console.WriteLine("Daxil etdiyiniz nomreye uygun gelen satishin detallari bunlardir:");
            Console.Write(Environment.NewLine);
            Console.WriteLine(sales.Find(CheckID));
            Console.WriteLine("Terkibindeki mehsullarin siyahisi:");
            foreach (SaleItem item in sales.Find(CheckID).list)
                Console.WriteLine(item);

            Console.Write(Environment.NewLine);
        }
    }
}
