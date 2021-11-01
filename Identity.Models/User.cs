using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyFirstOpenIddict.Common.Models;

namespace Identity.Models
{
    public class User : IAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(256), Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Required, MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string SecurityStamp { get; set; }

        public DateTime LastUpdatedPwd { get; set; }
        public int PwdExpiredDays { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public UserProfile UserProfile { get; set; }
    }


}
