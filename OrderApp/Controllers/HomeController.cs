using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Models;
using OrderApp.Models.ViewModels;
using OrderApp.Services.Order;

namespace OrderApp.Controllers;

public class HomeController : Controller
{
    private readonly IOrderService orderService;
    private readonly IMapper mapper;

    public HomeController(IOrderService orderService, IMapper mapper)
    {
        this.orderService = orderService;
        this.mapper = mapper;
    }

    public IActionResult Index()
    {
        return View(new OrderViewModel 
        { 
            OrderList = mapper.ProjectTo<CustomerOrderModel>(orderService.GetDiscountedOrders()).ToList() 
        });
    }
}
