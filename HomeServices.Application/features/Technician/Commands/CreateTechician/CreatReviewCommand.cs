using HomeServices.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Commands.CreateTechician
{
    public sealed record CreatReviewCommand(int Rating, string Comment, Guid TechId, Guid CustomerId) : IRequest<ReviewDto>;
    
}
