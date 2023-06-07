namespace ApiCartobani.Domain.Users.Mappings;

using ApiCartobani.Domain.Users.Dtos;
using ApiCartobani.Domain.Users;
using Mapster;

public sealed class UserMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>()
            .Map(x => x.Email, y => y.Email.Value);
        config.NewConfig<UserForCreationDto, User>()
            .TwoWays();
        config.NewConfig<UserForUpdateDto, User>()
            .TwoWays();
    }
}