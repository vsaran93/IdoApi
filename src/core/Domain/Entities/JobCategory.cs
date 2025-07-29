using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class JobCategory : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public ICollection<JobSubCategory> JobSubCategories { get; } = new List<JobSubCategory>();
    }
}