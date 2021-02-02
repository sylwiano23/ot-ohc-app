using Application.Positions.Queries.Models;
using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Positions.Queries.GetPosition
{
    public class GetPositionQueryHandler : IRequestHandler<GetPositionQuery, PositionVm>
    {
        private readonly IOhcDbContext _context;

        public GetPositionQueryHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<PositionVm> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            var position = await _context.Positions
                .Include(p => p.FactorPositions)
                .ThenInclude(fp => fp.Factor)
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            
            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.Id);
            }

            var factors = position.FactorPositions
                .Select(pf => pf.Factor)
                .ToList();

            var groupedFactors = factors
                .GroupBy(f => f.FactorType)
                .ToDictionary(gf => gf.Key.ToString(), gf => gf.Select(x => x.Id)
                .ToList());

            foreach (FactorTypeEnum factorType in Enum.GetValues(typeof(FactorTypeEnum)))
            {
                if (!groupedFactors.ContainsKey(factorType.ToString()))
                {
                    groupedFactors.Add(factorType.ToString(), new List<int>());
                }                
            }

            var vm = new PositionVm
            {
                Id = position.Id,
                Name = position.Name,
                Factors = groupedFactors,
                Description = position.Description
            };

            return vm;
        }
    }
}
