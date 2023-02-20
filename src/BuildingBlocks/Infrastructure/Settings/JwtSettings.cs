using System.ComponentModel.DataAnnotations;

namespace BuildingBlocks.Infrastructure.Settings;

public class JwtSettings
{
    [Required]
    public string Secret { get; init; }

    [Range(0, int.MaxValue)]
    public int ExpireMinutes { get; init; }

    public string Issuer { get; init; }

    public string Audience { get; init; }
}
