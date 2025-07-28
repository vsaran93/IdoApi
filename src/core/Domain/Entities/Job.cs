using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Job : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("job_category_id")]
        public int JobCategoryId { get; set; }

         [Column("job_sub_category_id")]
        public int JobSubCategoryId { get; set; }

         [Column("created_by")]
        public int CreatedBy { get; set; }

         [Column("assigned_to")]
        public int AssignedTo { get; set; }

         [Column("status")]
        public string Status { get; set; }

         [Column("address_id")]
        public int AddressId { get; set; }
    }
}