using MediatR;
using School.Core.Bases;
using School.Core.Features.Departments.Queries.Results;

namespace School.Core.Features.Departments.Queries.Models;
public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
{
    public int Id { get; set; }
}
