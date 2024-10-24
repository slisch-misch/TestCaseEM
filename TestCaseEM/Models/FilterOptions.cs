namespace TestCaseEM.Models
{
    public class FilterOptions
    {
        public string? District { get; set; }
        public DateTime From { get; set; } = DateTime.MinValue;
        public DateTime To { get; set; } = DateTime.MaxValue;

        public int FilterOrders(List<Order> orders)
        {
            return !string.IsNullOrEmpty(District)
                ? orders.Count(i => i.District.Equals(District) && i.Time.HasValue && i.Time < To && i.Time > From)
                : orders.Count(i => i.Time.HasValue && i.Time < To && i.Time > From);
        }
    }
}
