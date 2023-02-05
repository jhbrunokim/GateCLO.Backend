using FluentValidation;

namespace GateCLO.Application.Features.Employee.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
    }
}