using Data.Models;

namespace Data
{
    public class DataService : IDataService
    {
        public IQueryable<Order> Orders => new List<Order> 
        {
            new Order {Id = 1, OrderDate = new DateOnly(2024, 05, 25), CustomerId = 1, UnitPrice = 1, Quantity = 5 },
            new Order {Id = 2, OrderDate = new DateOnly(2024, 03, 12), CustomerId = 3, UnitPrice = 1, Quantity = 15 },
            new Order {Id = 3, OrderDate = new DateOnly(2024, 07, 10), CustomerId = 2, UnitPrice = 1, Quantity = 25 },
            new Order {Id = 4, OrderDate = new DateOnly(2024, 08, 02), CustomerId = 3, UnitPrice = 1, Quantity = 40 }
        }.AsQueryable();

        public IQueryable<Customer> Customers => new List<Customer>
        {
            new Customer { Id = 1, FirstName = "John", LastName = "Smith"},
            new Customer { Id = 2, FirstName = "Mona", LastName = "Lisa"},
            new Customer { Id = 3, FirstName = "Jason", LastName = "Mason"}
        }.AsQueryable();
    }
}
