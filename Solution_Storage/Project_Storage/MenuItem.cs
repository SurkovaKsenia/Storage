using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using StorageModel;
using Files;

namespace Project_Storage
{
    class MenuItem
    {
        public static void Input(Dictionary<string, long> Locations)
        {
            Console.Clear();
            while (true)
            {
                long barcode = ControlInput.InputBarcode();
                string key = InputStorageLocation(Mock.CountProduct, Mock.Locations);
                Console.WriteLine("Для завершения ввода нажмите ESC");

                Locations.Add(key, barcode);

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Ввод данных завершён");
                    break;
                }
            }
        }

        public static void CalculateFullness(Dictionary<string, long> Locations)
        {
            Console.Clear();
            int count_fullness = Locations.Count();

            int count = Locations.Values.Count(l => (l != 0));

            double fullness = Convert.ToDouble(count * 100) / count_fullness;

            Console.WriteLine($"Заполняемость склада {fullness} %");
            Console.WriteLine();
            foreach (var loc in Locations)
            {
                if (loc.Value == 0)
                {   Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Место хранения: {loc.Key}  свободно");
                    Console.ResetColor();
                }
                else Console.WriteLine($"Место хранения: {loc.Key} Товар: {loc.Value}");
            }
        }

        public static string InputStorageLocation(Dictionary<string, int> CountProduct, Dictionary<string, long> Locations)
        {
            string key;
            Console.WriteLine("Место хранения товара :");
            do
            {
                string zone = ControlInput.GetZone();
                int rack = ControlInput.GetRack();
                string section = ControlInput.GetSection();
                int shelf = ControlInput.GetShelf();
                int count_product = ControlInput.GetCountProdact();

                key = $"{zone}.{rack}-{section}{shelf}";
                CountProduct.Add(key, count_product);

                Console.WriteLine("Если вы хотите продолжить ввод, нажмите Enter, если хотите ввести другой товар - ESC");
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape);
            return key;
        }

