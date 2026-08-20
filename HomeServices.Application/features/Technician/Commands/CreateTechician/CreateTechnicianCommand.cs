using HomeServices.Application.Common.Dtos;
using MediatR;
using MechanicShop.Domain.Common.Results;
using HomeServices.Domain.Entites.Technicians;


namespace HomeServices.Application.features.Technician.Commands.CreateTechician
{
    public sealed record CreateTechnicianCommand(
        
        string name,
        string bio,
        string Email,
        string phone,
        List<CreatReviewCommand> Reviews
     ) : IRequest<Result<TechnicianDto>>;
 
}
