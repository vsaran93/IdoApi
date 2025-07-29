using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Column("firstname")]
        public string Firstname { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        public UserDetail? UserDetail { get; set; }

        public ICollection<Role> Roles { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}