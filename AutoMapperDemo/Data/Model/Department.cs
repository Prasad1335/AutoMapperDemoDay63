using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperDemo.Data.Models;

[Table("Department")]
public partial class Department
{

    public Department()
    {
        Users = new HashSet<User>();
    }

    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }
    [Required]
    [StringLength(500)]
    [Unicode(false)]
    public string Description { get; set; }
    [Column(TypeName = "text")]
   
    [InverseProperty(nameof(User.DepartmentRef))]
    public virtual ICollection<User> Users { get; set; }

}
