using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Departments.Queries.Models;
using School.Core.Features.Departments.Queries.Results;
using School.Service.Interfaces;

namespace School.Core.Features.Departments.Queries.Handlers;
public class DepartmentQueryHandler : ResponseHandler,
    IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
{
    #region Fields
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DepartmentQueryHandler(IDepartmentService departmentService, IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await _departmentService.GetDepartmentById(request.Id);
        if (department is null) return NotFound<GetDepartmentByIdResponse>();
        var departmentMapper = _mapper.Map<GetDepartmentByIdResponse>(department);
        return Success<GetDepartmentByIdResponse>(departmentMapper);
    }
    #endregion
}
