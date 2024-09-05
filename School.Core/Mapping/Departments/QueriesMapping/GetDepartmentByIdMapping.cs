using School.Core.Features.Departments.Queries.Results;
using School.Data.Models;

namespace School.Core.Mapping.Departments;
public partial class DepatmentProfile
{
    public void GetDepartmentByIdMapping()
    {
        CreateMap<Department, GetDepartmentByIdResponse>()
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Name))
            .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
            .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
            .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors));

        CreateMap<DepartmentSubject, SubjectResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubjectId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Name));

        CreateMap<Student, StudentResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<Instructor, InstructorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
