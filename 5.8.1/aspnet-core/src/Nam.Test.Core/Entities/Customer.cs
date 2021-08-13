using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nam.Test.Entities
{
    [Table("AppCustomers", Schema = TestConsts.SchemaName)]
    public class Customer : FullAuditedEntity<Guid>
    {
        [Required]
        [StringLength(TestConsts.MaxShortLineLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(TestConsts.MaxDoubleLineLength)]
        public string Address { get; set; }
    }
}
