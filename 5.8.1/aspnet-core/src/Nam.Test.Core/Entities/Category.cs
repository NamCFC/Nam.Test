using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nam.Test.Entities
{
    [Table("AppCategories", Schema = TestConsts.SchemaName)]
    public class Category : FullAuditedEntity<Guid>
    {
        [Required]
        [StringLength(TestConsts.MaxShortLineLength)]
        public string Name { get; set; }

        [StringLength(TestConsts.MaxDoubleLineLength)]
        public string Description { get; set; }
    }
}
