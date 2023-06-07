namespace ApiCartobani.Domain.Users.Validators;

using ApiCartobani.Domain.Users.Dtos;
using ApiCartobani.Domain;
using FluentValidation;

public class UserForManipulationDtoValidator<T> : AbstractValidator<T> where T : UserForManipulationDto
{
    public UserForManipulationDtoValidator()
    {
        RuleFor(u => u.Identifier)
            .NotEmpty()
            .WithMessage("Please provide an identifier.");
    }
}