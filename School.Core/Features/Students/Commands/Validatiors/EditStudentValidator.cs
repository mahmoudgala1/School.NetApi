using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using School.Service.Interfaces;

namespace School.Core.Features.Students.Commands.Validatiors;
public class EditStudentValidator : AbstractValidator<EditStudentCommand>
{
    private readonly IStudentService _studentService;
    public EditStudentValidator(IStudentService studentService)
    {
        _studentService = studentService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(student => student.Id).NotNull().NotEmpty();
    }
    public void ApplyCustomValidationRules()
    {
        RuleFor(student => student.Name)
            .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExist(Key, model.Id))
            .WithMessage("Name Is Exist");
    }
}
