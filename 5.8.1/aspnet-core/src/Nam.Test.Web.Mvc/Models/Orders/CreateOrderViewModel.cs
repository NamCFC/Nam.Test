using Microsoft.AspNetCore.Mvc.Rendering;
using Nam.Test.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nam.Test.Web.Models.Orders
{
    public class CreateOrderViewModel
    {
        public List<ProductDto> Products { get; set; }

        public List<CustomerDto> Customers { get; set; }

        public List<SelectListItem> GetProducts()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-Select Product-",
                    Selected = true,
                    Disabled = true
                }
            };
            list.AddRange(Products.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }));
            return list;
        }

        public List<SelectListItem> GetCustomers()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-Select Customer-",
                    Selected = true,
                    Disabled = true
                }
            };
            list.AddRange(Customers.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }));
            return list;
        }
    }
}
