using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyFirstOpenIddict.Common.Models;

namespace Identity.Models
{
    public class UserProfile : IAuditableEntity
    {
        [Key]
        public Guid UserId { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string EmployeeCode { get; set; }
        [MaxLength(5)]
        public string Gender { get; set; }
        [MaxLength(200)]
        public string ReferPerson { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }

}
