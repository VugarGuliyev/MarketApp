using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();

            bool bool1 = false;
            bool bool2 = false;

            while (!bool1)
            {
                Console.Clear();
                Console.WriteLine("*** MARKET IDAREETME SISTEMI ***");
                Console.Write(Environment.NewLine);
                Console.WriteLine("1 - Mehsul emeliyyatlari");
                Console.WriteLine("2 - Satish emeliyyatlari");
                Console.WriteLine("3 - Sistemden chix");
                Console.Write(Environment.NewLine);
                Console.Write("Sechim edin: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        while (!bool2)
                        {
                            Console.WriteLine("MEHSUL EMELIYYATLARI");
                            Console.Write(Environment.NewLine);
                            Console.WriteLine("1 - Yeni mehsul elave et");
                            Console.WriteLine("2 - Mehsul uzerinde duzelish et");
                            Console.WriteLine("3 - Mehsulu sil");
                            Console.WriteLine("4 - Butun mehsullari goster");
                            Console.WriteLine("5 - Kateqoriyaya uygun mehsullari goster");
                            Console.WriteLine("6 - Qiymet araligina uygun mehsullari goster");
                            Console.WriteLine("7 - Ada uygun mehsullari goster");
                            Console.WriteLine("8 - Esas menyuya qayit");
                            Console.Write(Environment.NewLine);
                            Console.Write("Sechim edin: ");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    process.AddNewProduct();
                                    break;
                                case "2":
                                    Console.Clear();
                                    process.ChangeProductDetails();
                                    break;
                                case "3":
                                    Console.Clear();
                                    process.RemoveProduct();
                                    break;
                                case "4":
                                    Console.Clear();
                                    process.ShowAllProducts();
                                    break;
                                case "5":
                                    Console.Clear();
                                    process.ShowCategoryBasedProducts();
                                    break;
                                case "6":
                                    Console.Clear();
                                    process.ShowPriceBasedProducts();
                                    break;
                                case "7":
                                    Console.Clear();
                                    process.ShowNameBasedProducts();
                                    break;
                                case "8":
                                    Console.Clear();
                                    bool2 = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Duzgun sechim edin.");
                                    Console.Write(Environment.NewLine);
                                    break;
                            }
                        }
                        bool2 = false;
                        break;
                    case "2":
                        Console.Clear();
                        while (!bool2)
                        {
                            Console.WriteLine("SATISH EMELIYYATLARI");
                            Console.Write(Environment.NewLine);
                            Console.WriteLine("1 - Yeni satish elave et");
                            Console.WriteLine("2 - Satishdan mehsul chixart");
                            Console.WriteLine("3 - Satishi sil");
                            Console.WriteLine("4 - Butun satishlari goster");
                            Console.WriteLine("5 - Verilen tarix araligina gore satishlari goster");
                            Console.WriteLine("6 - Verilen mebleg araligina gore satishlari goster");
                            Console.WriteLine("7 - Deqiq tarixe uygun satishlari goster");
                            Console.WriteLine("8 - Verilmish nomreye uygun gelen satishin melumatlarini goster");
                            Console.WriteLine("9 - Esas menyuya qayit");
                            Console.Write(Environment.NewLine);
                            Console.Write("Sechim edin: ");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    process.AddNewSale();
                                    break;
                                case "2":
                                    Console.Clear();
                                    process.ReturnProduct();
                                    break;
                                case "3":
                                    Console.Clear();
                                    process.RemoveSale();
                                    break;
                                case "4":
                                    Console.Clear();
                                    process.ShowAllSales();
                                    break;
                                case "5":
                                    Console.Clear();
                                    process.ShowDateBasedSales();
                                    break;
                                case "6":
                                    Console.Clear();
                                    process.ShowAmountBasedSales();
                                    break;
                                case "7":
                                    Console.Clear();
                                    process.ExactDateSale();
                                    break;
                                case "8":
                                    Console.Clear();
                                    process.ShowIDBasedSale();
                                    break;
                                case "9":
                                    Console.Clear();
                                    bool2 = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Duzgun sechim edin.");
                                    Console.Write(Environment.NewLine);
                                    break;
                            }
                        }
                        bool2 = false;
                        break;
                    case "3":
                        bool1 = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun sechim edin.");
                        Console.Write(Environment.NewLine);
                        break;
                }
            }


            Console.Read();
        }
    }
}
