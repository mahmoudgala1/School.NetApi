using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;
public class InstructorSubject
{
    [Key]
    public int InstructorId { get; set; }
    [Key]
    public int SubjectId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("InstructorSubjects")]
    public virtual Instructor Instructor { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("InstructorSubjects")]
    public virtual Subject Subject { get; set; }
}
