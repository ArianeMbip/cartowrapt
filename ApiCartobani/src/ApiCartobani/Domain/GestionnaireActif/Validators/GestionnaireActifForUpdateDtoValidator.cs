namespace ApiCartobani.Domain.GestionnaireActif.Validators;

using ApiCartobani.Domain.GestionnaireActif.Dtos;
using FluentValidation;

public sealed class GestionnaireActifForUpdateDtoValidator: GestionnaireActifForManipulationDtoValidator<GestionnaireActifForUpdateDto>
{
    public GestionnaireActifForUpdateDtoValidator()
    {
        // add fluent validation rules that should only be run on update operations here
        //https://fluentvalidation.net/
    }
}