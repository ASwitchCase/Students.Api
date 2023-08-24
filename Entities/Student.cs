using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Api.Entities
{
    public class Student
    {
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set;}
        public string? Email { get; set; }
        [Required]
        [StringLength(30)]
        public string? Major { get; set; }
        [Required]
        [Range(0,4)]
        public decimal Gpa { get; set; }
        public Guid Id {get; set;}

    }
}