using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class JobSubCategory : BaseEntity
    {
        [Column("job_category_id")]
        public int JobCategoryId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public JobCategory JobCategory { get; set; }  = null!;
    }
}