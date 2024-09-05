using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;
public class Subject
{
    public Subject()
    {
        StudentSubjects = new HashSet<StudentSubject>();
        DepartmentSubjects = new HashSet<DepartmentSubject>();
    }
    [Key]
    public int Id { get; set; }
    [StringLength(200)]
    public string Name { get; set; }
    public int? Period { get; set; }
    [InverseProperty("Subject")]
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    [InverseProperty("Subject")]
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
    [InverseProperty("Subject")]
    public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }
}
