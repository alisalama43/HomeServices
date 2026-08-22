using HomeServices.Application.features.ServiceRequest.Dtos;
using HomeServices.Domain.Common.Results;
using HomeServices.Domain.Entites.Request;
using HomeServices.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequests.Command.CreateServiceRequest
{
    public sealed record CreateServiceRequestCommand(
      Guid CustomerId,
    Guid ServiceId,
    string Description,
    string Aaddress,
    DateTime PreferredDateTime,
    IReadOnlyCollection<Guid> RequiredProfessionIds,
    IReadOnlyCollection<string> ImageReferences) : IRequest<Result<ServiceRequestDto>>;
    //private readonly List<RequestProfession> _requiredProfessions = new();
    //private readonly List<RequestImage> _images = new();

    //public Guid CustomerId { get; private set; }
    //public Guid ServiceId { get; private set; }
    //public string Description { get; private set; } = string.Empty;
    //public string Address { get; private set; } = null!;
    //public DateTime PreferredDateTime { get; private set; }
    //public ServiceRequestStatus Status { get; private set; }
    //public Guid? AcceptedOfferId { get; private set; }

}
