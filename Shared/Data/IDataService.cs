using Data.Models;

namespace Data
{
    public interface IDataService
    {
        IQueryable<Order> Orders { get; }

        IQueryable<Customer> Customers { get;  }
    }
}
