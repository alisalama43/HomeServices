
using MediatR;
using HomeServices.Domain.Common.Results;
using HomeServices.Domain.Entites.Technicians;
using HomeServices.Application.features.Dtos;


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
