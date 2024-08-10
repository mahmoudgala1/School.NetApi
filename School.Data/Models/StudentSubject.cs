using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;
public class StudentSubject
{
    [Key]
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    [ForeignKey("StudentId")]
    public virtual Student Student { get; set; }
    [ForeignKey("SubjectId")]
    public virtual Subject Subject { get; set; }
}
