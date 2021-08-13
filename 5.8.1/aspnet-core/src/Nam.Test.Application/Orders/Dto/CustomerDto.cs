using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Nam.Test.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.Test.Orders.Dto
{
    [AutoMapFrom(typeof(Customer))]
    public class CustomerDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
