using School.Core.Features.Students.Queries.Results;
using School.Data.Models;

namespace School.Core.Mapping.Students;
public partial class StudentProfile
{
    public void GetSingleStudentMapping()
    {
        CreateMap<Student, GetSingleStudentResponse>()
            .ForMember(s => s.DepartmentName, options => options.MapFrom(s => s.Department.Name));
    }
}
