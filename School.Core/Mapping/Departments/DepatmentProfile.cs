using AutoMapper;

namespace School.Core.Mapping.Departments;
public partial class DepatmentProfile : Profile
{
    public DepatmentProfile()
    {
        GetDepartmentByIdMapping();
    }
}
