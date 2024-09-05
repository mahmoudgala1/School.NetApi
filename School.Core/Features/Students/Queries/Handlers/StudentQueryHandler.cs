using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Results;
using School.Core.Resources;
using School.Core.Wrappers;
using School.Data.Models;
using School.Service.Interfaces;
using System.Linq.Expressions;

namespace School.Core.Features.Students.Queries.Handlers;
public class StudentQueryHandler : ResponseHandler
    , IRequestHandler<GetStudentListQuery, Response<List<GetStudentListRsponse>>>,
    IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
    IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
{
    #region Fields
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    #endregion

    #region Constructors
    public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer)
    {
        _studentService = studentService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetStudentListRsponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    {
        var studentList = await _studentService.GetStudentsListAsync();
        var studentListMapper = _mapper.Map<List<GetStudentListRsponse>>(studentList);
        return Success(studentListMapper, new { Count = studentListMapper.Count });
    }
    public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdAsync(request.Id);
        if (student == null)
            return NotFound<GetSingleStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
        var studentMapper = _mapper.Map<GetSingleStudentResponse>(student);
        return Success(studentMapper);
    }

    public Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Id, e.Name, e.Address, e.Phone, e.Department.Name);
        var querable = _studentService.FilterStudentPaginatedQueryable(request.OrderBy, request.Search).Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return querable;
    }
    #endregion
}
