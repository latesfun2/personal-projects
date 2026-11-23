using System;
using System.Collections.Generic;

namespace Обучалка
{
    class Program
    {
        static Dictionary<string, Dictionary<string, double>> rates = new Dictionary<string, Dictionary<string, double>>()
        {
            { "euro", new Dictionary<string, double> { { "rub", 89.74 }, { "dolar", 1.14 }, { "zl", 4.33 } } },
            { "rub", new Dictionary<string, double> { { "euro", 1 / 89.74 }, { "dolar", 78.75 }, { "zl", 20.75 } } },
            { "dolar", new Dictionary<string, double> { { "euro", 0.88 }, { "rub", 78.75 }, { "zl", 20.75 } } },
            { "zl", new Dictionary<string, double> { { "euro", 0.23 }, { "dolar", 0.26 }, { "rub", 20.75 } } }
        };

        static void Main()
        {
            Console.WriteLine("Выберите валюту для конвертации: euro(1), rub(2), dolar(3), zl(4)");
            int mainChoice = int.Parse(Console.ReadLine());
            string[] mainCurrencies = { "euro", "rub", "dolar", "zl" };

            if (mainChoice < 1 || mainChoice > 4)
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            string fromCurrency = mainCurrencies[mainChoice - 1];

            Console.WriteLine($"В какую валюту хотите конвертировать? (euro(1), rub(2), dolar(3), zl(4))");
            int targetChoice = int.Parse(Console.ReadLine());

            if (targetChoice < 1 || targetChoice > 4)
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            string toCurrency = mainCurrencies[targetChoice - 1];

            Console.Write($"Введите сумму для конвертации {fromCurrency}: ");
            double amount = double.Parse(Console.ReadLine());

            if (rates[fromCurrency].ContainsKey(toCurrency))
            {
                double rate = rates[fromCurrency][toCurrency];
                Console.WriteLine($"Результат: {amount} {fromCurrency} = {amount * rate} {toCurrency}");
            }
            else
            {
                Console.WriteLine("Конвертация для выбранных валют недоступна.");
            }
        }
    }
}