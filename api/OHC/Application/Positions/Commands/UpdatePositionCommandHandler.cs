using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Positions.Commands
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, int>
    {
        private readonly IOhcDbContext _context;

        public UpdatePositionCommandHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Positions
                 .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Position), request.Id);
            }

            var factorsToRemove = _context.FactorPositions.Where(x => x.Position == entity).ToList();
            _context.FactorPositions.RemoveRange(factorsToRemove);

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


