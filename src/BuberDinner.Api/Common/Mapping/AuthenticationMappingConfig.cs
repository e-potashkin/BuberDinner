using BuberDinner.Application.UseCases.Authentication.Commands.Register;
using BuberDinner.Application.UseCases.Authentication.Common;
using BuberDinner.Application.UseCases.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // src => target
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
