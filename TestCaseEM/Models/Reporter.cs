namespace TestCaseEM.Models
{
    public class Reporter
    {
        public readonly Dictionary<int, string> Districts = new()
        {
            { 0, "Все районы"}
        };

        public readonly List<Order> Orders = [];

        public Reporter()
        {
            LoadDistricts();
            LoadOrders();
        }

        private void LoadDistricts()
        {
            var lines = File.ReadAllLines("districts.txt");
            for (var i = 1; i < lines.Length; i++)
            {
                Districts.Add(i, lines[i]);
            }
        }

        public void ShowDistricts()
        {
            foreach (var district in Districts)
            {
                Console.WriteLine($"{district.Key}. {district.Value}");
            };
        }
        private void LoadOrders()
        {
            var lines = File.ReadAllLines("orders.txt");
            if (lines.Length <= 1)
                return;

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                var order = new Order
                {
                    OrderId = parts[0]
                };

                if (double.TryParse(parts[1], out var weight))
                    order.Weight = weight;

                if (int.TryParse(parts[2], out var distrId))
                {
                    if (Districts.TryGetValue(distrId, out var district))
                        order.District = district;
                }

                if (DateTime.TryParse(parts[3], out var date))
                    order.Time = date;

                Orders.Add(order);
            };
        }
    }
}
