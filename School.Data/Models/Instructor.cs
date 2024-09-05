using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;
public class Instructor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public int? SupervisorId { get; set; }
    [ForeignKey("SupervisorId")]
    [InverseProperty("Instructors")]
    public virtual Instructor Supervisor { get; set; }

    [InverseProperty("Supervisor")]
    public virtual ICollection<Instructor> Instructors { get; set; }

    public int? DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    [InverseProperty("Instructors")]
    public virtual Department Department { get; set; }

    [InverseProperty("Instructor")]
    public virtual Department DepartmentManager { get; set; }

    [InverseProperty("Instructor")]
    public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }
}
