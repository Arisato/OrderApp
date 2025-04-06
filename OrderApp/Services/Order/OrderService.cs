using Data;
using OrderApp.Helpers;
using OrderApp.Models.Dto;

namespace OrderApp.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IDataService dataService;

        public OrderService(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public IQueryable<CustomerOrderDto> GetDiscountedOrders()
        {
            var customerOrders = from order in dataService.Orders
                                 join customer in dataService.Customers
                                 on order.CustomerId equals customer.Id
                                 select new CustomerOrderDto
                                 {
                                     OrderId = order.Id,
                                     OrderDate = order.OrderDate,
                                     CustomerId = customer.Id,
                                     FirstName = customer.FirstName,
                                     LastName = customer.LastName,
                                     TotalCost = order.Quantity > 9 ? DiscountHelper.CalculateDiscount(order.UnitPrice, order.Quantity) : order.UnitPrice * order.Quantity
                                 };

            return customerOrders.OrderBy(o => o.OrderId);
        }
    }
}
