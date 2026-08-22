using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.ServiceRequest.Dtos;
using HomeServices.Application.features.ServiceRequests.Mappers;
using HomeServices.Domain.Common.Results;
using HomeServices.Domain.Entites.Customer;
using HomeServices.Domain.Entites.Service;
using HomeServices.Domain.Entites.Technicians;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceR = HomeServices.Domain.Entites.Service.ServiceRequest;

namespace HomeServices.Application.features.ServiceRequests.Command.CreateServiceRequest
{
    public sealed class CreateServicerequestCommandHandler(
        IAppDbContext context)
        : IRequestHandler<CreateServiceRequestCommand, Result<ServiceRequestDto>>
    {
        public async Task<Result<ServiceRequestDto>> Handle(
            CreateServiceRequestCommand request,
            CancellationToken cancellationToken)
        {
            
            var customer = await context.customers
                .FirstOrDefaultAsync(
                    e => e.Id == request.CustomerId,
                    cancellationToken);

            if (customer is null)
                return CustomerError.NotFound;

            
            if (!customer.IsActive)
                return CustomerError.RequiredActiveStatus;

            
            var service = await context.Services
                .FindAsync(
                    new object[] { request.ServiceId },
                    cancellationToken);

            if (service is null)
                return ServiceError.NotFound;

            
            var professionIds = request.RequiredProfessionIds
                .Distinct()
                .ToList();

            var professions = await context.Professions
                .Where(p => professionIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

           
            if (professions.Count != professionIds.Count)
                return TechnicianError.NotFound;

           
            
            var address = request.Aaddress;

            
            var serviceRequest = new ServiceR(
                Guid.NewGuid(),
                customer.Id,
                service.Id,
                request.Description,
                address,
                request.PreferredDateTime,
                professionIds);

            
            foreach (var imageReference in request.ImageReferences)
            {
                serviceRequest.AddImage(imageReference);
            }

            
            var submitResult = serviceRequest.Submit();

           

            
            await context.ServiceRequests.AddAsync(
                serviceRequest,
                cancellationToken);

           
            await context.SaveChangesAsync(cancellationToken);

           
            return serviceRequest.ToDto();
        }
    }
}