using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Factors.Commands
{
    public class DeletePositionCommandHandler : IRequestHandler<DeleteFactorCommand>
    {
        private readonly IOhcDbContext _context;

        public DeletePositionCommandHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFactorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Factors
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Factor), request.Id);
            }

            _context.Factors.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
