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
    class MethodClass : IMarketable
    {
        List<Sale> sales = new List<Sale>();
        List<Product> products = new List<Product>();

        public void AddNewProduct()
        {
            products.Add(new Product());
            // Ashagidaki StringBuilder her novbeti user input-da yeni string yaratmamaq uchun istifade olunub.
            // Diger deyishenler ise user-in girish edeceyi mehsul qiymeti, sayi ve kateqoriyasinin duzgunluyunu yoxlamaq uchun istifade olunub.
            StringBuilder myString = new StringBuilder();
            double myDouble;
            int myInt;
            bool myBool = false;
            Console.WriteLine("Yeni mehsul detallarini daxil edin.");

            while (true)
            {
                Console.Write("Ad: ");
                myString.Append(Console.ReadLine());

                if (myString.ToString() != String.Empty)
                {
                    products[products.Count - 1].Name = myString.ToString();
                    myString.Clear();
                    break;
                }

                Console.WriteLine("Duzgun ad daxil edin!");
                myString.Clear();
            }

            while (true)
            {
                Console.Write("Qiymet: ");

                if (double.TryParse(Console.ReadLine(), out myDouble) && myDouble > 0)
                {
                    products[products.Count - 1].Price = myDouble;
                    break;
                }

                Console.WriteLine("Duzgun qiymet daxil edin!");
            }

            while (true)
            {
                Console.Write("Say: ");

                if (int.TryParse(Console.ReadLine(), out myInt) && myInt >= 0)
                {
                    products[products.Count - 1].Count = myInt;
                    break;
                }

                Console.WriteLine("Duzgun say daxil edin!");
            }

            while (true)
            {
                Console.Write("Kod: ");
                myString.Append(Console.ReadLine());

                if (myString.ToString() != String.Empty)
                {
                    products[products.Count - 1].Code = myString.ToString();
                    myString.Clear();
                    Console.WriteLine("Mehsul uchun ashagidaki kateqoriyalardan birini sechin.");

                    foreach (var item in Enum.GetValues(typeof(Category)))
                        Console.WriteLine($"{(int)item} - {item}");

                    break;
                }

                Console.WriteLine("Duzgun kod daxil edin!");
                myString.Clear();
            }

            while (!myBool)
            {
                Console.Write("Kateqoriya indeksi: ");
                myString.Append(Console.ReadLine());

                switch (myString.ToString())
                {
                    case "1":
                        products[products.Count - 1].Category = Category.Shirniyyat;
                        myBool = true;
                        break;
                    case "2":
                        products[products.Count - 1].Category = Category.Et_Mehsullari;
                        myBool = true;
                        break;
                    case "3":
                        products[products.Count - 1].Category = Category.Sud_Mehsullari;
                        myBool = true;
                        break;
                    case "4":
                        products[products.Count - 1].Category = Category.Meishet_Avadanligi;
                        myBool = true;
                        break;
                    case "5":
                        products[products.Count - 1].Category = Category.Ichki;
                        myBool = true;
                        break;
                    case "6":
                        products[products.Count - 1].Category = Category.Meyve_Terevez;
                        myBool = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun kateqoriya indeksi daxil edin!");
                        myString.Clear();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Yeni mehsul elave edildi!");
            Console.WriteLine(products[products.Count - 1]);
        }





        public void ChangeProductDetails()
        {
            throw new NotImplementedException();
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
