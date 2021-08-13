using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Nam.Test.Entities;
using Nam.Test.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nam.Test.Orders
{
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IRepository<Order, Guid> _orderRepository;

        public OrderAppService(
            IRepository<Category, Guid> categoryRepository,
            IRepository<Product, Guid> productRepository,
            IRepository<Customer, Guid> customerRepository,
            IRepository<Order, Guid> orderRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        #region Order
        public async Task<PagedResultDto<OrderDto>> GetAllOrders(GetOrdersFilter input)
        {
            var query = await _orderRepository.GetAll().Include(u => u.Product).ThenInclude(u => u.Category).Include(u => u.Customer)
                .Select(u => new OrderDto
                {
                    Id = u.Id,
                    Amount = u.Amount,
                    ProductId = u.ProductId,
                    ProductName = u.Product.Name,
                    CustomerId = u.CustomerId,
                    OrderDate = u.OrderDate,
                    CategoryName = u.Product.Category.Name,
                    CustomerName = u.Customer.Name
                }).WhereIf(!string.IsNullOrEmpty(input.Keyword), u => u.ProductName.Trim().ToLower().Contains(input.Keyword.Trim().ToLower()))
                .ToListAsync();
            var result = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            return new PagedResultDto<OrderDto>(query.Count(), result);
        }

        public async Task Create(CreateOrderDto input)
        {
            var product = await _productRepository.GetAll().FirstOrDefaultAsync(u => u.Id == input.ProductId);
            if(product == null)
                throw new UserFriendlyException("Product does not exist");
            if (product.Quantity < input.Amount)
                throw new UserFriendlyException("Product quantity is not enough");
            product.Quantity -= input.Amount;
            _productRepository.Update(product);
            var obj = ObjectMapper.Map<Order>(input);
            await _orderRepository.InsertAsync(obj);
        }
        #endregion

        #region Product
        public async Task<List<ProductDto>> GetAllProducts()
        {
            var query = await _productRepository.GetAllListAsync();
            return ObjectMapper.Map<List<ProductDto>>(query);
        }
        #endregion

        #region Customer
        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            var query = await _customerRepository.GetAllListAsync();
            return ObjectMapper.Map<List<CustomerDto>>(query);
        }
        #endregion
    }
}