        public static void SearchProdact(Dictionary<long, string> Catalog, Dictionary<string, long> Locations,
                                  Dictionary<string, int> CountProduct)
        {
            Console.Clear();
            long barcode = ControlInput.InputBarcode();
            int count_product = 0;

            foreach (var product in Catalog)
            {
                if (barcode == product.Key)
                {
                    Console.WriteLine($"Наименование: {product.Value}");
                    Console.WriteLine(" ");
                    Console.WriteLine("Хранится:");

                    foreach (var location in Locations)
                    {
                        if (barcode == location.Value)
                        {
                            foreach (var count in CountProduct)
                            {
                                if (location.Key == count.Key)
                                {
                                    Console.WriteLine($"На полке {count.Key} в количестве {count.Value} шт.");
                                    count_product += count.Value;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine($"Итого {count_product} шт.");
        }

        public static void AddNewProdact(Dictionary<long, string> Catalog)
        {
            Console.Clear();
            Console.WriteLine("Введите наименование товара:");
            string product_name = Console.ReadLine();

            long barcode = ControlInput.InputBarcode();

            byte pr = 0;
            foreach (var item in Catalog)
            {
                if (item.Key == barcode)
                {
                    Console.WriteLine("Такой товар уже есть!");
                    pr = 1;
                    break;
                }
                else pr = 0;
            }

            if (pr == 0)
            {
                Product product = new Product(product_name, barcode);
                Catalog.Add(barcode, product_name);
                Console.WriteLine("Новый товар добавлен в каталог!");
            }
        }

        public static void SortBarcode(Dictionary<long, string> Catalog)
        {
            Console.Clear();
            Console.WriteLine("↑ - сортировка по возрастанию, ↓ - по убыванию");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("");
                    var ByBarcode = Catalog.OrderBy(c => c.Key);
                    foreach (var product in ByBarcode)
                    {
                        Console.WriteLine($"{product.Key.ToString()} - {product.Value}");
                    }
                    break;

                case ConsoleKey.DownArrow:
                    Console.WriteLine("");
                    var DescendingBarcode = Catalog.OrderByDescending(c => c.Key);
                    foreach (var product in DescendingBarcode)
                    {
                        Console.WriteLine($"{product.Key.ToString()} - {product.Value}");
                    }
                    break;
            }
        }
        public static void SortName(Dictionary<long, string> Catalog)
        {
            Console.Clear();
            Console.WriteLine("↑ - сортировка по возрастанию, ↓ - по убыванию");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("");
                    var ByName = Catalog.OrderBy(c => c.Value);
                    foreach (var product in ByName)
                    {
                        Console.WriteLine($"{product.Value} - {product.Key.ToString()}");
                    }
                    break;

                case ConsoleKey.DownArrow:
                    Console.WriteLine("");
                    var DescendingName = Catalog.OrderByDescending(c => c.Value);
                    foreach (var product in DescendingName)
                    {
                        Console.WriteLine($"{product.Value} - {product.Key.ToString()}");
                    }
                    break;
            }
        }

        public static void SortCount(Dictionary<long, string> Catalog, Dictionary<string, long> Locations,
                                     Dictionary<string, int> CountProduct, Dictionary<string, int> AllCount)
        {
            AllCount.Clear();
            int count_product = 0;
            foreach (var product in Catalog)
            {
                if (product.Key == product.Key)
                {
                    count_product = 0;
                    foreach (var location in Locations)
                    {
                        if (product.Key == location.Value)
                        {
                            foreach (var count in CountProduct)
                            {
                                if (location.Key == count.Key)
                                {
                                    count_product += count.Value;
                                }
                            }
                        }
                    }
                    AllCount.Add(product.Value, count_product);
                }
            }
            Console.Clear();
            Console.WriteLine("↑ - сортировка по возрастанию, ↓ - по убыванию");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("");
                    var ByCount = AllCount.OrderBy(c => c.Value);
                    foreach (var product in ByCount)
                    {
                        Console.WriteLine($"{product.Value} шт. - {product.Key.ToString()}");
                    }
                    break;

                case ConsoleKey.DownArrow:
                    Console.WriteLine("");
                    var DescendingCount = AllCount.OrderByDescending(c => c.Value);
                    foreach (var product in DescendingCount)
                    {
                        Console.WriteLine($"{product.Value} шт. - {product.Key.ToString()}");
                    }
                    break;
            }
        }

        public static void SearchZone(Dictionary<string, long> Locations)
        {
            byte pr = 0;
            Console.Clear();
            Console.WriteLine("Введите зону для поиска");
            string zone = ControlInput.GetZone();

            foreach (var loc in Locations)
            {
                if (loc.Key.Substring(0, 2) == zone || loc.Key.Substring(0, 1) == zone || loc.Key.Substring(1, 1) == zone)
                {
                    Console.WriteLine($"Зона: {loc.Key} Товар: {loc.Value}");
                    pr = 1;
                }
            }

            if (pr == 0) Console.WriteLine("Зона не найдена");
        }
        public static void SaveToFile(Dictionary<string,long> Locations)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Сохранение реализовано только для словаря Locations. Остальные находятся в разработке");
            Console.ResetColor();

            string fileName = FileControl.ReadPathToSave();
            FileTypes fileType = FileControl.ReadFileType();
            try
            {
                switch (fileType)
                {
                    case FileTypes.Xml: FileManager.SaveToXml(fileName, Locations); break;
                    case FileTypes.Json: FileManager.SaveToJson(fileName, Locations); break;
                }
                Console.WriteLine("Файл успешно сохранен!");
            }
            catch (Exception e)
            {
                Console.WriteLine("При сохранении файла произошла ошибка: " + e.Message);
            }
        }
        public static void LoadFromFile(Dictionary<string, long> Locations)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Загрузка реализована только для словаря Locations. Остальные находятся в разработке");
            Console.ResetColor();

            string fileName = FileControl.ReadPathToLoad();
            FileTypes? fileType = FileManager.CheckFileType(fileName);
            try
            {
                switch (fileType)
                {
                    case FileTypes.Xml:FileManager.LoadFromXml(fileName, Locations); break;
                    case FileTypes.Json: FileManager.LoadFromJson(fileName, Locations); break;
                    default: throw new InvalidOperationException("Формат файла не распознан. Используйте XML или JSON.");
                }
                Console.WriteLine("Файл успешно загружен!");
            }
            catch (Exception e)
            {
                Console.WriteLine("При загрузке файла произошла ошибка: " + e.Message);
            }
        }
    }
}
