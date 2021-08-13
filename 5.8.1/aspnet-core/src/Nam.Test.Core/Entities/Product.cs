using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nam.Test.Entities
{
    [Table("AppProducts", Schema = TestConsts.SchemaName)]
    public class Product : FullAuditedEntity<Guid>
    {
        [Required]
        [StringLength(TestConsts.MaxShortLineLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [StringLength(TestConsts.MaxDoubleLineLength)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
