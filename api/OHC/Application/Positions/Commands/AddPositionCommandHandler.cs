using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Positions.Commands
{
    public class AddPositionCommandHandler : IRequestHandler<AddPositionCommand, int>
    {
        private readonly IOhcDbContext _context;

        public AddPositionCommandHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddPositionCommand request, CancellationToken cancellationToken)
        {
            Position entity = Position.CreateNew();
            _context.Positions.Add(entity);

            var factorsToInclude = _context.Factors.Where(f => request.FactorsListIds.Contains(f.Id)).ToList();          

            List<FactorPosition> factorPositionsList = new List<FactorPosition>();
            foreach (var factor in factorsToInclude)
            {
                factorPositionsList.Add(FactorPosition.CreateNew(entity, factor));
            }

            entity.ChangeDetails(request.Name, request.Description, factorPositionsList);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

