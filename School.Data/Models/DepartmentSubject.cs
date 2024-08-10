using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace School.Data.Models;
public class DepartmentSubject
{
    [Key]
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public int SubjectId { get; set; }
    [ForeignKey("DepartmentId")]
    public virtual Department Department { get; set; }
    [ForeignKey("SubjectId")]
    public virtual Subject Subject { get; set; }
}
