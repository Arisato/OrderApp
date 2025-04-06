using Data;
using Data.Models;
using Moq;
using OrderApp.Services.Order;

namespace OrderAppTests.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public void GetDiscountedOrders_ValidCustomerOrdersReturned()
        {
            //Arrange
            var orders = new List<Order>
            {
                new Order {Id = 1, OrderDate = new DateOnly(2024, 05, 25), CustomerId = 1, UnitPrice = 1, Quantity = 5 },
                new Order {Id = 2, OrderDate = new DateOnly(2024, 03, 12), CustomerId = 3, UnitPrice = 1, Quantity = 15 },
                new Order {Id = 3, OrderDate = new DateOnly(2024, 07, 10), CustomerId = 2, UnitPrice = 1, Quantity = 25 },
                new Order {Id = 4, OrderDate = new DateOnly(2024, 08, 02), CustomerId = 3, UnitPrice = 1, Quantity = 40 }
            }.AsQueryable();

            var customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "John", LastName = "Smith"},
                new Customer { Id = 2, FirstName = "Mona", LastName = "Lisa"},
                new Customer { Id = 3, FirstName = "Jason", LastName = "Mason"},
                new Customer { Id = 4, FirstName = "NotIncludedInOrders", LastName = "NotIncludedInOrders"}
            }.AsQueryable();

            var mockedDataService = new Mock<IDataService>();

            mockedDataService.Setup(d => d.Orders).Returns(orders);
            mockedDataService.Setup(d => d.Customers).Returns(customers);

            //Act
            var result = new OrderService(mockedDataService.Object).GetDiscountedOrders();

            //Assert
            Assert.True(result.Count() == orders.Count());
            Assert.True(result.Where(o => o.CustomerId == 1).Count() == 1);
            Assert.True(result.Where(o => o.CustomerId == 2).Count() == 1);
            Assert.True(result.Where(o => o.CustomerId == 3).Count() == 2);
            Assert.False(result.Any(o => o.CustomerId == 4));
        }
    }
}
