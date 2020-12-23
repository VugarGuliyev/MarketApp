using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    partial class MethodClass : IMarketable
    {
        public void AddNewProduct()
        {
            products.Add(new Product());
            Console.WriteLine("Yeni mehsulun detallarini daxil edin.");

            // Ashagidaki while loop-lar mehsul detallarinin girishi uchun istifade olunub.
            // Melumatlar duzgun yazilmayanda bildirish edilir ve yeniden daxil edilmesi teleb olunur.

            while (true)
            {
                Console.Write("Kod: ");
                strCode.Replace(strCode.ToString(), Console.ReadLine());

                if (products.Exists(FindProduct))
                {
                    Console.WriteLine("Bu koda uygun mehsul artiq movcuddur.");
                    return;
                }

                if (strCode.ToString() != String.Empty)
                {
                    products[products.Count - 1].Code = strCode.ToString();
                    break;
                }

                Console.WriteLine("Duzgun kod daxil edin.");
            }

            while (true)
            {
                Console.Write("Ad: ");
                strInput.Replace(strInput.ToString(), Console.ReadLine());

                if (strInput.ToString() != String.Empty)
                {
                    products.Find(FindProduct).Name = strInput.ToString();
                    break;
                }

                Console.WriteLine("Duzgun ad daxil edin!");
            }

            while (true)
            {
                Console.Write("Qiymet (AZN): ");

                if (double.TryParse(Console.ReadLine(), out myDouble) && myDouble > 0)
                {
                    products.Find(FindProduct).Price = myDouble;
                    break;
                }

                Console.WriteLine("Duzgun qiymet daxil edin!");
            }

            while (true)
            {
                Console.Write("Say: ");

                if (int.TryParse(Console.ReadLine(), out myInt) && myInt >= 0)
                {
                    products.Find(FindProduct).Count = myInt;
                    Console.WriteLine("Mehsul uchun ashagidaki kateqoriyalardan birini sechin.");

                    foreach (var item in Enum.GetValues(typeof(Category)))
                        Console.WriteLine($"{(int)item} - {item}");

                    break;
                }

                Console.WriteLine("Duzgun say daxil edin!");
            }

            while (!myBool)
            {
                Console.Write("Kateqoriya indeksi: ");
                strInput.Replace(strInput.ToString(), Console.ReadLine());

                switch (strInput.ToString())
                {
                    case "1":
                        products.Find(FindProduct).Category = Category.Shirniyyat;
                        myBool = true;
                        break;
                    case "2":
                        products.Find(FindProduct).Category = Category.Et_Mehsullari;
                        myBool = true;
                        break;
                    case "3":
                        products.Find(FindProduct).Category = Category.Sud_Mehsullari;
                        myBool = true;
                        break;
                    case "4":
                        products.Find(FindProduct).Category = Category.Meishet_Avadanligi;
                        myBool = true;
                        break;
                    case "5":
                        products.Find(FindProduct).Category = Category.Ichki;
                        myBool = true;
                        break;
                    case "6":
                        products.Find(FindProduct).Category = Category.Meyve_Terevez;
                        myBool = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun kateqoriya indeksi daxil edin!");
                        break;
                }
            }

            Console.WriteLine(Environment.NewLine + "Yeni mehsul elave edildi!");
            Console.WriteLine(products.Find(FindProduct));
            myBool = false;
        }


        public void ChangeProductDetails()
        {
            Console.Write("Mehsulun kodunu daxil edin: ");
            strCode.Replace(strCode.ToString(), Console.ReadLine());

            // Mehsulun koduna uygun axtarish edilir. Koda uygun mehsul movcud deyilse sistemden chixilir.
            // Koda uygun mehsul movcuddursa deyishiklikler edilir.
            if (!products.Exists(FindProduct))
            {
                Console.WriteLine("Bu koda uygun mehsul tapilmadi.");
                return;
            }



        }



        public void RemoveProduct()
        {
            throw new NotImplementedException();
        }

        public void ShowAllProducts()
        {
            throw new NotImplementedException();
        }

        public void ShowCategoryBasedProducts()
        {
            throw new NotImplementedException();
        }

        public void ShowNameBasedProducts()
        {
            throw new NotImplementedException();
        }

        public void ShowPriceBasedProducts()
        {
            throw new NotImplementedException();
        }
    }
}
