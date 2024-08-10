using System.ComponentModel.DataAnnotations;

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
    public DateTime Period { get; set; }
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
}
