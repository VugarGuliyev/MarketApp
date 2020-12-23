using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    // Bu hisse mehsullar uzerinde aparilacaq emeliyyatlara uygun metodlari ehtiva edir.

    partial class MethodClass : IMarketable
    {
        public void AddNewProduct()
        {
            products.Add(new Product());
            Console.WriteLine("Yeni mehsulun detallarini daxil edin.");

            // Ashagidaki while loop-lar mehsul detallarinin daxil edilmesi uchun istifade olunub.
            // Melumatlar duzgun yazilmayanda bildirish edilir ve duzgun daxil edilmesi teleb olunur.
            // Mehsul kodlari unikaldir ve mehsullar kodlar uzerinden axtarilir.

            while (true)
            {
                Console.Write("Kod: ");

                if (String.IsNullOrEmpty(oldCodeInput.ToString()))
                    oldCodeInput.Append(Console.ReadLine());
                else
                    oldCodeInput.Replace(oldCodeInput.ToString(), Console.ReadLine());

                if (products.Exists(FindProduct))
                {
                    Console.WriteLine("Bu koda uygun mehsul artiq movcuddur.");
                    return;
                }

                if (!String.IsNullOrEmpty(oldCodeInput.ToString()) &&
                    !String.IsNullOrWhiteSpace(oldCodeInput.ToString()))
                {
                    products[products.Count - 1].Code = oldCodeInput.ToString();
                    break;
                }

                Console.WriteLine("Mehsul kodu bosh buraxila bilmez!");
            }

            while (true)
            {
                Console.Write("Ad: ");

                if (String.IsNullOrEmpty(input.ToString()))
                    input.Append(Console.ReadLine());
                else
                    input.Replace(input.ToString(), Console.ReadLine());

                if (!String.IsNullOrEmpty(input.ToString()) &&
                    !String.IsNullOrWhiteSpace(input.ToString()))
                {
                    products.Find(FindProduct).Name = input.ToString();
                    break;
                }

                Console.WriteLine("Mehsul adi bosh buraxila bilmez!");
            }

            while (true)
            {
                Console.Write("Qiymet (AZN): ");

                if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
                {
                    products.Find(FindProduct).Price = price;
                    break;
                }

                Console.WriteLine("Duzgun qiymet daxil edin!");
            }

            while (true)
            {
                Console.Write("Say: ");

                if (String.IsNullOrEmpty(input.ToString()))
                    input.Append(Console.ReadLine());
                else
                    input.Replace(input.ToString(), Console.ReadLine());

                if (!input.ToString().Contains('.') && int.TryParse(input.ToString(), out count) && count >= 0)
                {
                    products.Find(FindProduct).Count = count;
                    Console.WriteLine("Mehsul uchun ashagidaki kateqoriyalardan birini sechin");

                    foreach (var item in Enum.GetValues(typeof(Category)))
                        Console.WriteLine($"{(int)item} - {item}");

                    break;
                }

                Console.WriteLine("Duzgun say daxil edin!");
            }

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
                        products.Find(FindProduct).Category = Category.Shirniyyat;
                        category = true;
                        break;
                    case "2":
                        products.Find(FindProduct).Category = Category.Et_Mehsullari;
                        category = true;
                        break;
                    case "3":
                        products.Find(FindProduct).Category = Category.Sud_Mehsullari;
                        category = true;
                        break;
                    case "4":
                        products.Find(FindProduct).Category = Category.Meishet_Avadanligi;
                        category = true;
                        break;
                    case "5":
                        products.Find(FindProduct).Category = Category.Ichki;
                        category = true;
                        break;
                    case "6":
                        products.Find(FindProduct).Category = Category.Meyve_Terevez;
                        category = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun kateqoriya indeksi daxil edin!");
                        break;
                }
            }

            Console.WriteLine("Yeni mehsul elave edildi.");
            Console.WriteLine(products.Find(FindProduct));
            category = false;
        }

        public void ChangeProductDetails()
        {
            Console.Write("Duzelish etmek istediyiniz mehsulun kodunu daxil edin: ");

            if (String.IsNullOrEmpty(oldCodeInput.ToString()))
                oldCodeInput.Append(Console.ReadLine());
            else
                oldCodeInput.Replace(oldCodeInput.ToString(), Console.ReadLine());

            // Mehsulun koduna gore axtarish edilir. Koda uygun mehsul movcud deyilse sistemden chixilir.
            // Koda uygun mehsul movcuddursa deyishiklikler edilir.

            if (!products.Exists(FindProduct))
            {
                Console.WriteLine("Bu koda uygun mehsul tapilmadi.");
                return;
            }

            // Kohne kodla tapilan mehsula yeni kod menimsedilir.
            // Mehsul kodu deyishdirildikden sonra yeni detallar yeni kodla tapilan mehsula menimsedilir.

            while (true)
            {
                Console.Write("Mehsulun yeni kodu: ");

                if (String.IsNullOrEmpty(newCodeInput.ToString()))
                    newCodeInput.Append(Console.ReadLine());
                else
                    newCodeInput.Replace(newCodeInput.ToString(), Console.ReadLine());

                if (products.Exists(AmendProduct))
                {
                    Console.WriteLine("Bu koda uygun mehsul artiq movcuddur.");
                    return;
                }

                if (!String.IsNullOrEmpty(newCodeInput.ToString()) &&
                    !String.IsNullOrWhiteSpace(newCodeInput.ToString()))
                {
                    products.Find(FindProduct).Code = newCodeInput.ToString();
                    break;
                }

                Console.WriteLine("Mehsul kodu bosh buraxila bilmez!");
            }

            while (true)
            {
                Console.Write("Mehsulun yeni adi: ");

                if (String.IsNullOrEmpty(input.ToString()))
                    input.Append(Console.ReadLine());
                else
                    input.Replace(input.ToString(), Console.ReadLine());

                if (!String.IsNullOrEmpty(input.ToString()) &&
                    !String.IsNullOrWhiteSpace(input.ToString()))
                {
                    products.Find(AmendProduct).Name = input.ToString();
                    break;
                }

                Console.WriteLine("Mehsul adi bosh buraxila bilmez!");
            }

            while (true)
            {
                Console.Write("Mehsulun yeni qiymeti (AZN): ");

                if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
                {
                    products.Find(AmendProduct).Price = price;
                    break;
                }

                Console.WriteLine("Duzgun qiymet daxil edin!");
            }

            while (true)
            {
                Console.Write("Mehsulun yeni sayi: ");

                if (String.IsNullOrEmpty(input.ToString()))
                    input.Append(Console.ReadLine());
                else
                    input.Replace(input.ToString(), Console.ReadLine());

                if (!input.ToString().Contains('.') && int.TryParse(input.ToString(), out count) && count >= 0)
                {
                    products.Find(AmendProduct).Count = count;
                    Console.WriteLine("Mehsul uchun yeni kateqoriya sechin");

                    foreach (var item in Enum.GetValues(typeof(Category)))
                        Console.WriteLine($"{(int)item} - {item}");

                    break;
                }

                Console.WriteLine("Duzgun say daxil edin!");
            }

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
                        products.Find(AmendProduct).Category = Category.Shirniyyat;
                        category = true;
                        break;
                    case "2":
                        products.Find(AmendProduct).Category = Category.Et_Mehsullari;
                        category = true;
                        break;
                    case "3":
                        products.Find(AmendProduct).Category = Category.Sud_Mehsullari;
                        category = true;
                        break;
                    case "4":
                        products.Find(AmendProduct).Category = Category.Meishet_Avadanligi;
                        category = true;
                        break;
                    case "5":
                        products.Find(AmendProduct).Category = Category.Ichki;
                        category = true;
                        break;
                    case "6":
                        products.Find(AmendProduct).Category = Category.Meyve_Terevez;
                        category = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun kateqoriya indeksi daxil edin!");
                        break;
                }
            }

            Console.WriteLine("Mehsul detallari deyishdirildi.");
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