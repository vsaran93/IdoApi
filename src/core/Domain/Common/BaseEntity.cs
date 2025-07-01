using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        [Column("created_by")]
        public string CreatedBy { get; set; }

        [Column("last_modified")]
        public DateTime LastModified { get; set; }
        
        [Column("last_modified_by")]
        public string LastModifiedBy { get; set; }
    }
}