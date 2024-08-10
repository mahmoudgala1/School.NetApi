using School.Core.Features.Students.Commands.Models;
using School.Data.Models;

namespace School.Core.Mapping.Students;
public partial class StudentProfile
{
    public void EditStudentCommandMapping()
    {
        CreateMap<EditStudentCommand, Student>();
    }
}
