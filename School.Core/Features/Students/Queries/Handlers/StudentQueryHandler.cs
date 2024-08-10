using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Results;
using School.Service.Interfaces;

namespace School.Core.Features.Students.Queries.Handlers;
public class StudentQueryHandler : ResponseHandler
    , IRequestHandler<GetStudentListQuery, Response<List<GetStudentListRsponse>>>,
    IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
{
    #region Fields
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public StudentQueryHandler(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetStudentListRsponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    {
        var studentList = await _studentService.GetStudentsListAsync();
        var studentListMapper = _mapper.Map<List<GetStudentListRsponse>>(studentList);
        return Success(studentListMapper);
    }
    public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdAsync(request.Id);
        if (student == null)
            return NotFound<GetSingleStudentResponse>();
        var studentMapper = _mapper.Map<GetSingleStudentResponse>(student);
        return Success(studentMapper);
    }
    #endregion
}
