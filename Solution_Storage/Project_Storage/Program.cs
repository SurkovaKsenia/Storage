using System;
using System.Collections.Generic;
using System.Linq;
using StorageModel;
using Controllers;

namespace Project_Storage
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WindowWidth = 135;
            ManageStorage();
        }

        static void ManageStorage()
        {
            Console.Clear();
            ShowMenu();
            Console.WriteLine("Для выхода нажмите ESC");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.F1:
                    MenuItem.Input(Mock.Locations);
                    EndMethod();
                    break;
                case ConsoleKey.F2:
                    MenuItem.SearchProdact(Mock.Catalog, Mock.Locations, Mock.CountProduct);
                    EndMethod();
                    break;
                case ConsoleKey.F3:
                    MenuItem.AddNewProdact(Mock.Catalog);
                    EndMethod();
                    break;
                case ConsoleKey.F4:
                    MenuItem.SortBarcode(Mock.Catalog);
                    EndMethod();
                    break;
                case ConsoleKey.F5:
                    MenuItem.SortName(Mock.Catalog);
                    EndMethod();
                    break;
                case ConsoleKey.F6:
                    MenuItem.SortCount(Mock.Catalog, Mock.Locations, Mock.CountProduct,Mock.AllCount);
                    EndMethod();
                    break;
                case ConsoleKey.F7:
                    MenuItem.CalculateFullness(Mock.Locations);
                    EndMethod();
                    break;
                case ConsoleKey.F8:
                    MenuItem.SearchZone(Mock.Locations);
                    EndMethod();
                    break;
                case ConsoleKey.F9:
                    MenuItem.LoadFromFile(Mock.Locations);
                    EndMethod();
                    break;
                case ConsoleKey.F10:
                    MenuItem.SaveToFile(Mock.Locations);
                    EndMethod();
                    break;
            }
        }
        static void EndMethod()
        {
            Console.WriteLine("");
            Console.WriteLine("Чтобы вернуться в главное меню, нажмите Enter. Если хотите выйти, нажмите ESC");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    ManageStorage();
                    break;
                case ConsoleKey.Escape:
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
            Console.Write("F4 - Сортировка по штрих-коду | ");
            Console.Write("F5 - Сортировка по наименованию | ");
            Console.Write("F6 - Сортировка по количеству | ");
            Console.Write("F7 - Заполняемость склада | ");
            Console.Write("F8 - Поиск зоны | ");
            Console.Write("F9 - Загрузка из файла | ");
            Console.Write("F10 - Сохранение в файл | ");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
}
