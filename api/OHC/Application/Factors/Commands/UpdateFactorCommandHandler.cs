using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Factors.Commands
{
    public class UpdateFactorCommandHandler : IRequestHandler<UpdateFactorCommand, int>
    {
        private readonly IOhcDbContext _context;

        public UpdateFactorCommandHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateFactorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Factors
                 .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Factor), request.Id);
            }

            var factorType = (FactorTypeEnum)Enum.Parse(typeof(FactorTypeEnum), request.FactorType);
            
            entity.ChangeDetails(request.Name, factorType);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
