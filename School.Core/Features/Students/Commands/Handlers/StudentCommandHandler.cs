using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Models;
using School.Service.Interfaces;

namespace School.Core.Features.Students.Commands.Handlers;
public class StudentCommandHandler : ResponseHandler
    , IRequestHandler<AddStudentCommand, Response<string>>
    , IRequestHandler<EditStudentCommand, Response<string>>
    , IRequestHandler<DeleteStudentCommand, Response<string>>
{
    #region Fields
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public StudentCommandHandler(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Student>(request);
        var result = await _studentService.AddStudentAsync(student);
        if (result == "Exist")
            return BadRequest<string>();
        return Created("Added Successfully");
    }

    public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdAsync(request.Id);
        if (student is null) return NotFound<string>();
        var studentMapper = _mapper.Map(request, student);
        var result = await _studentService.EditStudentAsync(studentMapper);
        return Success("Edit Successfully");
    }

    public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdAsync(request.Id);
        if (student is null) return NotFound<string>("Student Is Not Found");
        var result = await _studentService.DeleteStudentAsync(student);
        return Deleted<string>();
    }
    #endregion
}
