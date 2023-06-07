namespace ApiCartobani.Domain.GestionnaireActif.Mappings;

using ApiCartobani.Domain.GestionnaireActif.Dtos;
using ApiCartobani.Domain.GestionnaireActif;
using Mapster;

public sealed class GestionnaireActifMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GestionnaireActif, GestionnaireActifDto>();
        config.NewConfig<GestionnaireActifForCreationDto, GestionnaireActif>()
            .TwoWays();
        config.NewConfig<GestionnaireActifForUpdateDto, GestionnaireActif>()
            .TwoWays();
    }
}