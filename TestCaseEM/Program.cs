using TestCaseEM.Models;

namespace TestCaseEM
{
    internal class Program
    {
        static void Main()
        {
            var report = new Reporter();
            var filter = new FilterOptions();
            report.ShowDistricts();

            Console.WriteLine("Выберите номер района");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var distrNum))
                {
                    if (report.Districts.TryGetValue(distrNum, out var distr))
                    {
                        if (distrNum != 0)
                            filter.District = distr;
                        break;
                    }
                    Console.WriteLine($"Неверный номер района {distrNum}. Попробуйте еще раз.");
                }
                else
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
            }

            Console.WriteLine("Введите начало периода (формат: yyyy-MM-dd HH:mm:ss)");
            while (true)
            {
                var fromInput = Console.ReadLine();
                if (DateTime.TryParse(fromInput, out var from))
                {
                    filter.From = from;
                    filter.To = from.AddMinutes(30);
                    Console.WriteLine($"Конец периода - {from} + 30 минут = {filter.To}");
                    break;
                }
                Console.WriteLine("Неверный формат даты. Пожалуйста, используйте формат yyyy-MM-dd.");
            }

            var quantityOrders = filter.FilterOrders(report.Orders);
            Console.WriteLine($"Кол-во заказов - {quantityOrders}");

            LogWriter.WriteLog(filter);
            LogWriter.WriteResult(filter, quantityOrders);
        }
    }
}