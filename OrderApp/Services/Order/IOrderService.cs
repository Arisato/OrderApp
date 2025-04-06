using OrderApp.Models.Dto;

namespace OrderApp.Services.Order
{
    public interface IOrderService
    {
        IQueryable<CustomerOrderDto> GetDiscountedOrders();
    }
}
