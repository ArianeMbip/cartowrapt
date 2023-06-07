namespace ApiCartobani.Domain.Univers.Mappings;

using ApiCartobani.Domain.Univers.Dtos;
using ApiCartobani.Domain.Univers;
using Mapster;

public sealed class UniversMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Univers, UniversDto>();
        config.NewConfig<UniversForCreationDto, Univers>()
            .TwoWays();
        config.NewConfig<UniversForUpdateDto, Univers>()
            .TwoWays();
    }
}