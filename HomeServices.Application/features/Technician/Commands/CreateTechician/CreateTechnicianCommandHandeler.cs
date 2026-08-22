using HomeServices.Application.Common.Abstract;

using HomeServices.Domain.Entites.Technicians;
using HomeServices.Domain.Common.Results;
using MediatR;
using TechnicianEntity = HomeServices.Domain.Entites.Technicians.Technician;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using HomeServices.Application.Features.Customers.Mappers;
using HomeServices.Application.features.Dtos;

namespace HomeServices.Application.features.Technician.Commands.CreateTechician
{
    public class CreateTechnicianCommandHandeler(
        ILogger<CreateTechnicianCommandHandeler> logger,
        IAppDbContext context,
        HybridCache cache)
        : IRequestHandler<CreateTechnicianCommand, Result<TechnicianDto>>
    {
        public async Task<Result<TechnicianDto>> Handle(
            CreateTechnicianCommand command,
            CancellationToken ct)
        {
            var email = command.Email.Trim().ToLower();

            bool existed = await context.TechnicianProfiles
                .AnyAsync(c => c.Email!.ToLower() == email, ct);

            if (existed)
            {
                logger.LogWarning("Email already exists.");
                return TechnicianError.ExistedEmail;
            }

            List<Review> reviews = [];

            foreach (var review in command.Reviews)
            {
                var reviewResult = Review.create(
                    Guid.NewGuid(),
                    review.Comment,
                    review.Rating,
                    review.TechId,
                    review.CustomerId);

                if (reviewResult.IsError)
                {
                    return reviewResult.Errors;
                }

                reviews.Add(reviewResult.Value);
            }

            var createTechnicianResult = TechnicianEntity.Create(
                Guid.NewGuid(),
                command.name,
                command.bio,
                command.Email,
                command.phone,
                 reviews);

            if (createTechnicianResult.IsError)
            {
                return createTechnicianResult.Errors;
            }

            context.TechnicianProfiles.Add(createTechnicianResult.Value);

            await context.SaveChangesAsync(ct);

            await cache.RemoveByTagAsync("technician", ct);

            var technician = createTechnicianResult.Value;

            logger.LogInformation(
                "Technician created successfully. Id: {TechnicianId}",
                technician.Id);

            return technician.ToDto();
        }
    }
}