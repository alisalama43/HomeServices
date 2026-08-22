using HomeServices.Application.features.Dtos;
using HomeServices.Domain.Entites.Technicians;

namespace HomeServices.Application.Features.Customers.Mappers;

public static class TechnicianMapper
{
    public static TechnicianDto ToDto(this Technician entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new TechnicianDto
        {
            Name = entity.Name!,
            Email = entity.Email!,
            Phone = entity.Phone!,
            reviews = entity.reviews
                .Select(v => v.ToDto())
                .ToList()
        };
    }

    public static List<TechnicianDto> ToDtos(this IEnumerable<Technician> entities)
    {
        return [.. entities.Select(e => e.ToDto())];
    }

    public static ReviewDto ToDto(this Review entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new ReviewDto(
            entity.Id,
            entity.Comment,
            entity.Rating,
            entity.TechnicianId,
            entity.CustomerId);
    }
}