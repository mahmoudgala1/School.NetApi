using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;
public class Student
{
    public Student()
    {
        StudentSubjects = new HashSet<StudentSubject>();
    }
    [Key]
    public int Id { get; set; }
    [StringLength(200)]
    public string Name { get; set; }
    [StringLength(500)]
    public string Address { get; set; }
    [StringLength(11)]
    public string Phone { get; set; }

    public int? DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    [InverseProperty("Students")]
    public virtual Department Department { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
}
