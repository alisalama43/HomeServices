using HomeServices.Application.features.Profession.Dto;
using ProfessionEntity = HomeServices.Domain.Entites.Professions.Profession;
namespace HomeServices.Application.features.Profession.Mappers;

public static class ProfessionMapper
{
    public static ProfessionDto ToDto(this ProfessionEntity entity)
    {
        return new ProfessionDto
        {
            Name = entity.Name
        };
    }
}