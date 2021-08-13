using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.Test.Orders.Dto
{
    public class OrderDto : EntityDto<Guid>
    {
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CategoryName { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int Amount { get; set; }

        public DateTime OrderDate { get; set; }
    }

    public class GetOrdersFilter
    {
        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public string Keyword { get; set; }
    }
}
