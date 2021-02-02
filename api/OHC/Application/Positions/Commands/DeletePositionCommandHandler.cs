using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Positions.Commands
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand>
    {
        private readonly IOhcDbContext _context;

        public DeletePositionCommandHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Positions
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Position), request.Id);
            }

            _context.Positions.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
