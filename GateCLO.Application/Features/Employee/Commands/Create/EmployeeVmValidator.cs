using FluentValidation;

public class EmployeeVmValidator : AbstractValidator<EmployeeVm>
{
    public EmployeeVmValidator()
    {
        RuleFor(s => s.Name).NotEmpty();
        RuleFor(s => s.Email).NotEmpty().EmailAddress();
        RuleFor(s => s.Joined).NotEmpty();
        RuleFor(s => s.Tel).NotEmpty();
    }
}