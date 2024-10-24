namespace TestCaseEM.Models
{
    internal static class LogWriter
    {
        public static void WriteLog(FilterOptions filter)
        {
            while (true)
            {
                Console.WriteLine("Введите адрес файлов для логов");
                var filePath = Console.ReadLine();

                if (ValidateLogFilePath(filePath))
                {
                    try
                    {
                        using var writer = new StreamWriter(filePath, append: true);
                        writer.AutoFlush = true;
                        writer.WriteLine($"{DateTime.Now} - district: {filter.District}, {filter.From}-{filter.To}");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при записи логов: {ex.Message}");
                    }
                }
            }
        }

        public static void WriteResult(FilterOptions filter, int result)
        {
            while (true)
            {
                Console.WriteLine("Введите адрес файлов для результатов");
                var filePath = Console.ReadLine();

                if (ValidateLogFilePath(filePath))
                {
                    try
                    {
                        using var writer = new StreamWriter(filePath, append: true);
                        writer.AutoFlush = true;
                        writer.WriteLine($"{DateTime.Now} - district: {filter.District}, {filter.From}-{filter.To}: result: {result}");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при записи результата: {ex.Message}");
                    }
                }
            }
        }
        private static bool ValidateLogFilePath(string? filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Путь к файлу не может быть пустым.");
                return false;
            }

            try
            {
                File.Create(filePath).Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка доступа к файлу или директории: {ex.Message}");
                return false;
            }
        }
    }
}
