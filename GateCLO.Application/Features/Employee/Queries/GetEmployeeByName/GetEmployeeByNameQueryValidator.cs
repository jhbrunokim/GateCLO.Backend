using FluentValidation;

namespace GateCLO.Application.Features.Employee.Queries.GetEmployeeByName;

public class GetEmployeeByNameQueryValidator: AbstractValidator<GetEmployeeByNameQuery>
{
    public GetEmployeeByNameQueryValidator()
    {
        RuleFor(s => s.Name).NotEmpty().WithMessage("The Name field is required.");
    }
}