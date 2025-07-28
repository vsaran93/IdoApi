using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserDetail
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("date_of_birth")]
        public string DateOfBirth { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("profile_picture_url")]
        public string ProfilePictureUrl { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        public User User { get; set; }
    }
}