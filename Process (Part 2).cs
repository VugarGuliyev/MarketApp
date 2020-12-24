using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    // Bu hisse mehsullar uzerinde aparilacaq emeliyyatlara uygun metodlari ehtiva edir.

    partial class Process : IMarketable
    {
        public void AddNewProduct()
        {
            products.Add(new Product());
            Console.WriteLine("Emeliyyati dayandirmaq uchun mehsul koduna # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Yeni mehsulun detallarini daxil edin.");

            // Ashagidaki while loop-lar mehsul detallarinin daxil edilmesi uchun istifade olunub.
            // Melumatlar duzgun yazilmayanda bildirish edilir ve duzgun daxil edilmesi teleb olunur.
            // Mehsul kodlari unikaldir ve mehsullar kodlar uzerinden axtarilir.

            while (true)
            {
                Console.Write("Kod: ");
                NewInput(oldCodeInput);

                if (oldCodeInput.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi.");
                    Console.Write(Environment.NewLine);
                    products.Remove(products[products.Count - 1]);
                    return;
                }

                if (oldCodeInput.ToString() == "0")
                {
                    Console.WriteLine("Mehsul kodu 0 ola bilmez. Yeniden cehd edin.");
                    continue;
                }

                if (products.Exists(FindProduct))
                {
                    Console.WriteLine("Bu kod artiq istifade olunub. Bashqa kod daxil edin.");
                    continue;
                }

                if (InputCheck(oldCodeInput.ToString()))
                {
                    Console.WriteLine("Mehsul kodu bosh buraxila bilmez. Yeniden cehd edin.");
                    continue;
                }

                products[products.Count - 1].Code = oldCodeInput.ToString();
                break;
            }

            while (true)
            {
                Console.Write("Ad: ");
                NewInput(input);

                if (InputCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun ad daxil edin.");
                    continue;
                }

                if (input.ToString() == "#")
                {
                    Console.WriteLine("Mehsul adi # ile bashlaya bilmez. Bashqa ad daxil edin.");
                    continue;
                }

                products.Find(FindProduct).Name = input.ToString();
                break;
            }

            while (true)
            {
                Console.Write("Qiymet (AZN): ");
                NewInput(input);

                if (PriceCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun qiymet daxil edin.");
                    continue;
                }

                products.Find(FindProduct).Price = price;
                break;
            }

            while (true)
            {
                Console.Write("Say: ");
                NewInput(input);

                if (CountCheck(input.ToString(), count))
                {
                    Console.WriteLine("Duzgun say daxil edin.");
                    continue;
                }

                products.Find(FindProduct).Count = count;
                Console.Write(Environment.NewLine);
                Console.WriteLine("Mehsul uchun ashagidaki kateqoriyalardan birini sechin.");
                ShowCategoryList();
                break;
            }

            while (!category)
            {
                Console.Write(Environment.NewLine);
                Console.Write("Kateqoriya indeksi: ");
                NewInput(input);
                CategoryCheck(input.ToString(), FindProduct);
            }

            Console.Clear();
            Console.WriteLine("Yeni mehsul elave edildi.");
            Console.WriteLine(products.Find(FindProduct));
            Console.Write(Environment.NewLine);
            category = false;
        }

        public void ChangeProductDetails()
        {
            // Evvela mehsul siyahisinin bosh olub olmadigi yoxlanilir.

            if (products.Count == 0)
            {
                Console.WriteLine("Mehsul siyahisi boshdur.");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun mehsul koduna # daxil ede bilersiniz.");
            Console.WriteLine("Duzelish etmek istediyiniz mehsulun kodunu daxil edin.");

            // Mehsulun koduna gore axtarish edilir. Koda uygun mehsul movcud deyilse
            // sistemden chixilir. Koda uygun mehsul movcuddursa deyishiklikler edilir.

            while (true)
            {
                Console.Write("Kod: ");
                NewInput(oldCodeInput);

                if (oldCodeInput.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi.");
                    Console.Write(Environment.NewLine);
                    return;
                }

                if (!products.Exists(FindProduct))
                {
                    Console.WriteLine("Bu koda uygun mehsul tapilmadi. Yeniden cehd edin.");
                    continue;
                }

                break;
            }

            // Kohne kodla tapilan mehsula yeni kod menimsedilir. Mehsul kodu
            // deyishdirildikden sonra yeni detallar yeni kodla tapilan mehsula menimsedilir.

            while (true)
            {
                Console.Write("Mehsulun yeni kodu: ");
                NewInput(newCodeInput);

                if (newCodeInput.ToString() == "0")
                {
                    Console.WriteLine("Mehsul kodu 0 ola bilmez. Yeniden cehd edin.");
                    continue;
                }

                if (products.Exists(AmendProduct))
                {
                    Console.WriteLine("Bu koda uygun mehsul artiq movcuddur. Yeniden cehd edin.");
                    continue;
                }

                if (InputCheck(newCodeInput.ToString()))
                {
                    Console.WriteLine("Mehsul kodu bosh buraxila bilmez. Yeniden cehd edin.");
                    continue;
                }

                products.Find(FindProduct).Code = newCodeInput.ToString();
                break;
            }

            while (true)
            {
                Console.Write("Mehsulun yeni adi: ");
                NewInput(input);

                if (InputCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun ad daxil edin.");
                    continue;
                }

                if (input.ToString() == "#")
                {
                    Console.WriteLine("Mehsul adi # ile bashlaya bilmez. Bashqa ad daxil edin.");
                    continue;
                }

                products.Find(AmendProduct).Name = input.ToString();
                break;
            }

            while (true)
            {
                Console.Write("Mehsulun yeni qiymeti (AZN): ");
                NewInput(input);

                if (PriceCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun qiymet daxil edin.");
                    continue;
                }

                products.Find(AmendProduct).Price = price;
                break;
            }

            while (true)
            {
                Console.Write("Mehsulun yeni sayi: ");
                NewInput(input);

                if (CountCheck(input.ToString(), count))
                {
                    Console.WriteLine("Duzgun say daxil edin.");
                    continue;
                }

                products.Find(AmendProduct).Count = count;
                Console.Write(Environment.NewLine);
                Console.WriteLine("Mehsul uchun yeni kateqoriya sechin.");
                ShowCategoryList();
                break;
            }

            while (!category)
            {
                Console.Write(Environment.NewLine);
                Console.Write("Kateqoriya indeksi: ");
                NewInput(input);
                CategoryCheck(input.ToString(), AmendProduct);
            }

            Console.Clear();
            Console.WriteLine("Mehsul detallari deyishdirildi.");
            Console.WriteLine(products.Find(AmendProduct));
            Console.Write(Environment.NewLine);
            category = false;
        }

        public void RemoveProduct()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Mehsul siyahisi boshdur.");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun birbasha # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Silmek istediyiniz mehsulun kodunu daxil edin.");
            
            while (true)
            {
                Console.Write("Kod: ");
                NewInput(oldCodeInput);

                if (oldCodeInput.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi.");
                    Console.Write(Environment.NewLine);
                    return;
                }

                if (!products.Exists(FindProduct))
                {
                    Console.WriteLine("Bu koda uygun mehsul tapilmadi. Bashqa kod daxil edin.");
                    continue;
                }

                // Kodlar unikal oldugu uchun ashagidaki metod koda uygun tapilan yegane mehsulu silir.

                products.Remove(products.Find(FindProduct));
                Console.Clear();
                Console.WriteLine("Mehsul silindi.");
                Console.Write(Environment.NewLine);
                return;
            }
        }

        public void ShowAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Mehsul siyahisi boshdur.");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Umumi mehsul siyahisi:");
            ShowProductList();
            Console.Write(Environment.NewLine);
        }

        public void ShowCategoryBasedProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Mehsul siyahisi boshdur.");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Kateqoriya indeksini daxil edin.");
            Console.Write(Environment.NewLine);
            ShowCategoryList();
            Console.Write(Environment.NewLine);

            while (true)
            {
                Console.Write("Kateqoriya indeksi: ");
                NewInput(input);

                switch (input.ToString())
                {
                    case "#":
                        Console.Clear();
                        Console.WriteLine("Emeliyyat dayandirildi.");
                        Console.Write(Environment.NewLine);
                        return;
                    case "1":
                        // Ashagidaki yoxlanish muvafiq kateqoriyaya uygun mehsullarin movcud
                        // olub olmamasini yoxlamaq uchundur. Mehsul tapilmasa bildirish edilir.

                        if (products.Find(x => x.Category == Category.Shirniyyat) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi. Bashqa indeks daxil edin.");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("Shirniyyat kateqoriyasi:");

                        foreach (Product item in products.FindAll(x => x.Category == Category.Shirniyyat))
                            Console.WriteLine(item);

                        Console.Write(Environment.NewLine);
                        return;
                    case "2":
                        if (products.Find(x => x.Category == Category.Et_Mehsullari) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi. Bashqa indeks daxil edin.");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("Et_Mehsullari kateqoriyasi:");

                        foreach (Product item in products.FindAll(x => x.Category == Category.Et_Mehsullari))
                            Console.WriteLine(item);

                        Console.Write(Environment.NewLine);
                        return;
                    case "3":
                        if (products.Find(x => x.Category == Category.Sud_Mehsullari) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi. Bashqa indeks daxil edin.");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("Sud_Mehsullari kateqoriyasi:");

                        foreach (Product item in products.FindAll(x => x.Category == Category.Sud_Mehsullari))
                            Console.WriteLine(item);

                        Console.Write(Environment.NewLine);
                        return;
                    case "4":
                        if (products.Find(x => x.Category == Category.Meishet_Avadanligi) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi. Bashqa indeks daxil edin.");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("Meishet_Avadanligi kateqoriyasi:");

                        foreach (Product item in products.FindAll(x => x.Category == Category.Meishet_Avadanligi))
                            Console.WriteLine(item);

                        Console.Write(Environment.NewLine);
                        return;
                    case "5":
                        if (products.Find(x => x.Category == Category.Ichki) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi. Bashqa indeks daxil edin.");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("Ichki kateqoriyasi:");

                        foreach (Product item in products.FindAll(x => x.Category == Category.Ichki))
                            Console.WriteLine(item);

                        Console.Write(Environment.NewLine);
                        return;
                    case "6":
                        if (products.Find(x => x.Category == Category.Meyve_Terevez) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi. Bashqa indeks daxil edin.");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("Meyve_Terevez kateqoriyasi:");

                        foreach (Product item in products.FindAll(x => x.Category == Category.Meyve_Terevez))
                            Console.WriteLine(item);

                        Console.Write(Environment.NewLine);
                        return;
                    default:
                        Console.WriteLine("Duzgun kateqoriya indeksi daxil edin.");
                        break;
                }
            }
        }

        public void ShowPriceBasedProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Mehsul siyahisi boshdur.");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Qiymet araligini daxil edin.");

            while (true)
            {
                Console.Write("Minimum qiymet: ");
                NewInput(minPriceInput);

                if (minPriceInput.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi.");
                    Console.Write(Environment.NewLine);
                    return;
                }

                Console.Write("Maksimum qiymet: ");
                NewInput(maxPriceInput);

                if (maxPriceInput.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi.");
                    Console.Write(Environment.NewLine);
                    return;
                }

                // Ashagidaki yoxlanish duzgun qiymetler daxil edilib edilmediyini yoxlamaq uchundur.

                if (PriceCompare())
                {
                    Console.WriteLine("Duzgun qiymet araligi daxil edin.");
                    continue;
                }

                // Duzgun qiymet daxil edilibse ve o araliga uygun mehsul movcud deyilse bildirish edilir.

                if (products.Find(x => x.Price >= minPrice && x.Price <= maxPrice) == null)
                {
                    Console.WriteLine("Bu qiymet araliginda mehsul yoxdur. Yeniden cehd edin.");
                    continue;
                }

                Console.Clear();
                Console.WriteLine("Daxil etdiyiniz qiymet araligina uygun mehsullar:");

                foreach (Product item in products.FindAll(x => x.Price >= minPrice && x.Price <= maxPrice))
                    Console.WriteLine(item);

                Console.Write(Environment.NewLine);
                return;
            }       
        }

        public void ShowNameBasedProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Mehsul siyahisi boshdur.");
                Console.Write(Environment.NewLine);
                return;
            }

            Console.WriteLine("Emeliyyati dayandirmaq uchun # daxil ede bilersiniz.");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Mehsulun adini daxil edin.");

            while (true)
            {
                Console.Write("Ad: ");
                NewInput(input);

                if (input.ToString() == "#")
                {
                    Console.Clear();
                    Console.WriteLine("Emeliyyat dayandirildi.");
                    Console.Write(Environment.NewLine);
                    return;
                }

                if (InputCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun ad daxil edin.");
                    continue;
                }

                if (products.Find(x => x.Name.ToLower() == input.ToString().ToLower()) == null)
                {
                    Console.WriteLine("Bu ada uygun mehsul tapilmadi. Yeniden cehd edin.");
                    continue;
                }

                Console.Clear();
                Console.WriteLine("Daxil etdiyiniz ada uygun gelen mehsullar ashagidakilardir:");

                foreach (Product item in products.FindAll(x => x.Name.ToLower() == input.ToString().ToLower()))
                    Console.WriteLine(item);

                Console.Write(Environment.NewLine);
                return;
            }
        }
    }
}