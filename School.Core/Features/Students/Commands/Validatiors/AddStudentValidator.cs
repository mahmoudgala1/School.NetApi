using FluentValidation;
using School.Core.Features.Students.Commands.Models;

namespace School.Core.Features.Students.Commands.Validatiors;
public class AddStudentValidator : AbstractValidator<AddStudentCommand>
{
    #region Fields
    #endregion

    #region Constructors
    public AddStudentValidator()
    {
        ApplyValidationRules();
    }
    #endregion

    #region Actions
    public void ApplyValidationRules()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(30);

        RuleFor(s => s.Address)
            .NotEmpty()
            .NotNull();

        RuleFor(s => s.DepartmentId)
            .NotEmpty()
            .NotNull();
    }
    public void ApplyCustomValidationRules()
    {

    }
    #endregion
}
