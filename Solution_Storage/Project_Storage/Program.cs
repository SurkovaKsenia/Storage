using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Storage
{
    class Program
    {
        static Dictionary<long, string> Catalog = new Dictionary<long, string>
        {
            [1928365746539] = "Миска для животных  Welovepet",
            [6473846538247] = "Миска для животных FOXIE",
            [0973754739471] = "Когтеточка настенная угловая Take Easy",
            [6372846463512] = "Когтеточка для кошек BigHouse",
            [9082836562820] = "Домик для животных Bigarden",
            [3275694862906] = "Домик - люлька для кошек FISSA",
            [4572947586352] = "Носки для кошек и собак нескользящие GABYDOG",
            [2998679038591] = "Толстовка Superman для собак и кошек",
        };

        static Dictionary<string, long> Locations = new Dictionary<string, long>
        {
             ["A.000-a0"] =  1928365746539,
             ["B.001-b1"] =  6473846538247,
             ["C.012-c2"] =  0973754739471,
             ["D.013-d3"] =  6372846463512,
             ["E.024-e4"] =  9082836562820,
             ["F.035-f5"] =  3275694862906,
             ["G.046-a6"] =  4572947586352,
             ["H.047-b7"] =  2998679038591,
             ["I.148-c8"] =  9082836562820,
             ["J.149-d9"] =  1928365746539,
             ["K.250-e0"] =  9082836562820,
             ["L.251-f1"] =  4572947586352,
        };

        static Dictionary<string, int> CountProdact = new Dictionary<string, int> 
        {
            ["A.000-a0"] = 19,
            ["B.001-b1"] = 67,
            ["C.012-c2"] = 471,
            ["D.013-d3"] = 612,
            ["E.024-e4"] = 20,
            ["F.035-f5"] = 36,
            ["G.046-a6"] = 42,
            ["H.047-b7"] = 21,
            ["I.148-c8"] = 90,
            ["J.149-d9"] = 20,
            ["K.250-e0"] = 90,
            ["L.251-f1"] = 452,
        };
        static void Main(string[] args)
        {
            MangeStorage();
        }

        static void MangeStorage()
        {
            Console.Clear();
            ShowMenu();
            Console.WriteLine("Для выхода нажмите ESC");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.F1:
                    Input();
                    break;
                case ConsoleKey.F2:
                    SearchProdact(Catalog, Locations, CountProdact);
                    break;
                case ConsoleKey.F3:
                    AddNewProdact(Catalog);
                    break;
                case ConsoleKey.F4:
                    PrintCatalog(Catalog);
                    break;
                case ConsoleKey.F5:
                    CalculateFullness(Locations);
                    break;
            }
        }

        static void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("F1 - Ввод данных | ");
            Console.Write("F2 - Поиск товара | ");
            Console.Write("F3 - Добавление нового товара| ");
            Console.Write("F4 - Вывод каталога | ");
            Console.Write("F5 - Заполняемость склада | ");
            Console.WriteLine("");
            Console.ResetColor();
        }

        static void Input()
        {
            Console.Clear();
            while (true)
            {
                long barcode = InputBarcode();
                InputStorageLocation(CountProdact, Locations);
                Console.WriteLine("Для завершения ввода нажмите ESC");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Ввод данных завершён");
                    break; 
                }
            }
            EndMethod();
        }

        static void EndMethod()
        {
            Console.WriteLine("");
            Console.WriteLine("Чтобы вернуться в главное меню, нажмите Enter. Если хотите выйти, нажмите ESC");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    MangeStorage();
                    break;
                case ConsoleKey.Escape:
                    break;
            }
        }
        
        static long InputBarcode()
        {
            Console.WriteLine("Введите штрих-кода товара");
            
            if (!long.TryParse(Console.ReadLine(), out long barcode))
            {
                if (barcode.ToString().Length != 13)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Штрих-код должен состоять из 13 цифр!");
                    Console.ResetColor();
                    Console.WriteLine("Введите штрих-кода товара");
                    barcode = long.Parse(Console.ReadLine());
                }
            }
            
            return barcode;
        }
        static void CalculateFullness( Dictionary<string, long> Locations)
        {
            Console.Clear();
            int count_fullness = Locations.Count();

            int count = Locations.Values.Count(l => (l != 0));

            double fullness = Convert.ToDouble(count_fullness * 100) / count;

            Console.WriteLine($"Заполняемость склада {fullness} %");
            
            EndMethod();

        }

        static void InputStorageLocation(Dictionary <string, int> CountProdact, Dictionary<string, long> Locations)
        {
            Console.WriteLine("Место хранения товара :");
            do
            {
              string  zone    = GetZone();
                  int rack    = GetRack();
               string section = GetSection();
                  int shelf   = GetShelf();
            int count_prodact = GetCountProdact();
                
                string key = $"{zone}.{rack}-{section}{shelf}"; 
                CountProdact.Add(key, count_prodact);
                
                Console.WriteLine("Если вы хотите продолжить ввод, нажмите Enter, если хотите ввести другой товар - ESC");
            }
            
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static string GetZone()
        {
            Console.Write("Зона :  ");
            string zone = Console.ReadLine().ToUpper();
            while (zone.Length >2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Максимальное число символов равно 2. Введите наименование зоны ещё раз");
                Console.ResetColor();
                Console.Write("Зона :  ");
                zone = Console.ReadLine().ToUpper();
            }
            return zone;
        }

        static int GetRack()
        {
            Console.Write("Стеллаж :  ");
            if (!int.TryParse(Console.ReadLine(), out int rack))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номер стеллажа находится в диапазоне [0;999]. Пожалуйста, введите номер ещё раз");
                Console.ResetColor();
                Console.Write("Стеллаж :  ");
                rack = int.Parse(Console.ReadLine());
            }
            return rack;
        }

        static string GetSection()
        {
            Console.Write("Секция :  ");
            string section = Console.ReadLine().ToLower();
            while (section.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Наименование секции должно состоять из 1 буквы. Введите наименование ещё раз");
                Console.ResetColor();
                Console.Write("Секция :  ");
                section = Console.ReadLine().ToUpper();
            }
            return section;
        }

        static int GetShelf()
        {
            Console.Write("Полка :  ");
            
            if (!int.TryParse(Console.ReadLine(), out int shelf))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номер полки находится в диапазоне [0;9]. Пожалуйста, введите номер ещё раз");
                Console.ResetColor();
                Console.Write("Полка :  ");
                shelf = int.Parse(Console.ReadLine());
            }
            
            return shelf;
        }

        static int GetCountProdact()
        {
            Console.Write("Количество :  ");

            if (!int.TryParse(Console.ReadLine(), out int count_prodact))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели не количество! Попробуйте ещё раз!");
                Console.ResetColor();
                Console.Write("Количество :  ");
                count_prodact = int.Parse(Console.ReadLine());
            }
            else
            {
                if (count_prodact < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Количество не может быть отрицательным! Попробуйте ещё раз!");
                    Console.ResetColor();
                    Console.WriteLine("Количество : ");
                    count_prodact = int.Parse(Console.ReadLine());
                }
            }
            
            return count_prodact;
        } 
        
        static void SearchProdact(Dictionary <long, string> Catalog, Dictionary <string, long> Locations, 
                                  Dictionary <string, int> CountProdact)
        {
            Console.Clear();
            long barcode = InputBarcode();
            int count_prodact = 0;

            foreach (var prodact in Catalog)
            {
                if (barcode == prodact.Key)
                {
                    Console.WriteLine($"Наименование: {prodact.Value}");
                    Console.WriteLine(" ");
                    Console.WriteLine("Хранится:");

                    foreach (var location in Locations)
                    {
                        if (barcode == location.Value)
                        {
                            foreach (var count in CountProdact)
                            {
                                if (location.Key == count.Key)
                                {
                                    Console.WriteLine($"На полке {count.Key} в количестве {count.Value} шт.");
                                    count_prodact += count.Value;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine($"Итого {count_prodact} шт.");
            
            EndMethod();
        }

        static void AddNewProdact(Dictionary <long, string> Catalog)
        {
            Console.Clear();
            Console.WriteLine("Введите наименование товара:");
            string prodact_name = Console.ReadLine();

            long barcode = InputBarcode();

            byte pr = 0;
            foreach (var prodact in Catalog)
            {
                if (prodact.Key == barcode)
                {
                    Console.WriteLine("Такой товар уже есть!");
                    pr = 1;
                    break;
                }
                else pr = 0;     
            }

            if (pr == 0)
            {
                Catalog.Add(barcode, prodact_name);
                Console.WriteLine("Новый товар добавлен в каталог!");
            }

            EndMethod(); 
        }

        static void PrintCatalog(Dictionary <long, string> Catalog)
        {
            Console.Clear();
            foreach (var prodact in Catalog)
            {
                Console.WriteLine($"{prodact.Key.ToString()} - {prodact.Value}");
            }
            
            EndMethod();
        }
    }
}
