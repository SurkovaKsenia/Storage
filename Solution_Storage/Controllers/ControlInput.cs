using System;

namespace Controllers
{
    public class ControlInput
    {
        public static long InputBarcode()
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
        public static string GetZone()
        {
            Console.Write("Зона :  ");
            string zone = Console.ReadLine().ToUpper();
            while (zone.Length > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Максимальное число символов равно 2. Введите наименование зоны ещё раз");
                Console.ResetColor();
                Console.Write("Зона :  ");
                zone = Console.ReadLine().ToUpper();
            }
            return zone;
        }

        public static int GetRack()
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

        public static string GetSection()
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

        public static int GetShelf()
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

        public static int GetCountProdact()
        {
            Console.Write("Количество :  ");

            if (!int.TryParse(Console.ReadLine(), out int count_product))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели не количество! Попробуйте ещё раз!");
                Console.ResetColor();
                Console.Write("Количество :  ");
                count_product = int.Parse(Console.ReadLine());
            }
            else
            {
                if (count_product < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Количество не может быть отрицательным! Попробуйте ещё раз!");
                    Console.ResetColor();
                    Console.WriteLine("Количество : ");
                    count_product = int.Parse(Console.ReadLine());
                }
            }

            return count_product;
        }
    }
}
