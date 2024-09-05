using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Departments.Queries.Models;
using static School.Data.AppMetaData.Router;

namespace School.Api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var result = await Mediator.Send(new GetDepartmentByIdQuery { Id = id });
            return NewResult(result);
        }
    }
}
