using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(10)]
        [Unicode(false)]
        public string Pan { get; set; }
        [Required]
        [StringLength(250)]
        [Unicode(false)]
        public string Address { get; set; }
        [Required]
        [StringLength(1)]
        [Unicode(false)]
        public string Gender { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string MobileNumber { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Comment { get; set; }
        public int? DepartmentRef { get; set; }

        [ForeignKey(nameof(DepartmentRef))]
        [InverseProperty(nameof(Department.Users))]
        public virtual Department DepartmentRefNavigation { get; set; }
    }
}
