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
            Console.WriteLine("Emeliyyati dayandirmaq uchun detallarin her hansi birine # daxil ede bilersiniz.");
            Console.WriteLine(Environment.NewLine + "Yeni mehsulun detallarini qeyd edin.");

            // Ashagidaki while loop-lar mehsul detallarinin daxil edilmesi uchun istifade olunub.
            // Melumatlar duzgun yazilmayanda bildirish edilir ve duzgun daxil edilmesi teleb olunur.
            // Mehsul kodlari unikaldir ve mehsullar kodlar uzerinden axtarilir.

            while (true)
            {
                Console.Write("Kod: ");

                oldCodeInput.Clear();
                oldCodeInput.Append(Console.ReadLine());

                if (oldCodeInput.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
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

                input.Clear();
                input.Append(Console.ReadLine());

                if (input.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
                    return;
                }

                if (InputCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun ad daxil edin.");
                    continue;
                }

                products.Find(FindProduct).Name = input.ToString();
                break;
            }

            while (true)
            {
                Console.Write("Qiymet (AZN): ");

                input.Clear();
                input.Append(Console.ReadLine());

                if (input.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
                    return;
                }

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

                input.Clear();
                input.Append(Console.ReadLine());

                if (input.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
                    return;
                }

                if (CountCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun say daxil edin.");
                    continue;
                }

                products.Find(FindProduct).Count = count;
                Console.WriteLine("Mehsul uchun ashagidaki kateqoriyalardan birini sechin.");

                foreach (var item in Enum.GetValues(typeof(Category)))
                    Console.WriteLine($"{(int)item} - {item}");

                break;
            }

            while (!category)
            {
                Console.Write("Kateqoriya indeksi: ");

                input.Clear();
                input.Append(Console.ReadLine());

                CategoryCheck(input.ToString(), FindProduct);
            }

            Console.WriteLine(Environment.NewLine + "Yeni mehsul elave edildi.");
            Console.WriteLine(products.Find(FindProduct));
            category = false;
        }

        public void ChangeProductDetails()
        {
            Console.WriteLine("Emeliyyati dayandirmaq uchun detallarin her hansi birine # daxil ede bilersiniz.");
            Console.WriteLine(Environment.NewLine + "Duzelish etmek istediyiniz mehsulun kodunu daxil edin.");

            // Mehsulun koduna gore axtarish edilir. Koda uygun mehsul movcud deyilse sistemden chixilir.
            // Koda uygun mehsul movcuddursa deyishiklikler edilir.

            while (true)
            {
                Console.Write("Kod: ");

                oldCodeInput.Clear();
                oldCodeInput.Append(Console.ReadLine());

                if (oldCodeInput.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
                    return;
                }

                if (!products.Exists(FindProduct))
                {
                    Console.WriteLine("Bu koda uygun mehsul tapilmadi. Yeniden cehd edin.");
                    continue;
                }

                break;
            }

            // Kohne kodla tapilan mehsula yeni kod menimsedilir.
            // Mehsul kodu deyishdirildikden sonra yeni detallar yeni kodla tapilan mehsula menimsedilir.

            while (true)
            {
                Console.Write("Mehsulun yeni kodu: ");

                newCodeInput.Clear();
                newCodeInput.Append(Console.ReadLine());

                if (newCodeInput.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
                    return;
                }

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

                input.Clear();
                input.Append(Console.ReadLine());

                if (input.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
                    return;
                }

                if (InputCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun ad daxil edin.");
                    continue;
                }

                products.Find(AmendProduct).Name = input.ToString();
                break;
            }

            while (true)
            {
                Console.Write("Mehsulun yeni qiymeti (AZN): ");

                input.Clear();
                input.Append(Console.ReadLine());

                if (input.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
                    return;
                }

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

                input.Clear();
                input.Append(Console.ReadLine());

                if (input.ToString() == "#")
                {
                    Console.WriteLine(Environment.NewLine + "Emeliyyat dayandirildi.");
                    return;
                }

                if (CountCheck(input.ToString()))
                {
                    Console.WriteLine("Duzgun say daxil edin.");
                    continue;
                }

                products.Find(AmendProduct).Count = count;
                Console.WriteLine("Mehsul uchun yeni kateqoriya sechin.");

                foreach (var item in Enum.GetValues(typeof(Category)))
                    Console.WriteLine($"{(int)item} - {item}");

                break;
            }

            while (!category)
            {
                Console.Write("Kateqoriya indeksi: ");

                input.Clear();
                input.Append(Console.ReadLine());

                CategoryCheck(input.ToString(), AmendProduct);
            }

            Console.WriteLine(Environment.NewLine + "Mehsul detallari deyishdirildi.");
            Console.WriteLine(products.Find(AmendProduct));
            category = false;
        }

        public void RemoveProduct()
        {
            Console.Write("Silmek istediyiniz mehsulun kodunu daxil edin: ");

            if (String.IsNullOrEmpty(oldCodeInput.ToString()))
                oldCodeInput.Append(Console.ReadLine());
            else
                oldCodeInput.Replace(oldCodeInput.ToString(), Console.ReadLine());

            if (!products.Exists(FindProduct))
            {
                Console.WriteLine("Bu koda uygun mehsul tapilmadi.");
                return;
            }

            // Kodlar unikal oldugu uchun ashagidaki metod koda uygun tapilan yegane mehsulu silir.

            products.Remove(products.Find(FindProduct));
            Console.WriteLine("Mehsul silindi.");
        }

        public void ShowAllProducts()
        {
            // Evvela mehsul siyahisinin bosh olub olmadigi yoxlanilir.

            if(products.Count == 0)
            {
                Console.WriteLine("Mehsul siyahisi boshdur.");
                return;
            }

            Console.WriteLine("Mehsul siyahisi");

            foreach (Product item in products)
                Console.WriteLine(item);
        }

        public void ShowCategoryBasedProducts()
        {
            Console.WriteLine("Kateqoriyaya uygun mehsullari gormek uchun indeks daxil edin.");

            foreach (var item in Enum.GetValues(typeof(Category)))
                Console.WriteLine($"{(int)item} - {item}");

            while (!category)
            {
                Console.Write("Kateqoriya indeksi: ");

                if (String.IsNullOrEmpty(input.ToString()))
                    input.Append(Console.ReadLine());
                else
                    input.Replace(input.ToString(), Console.ReadLine());

                switch (input.ToString())
                {
                    case "1":
                        // Ashagidaki yoxlanish muvafiq kateqoriyaya uygun mehsullarin movcud
                        // olub olmamasini yoxlamaq uchundur. Mehsul tapilmasa sistemden chixilir.

                        if (products.Find(product => product.Category == Category.Shirniyyat) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in products.FindAll(product => product.Category == Category.Shirniyyat))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "2":
                        if (products.Find(product => product.Category == Category.Et_Mehsullari) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in products.FindAll(product => product.Category == Category.Et_Mehsullari))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "3":
                        if (products.Find(product => product.Category == Category.Sud_Mehsullari) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in products.FindAll(product => product.Category == Category.Sud_Mehsullari))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "4":
                        if (products.Find(product => product.Category == Category.Meishet_Avadanligi) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in products.FindAll(product => product.Category == Category.Meishet_Avadanligi))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "5":
                        if (products.Find(product => product.Category == Category.Ichki) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in products.FindAll(product => product.Category == Category.Ichki))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "6":
                        if (products.Find(product => product.Category == Category.Meyve_Terevez) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in products.FindAll(product => product.Category == Category.Meyve_Terevez))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun kateqoriya indeksi daxil edin!");
                        break;
                }
            }

            category = false;
        }

        public void ShowNameBasedProducts()
        {
            while (true)
            {
                Console.Write("Minimum qiymet: ");

                if (String.IsNullOrEmpty(minPriceInput.ToString()))
                    minPriceInput.Append(Console.ReadLine());
                else
                    minPriceInput.Replace(minPriceInput.ToString(), Console.ReadLine());

                Console.Write("Maksimum qiymet: ");

                if (String.IsNullOrEmpty(maxPriceInput.ToString()))
                    maxPriceInput.Append(Console.ReadLine());
                else
                    maxPriceInput.Replace(maxPriceInput.ToString(), Console.ReadLine());

                // Ashagidaki yoxlanish daxil edilen reqemler duzgun olub olmadigini,
                // ve minimum qiymetin maksimum qiymetden kichik olub olmadigini yoxlamaq uchundur.

                if (double.TryParse(minPriceInput.ToString(), out minPrice) && minPrice > 0 &&
                    double.TryParse(maxPriceInput.ToString(), out maxPrice) && maxPrice > 0 &&
                    minPrice < maxPrice)
                {
                    // Ashagidaki yoxlanish duzgun qiymetler daxil edildikde hemin araliga
                    // uygun mehsullarin movcud olub olmadigini yoxlamaq uchundur.

                    if (products.Find(product => product.Price >= minPrice && product.Price <= maxPrice) == null)
                    {
                        Console.WriteLine("Bu qiymet araliginda mehsul yoxdur.");
                        return;
                    }

                    foreach (Product item in products.FindAll(product => product.Price >= minPrice && product.Price <= maxPrice))
                        Console.WriteLine(item);

                    return;
                }

                Console.WriteLine("Duzgun qiymet araligi daxil edin!");
            }
        }

        public void ShowPriceBasedProducts()
        {
            Console.Write("Mehsul adini daxil edin: ");

            if (String.IsNullOrEmpty(input.ToString()))
                input.Append(Console.ReadLine());
            else
                input.Replace(input.ToString(), Console.ReadLine());

            if (products.Find(product => product.Name.ToLower() == input.ToString().ToLower()) == null)
            {
                Console.WriteLine("Bu ada uygun mehsul tapilmadi.");
                return;
            }

            Console.WriteLine("Daxil etdiyiniz ada uygun gelen mehsullar ashagidakilardir");

            foreach (Product item in products.FindAll(product => product.Name.ToLower() == input.ToString().ToLower()))
                Console.WriteLine(item);
        }
    }
}