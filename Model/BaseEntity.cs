using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
      public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime CreatedDateTime { get; set; }
        [StringLength(255)]
        public long CreatedById { get; set; }
        [StringLength(255)]
        public long ModifiedBy { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}