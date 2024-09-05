using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;
public class Department
{
    public Department()
    {
        Students = new HashSet<Student>();
        DepartmentSubjects = new HashSet<DepartmentSubject>();
    }
    [Key]
    public int Id { get; set; }
    [StringLength(200)]
    public string Name { get; set; }

    public int? InstructorManager { get; set; }
    [ForeignKey("InstructorManager")]
    [InverseProperty("DepartmentManager")]
    public Instructor Instructor { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Student> Students { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Instructor> Instructors { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
}
