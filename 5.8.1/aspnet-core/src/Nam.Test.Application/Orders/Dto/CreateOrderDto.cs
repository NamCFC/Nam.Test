using Abp.AutoMapper;
using Nam.Test.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nam.Test.Orders.Dto
{
    [AutoMapTo(typeof(Order))]
    public class CreateOrderDto
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public int Amount { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
