using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class ApplicationLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, MaxLength(255)]
        public string ApplicationName { get; set; }
        public DateTime Date { get; set; }
        [Required, MaxLength(10)]
        public string Thread { get; set; }

        [Required, MaxLength(255)]
        public string TraceId { get; set; }

        [Required, MaxLength(50)]
        public string Level { get; set; }
        [Required, MaxLength(255)]
        public string Logger { get; set; }

        [Required]
        public string Message { get; set; }

        public string Exception { get; set; }

        [Required, MaxLength(2000)]
        public string Url { get; set; }

        [Required, MaxLength(1000)]
        public string ClassName { get; set; }

        [Required, MaxLength(1000)]
        public string MethodName { get; set; }

        [Required]
        public string Request { get; set; }
        [Required]
        public string Response { get; set; }
        public string Headers { get; set; }
    }
}
