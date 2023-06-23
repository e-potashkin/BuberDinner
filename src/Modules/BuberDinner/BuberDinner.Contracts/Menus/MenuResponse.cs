using System.Collections.ObjectModel;

namespace BuberDinner.Contracts.Menus;

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    float? AverageRating,
    string HostId,
    ReadOnlyCollection<string> DinnerIds,
    ReadOnlyCollection<string> MenuReviewIds,
    ReadOnlyCollection<MenuSectionResponse> Sections,
    DateTime CreatedDateTimeUtc,
    DateTime UpdatedDateTimeUtc);
