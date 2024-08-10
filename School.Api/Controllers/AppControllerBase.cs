﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Core.Bases;
using System.Net;

namespace School.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AppControllerBase : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    public ObjectResult NewResult<T>(Response<T> response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                return new OkObjectResult(response);
            case HttpStatusCode.Created:
                return new CreatedResult(string.Empty, response);
            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(response);
            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(response);
            case HttpStatusCode.NotFound:
                return new NotFoundObjectResult(response);
            case HttpStatusCode.Accepted:
                return new AcceptedResult(string.Empty, response);
            case HttpStatusCode.UnprocessableEntity:
                return new UnprocessableEntityObjectResult(response);
            default:
                return new BadRequestObjectResult(response);
        }
    }
}
