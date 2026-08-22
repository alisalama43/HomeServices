using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Profession.Dto;
using HomeServices.Application.features.Profession.Mappers;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Profession.Query
{
    internal class GetProfessionByIdQueryhandler(IAppDbContext appDbContext) : IRequestHandler<GetProfessionByIdQuery, Result<ProfessionDto>>
    {
        public async Task<Result<ProfessionDto>> Handle(GetProfessionByIdQuery request, CancellationToken cancellationToken)
        {
            var profession = appDbContext.Professions.FirstOrDefault(e => e.Id == request.id);
            return profession!.ToDto(); 
        }
    }
}
