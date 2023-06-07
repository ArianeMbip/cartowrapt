namespace ApiCartobani.Domain.Users.Validators;

using ApiCartobani.Domain.Users.Dtos;
using FluentValidation;

public sealed class UserForUpdateDtoValidator: UserForManipulationDtoValidator<UserForUpdateDto>
{
    public UserForUpdateDtoValidator()
    {
        // add fluent validation rules that should only be run on update operations here
        //https://fluentvalidation.net/
    }
}