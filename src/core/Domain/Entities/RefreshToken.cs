using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("token")]
        public string Token { get; set; }

        [Column("ip_address")]
        public string IpAddress { get; set; }

        [Column("user_agent")]
        public string UserAgent { get; set; }

        [Column("expires_at")]
        public DateTime ExpiresAt { get; set; }
        public User User { get; set; }

    }
}