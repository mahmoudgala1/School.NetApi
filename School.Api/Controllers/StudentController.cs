using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers;

[ApiController]
public class StudentController : AppControllerBase
{

    [HttpGet(Router.StudentRouting.List)]
    public async Task<IActionResult> GetStudentsListAsync()
    {
        return Ok(await Mediator.Send(new GetStudentListQuery()));
    }
    [HttpGet(Router.StudentRouting.Paginated)]
    public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet(Router.StudentRouting.GetById)]
    public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new GetStudentByIdQuery { Id = id }));
    }
    [HttpPost(Router.StudentRouting.Add)]
    public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentCommand student)
    {
        var result = await Mediator.Send(student);
        return NewResult(result);
    }
    [HttpPut(Router.StudentRouting.Edit)]
    public async Task<IActionResult> EditStudentAsync([FromBody] EditStudentCommand student)
    {
        var result = await Mediator.Send(student);
        return NewResult(result);
    }
    [HttpDelete(Router.StudentRouting.Delete)]
    public async Task<IActionResult> DeleteStudentAsync([FromRoute] int id)
    {
        var result = await Mediator.Send(new DeleteStudentCommand { Id = id });
        return NewResult(result);
    }
}
