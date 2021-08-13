using Abp.Application.Services;
using Nam.Test.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nam.Test.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task<List<ProductDto>> GetAllProducts();
        Task<List<CustomerDto>> GetAllCustomers();
    }
}
