using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Nam.Test.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.Test.Orders.Dto
{
    [AutoMapFrom(typeof(Product))]
    public class ProductDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
    }
}
