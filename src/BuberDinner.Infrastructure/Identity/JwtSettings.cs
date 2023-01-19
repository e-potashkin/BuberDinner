using System.ComponentModel.DataAnnotations;

namespace BuberDinner.Infrastructure.Identity;

public class JwtSettings
{
    [Required]
    public string Secret { get; init; } = null!;

    public int ExpireMinutes { get; init; }

    public string Issuer { get; init; } = null!;

    public string Audience { get; init; } = null!;
}
