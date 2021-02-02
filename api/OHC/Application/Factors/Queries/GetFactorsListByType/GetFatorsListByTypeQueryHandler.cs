using Application.Factors.Queries.Models;
using Common.Interfaces;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Factors.Queries.GetFactorsListByType
{
    public class GetFatorsListByTypeQueryHandler : IRequestHandler<GetFactorsListByTypeQuery, FactorsListVm>
    {
        private readonly IOhcDbContext _context;

        public GetFatorsListByTypeQueryHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<FactorsListVm> Handle(GetFactorsListByTypeQuery request, CancellationToken cancellationToken)
        {
            var factorsListDto = await _context.Factors
                .Where(p => p.FactorType == request.FactorType)
                .Select(p => new FactorDto { Id = p.Id, Name = p.Name, FactorType = p.FactorType.ToString() })
                .ToListAsync(cancellationToken);

            var vm = new FactorsListVm
            {
                Factors = factorsListDto
            };

            return vm;
        }
    }
}
