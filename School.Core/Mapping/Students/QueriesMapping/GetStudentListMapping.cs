using School.Core.Features.Students.Queries.Results;
using School.Data.Models;

namespace School.Core.Mapping.Students;
public partial class StudentProfile
{
    public void GetStudentListMapping()
    {
        CreateMap<Student, GetStudentListRsponse>()
            .ForMember(s => s.DepartmentName, options => options.MapFrom(s => s.Department.Name));
    }
}
