using System.ComponentModel.DataAnnotations;

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
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
}
