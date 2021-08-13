using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nam.Test.Controllers;
using Nam.Test.Orders;
using Nam.Test.Web.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nam.Test.Web.Controllers
{
    [AbpMvcAuthorize]
    public class OrdersController : TestControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrdersController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateModal()
        {
            var products = await _orderAppService.GetAllProducts();
            var customers = await _orderAppService.GetAllCustomers();
            var model = new CreateOrderViewModel
            {
                Products = products,
                Customers = customers
            };
            return PartialView("CreateModal", model);
        }
    }
}
