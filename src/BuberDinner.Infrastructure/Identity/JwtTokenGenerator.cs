using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.Aggregates.User;
using BuberDinner.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Identity;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptionsMonitor<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.CurrentValue;
        jwtSettings.OnChange(settings => _jwtSettings = settings);
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString() ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims: claims,
            expires: _dateTimeProvider.Now.AddMinutes(_jwtSettings.ExpireMinutes),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
