namespace Data.Models
{
    public class Order
    {
       public int Id { get; set; }

       public int CustomerId { get; set; }

       public DateOnly OrderDate { get; set; }

       public decimal UnitPrice { get; set; }

       public int Quantity { get; set; }
    }
}
