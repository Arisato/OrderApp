namespace OrderApp.Models
{
    public class CustomerOrderModel
    {
        public int OrderId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string OrderDate { get; set; } = string.Empty;

        public string TotalCost { get; set; } = string.Empty;
    }
}
