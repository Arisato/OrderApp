namespace OrderApp.Models.Dto
{
    public class CustomerOrderDto
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateOnly OrderDate { get; set; }

        public decimal TotalCost { get; set; }
    }
}
