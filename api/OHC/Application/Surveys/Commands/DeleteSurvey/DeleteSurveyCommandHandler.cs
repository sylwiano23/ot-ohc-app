using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities.Survey;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Surveys.Commands.DeleteSurvey
{
    public class DeleteSurveyCommandHandler : IRequestHandler<DeleteSurveyCommand>
    {
        private readonly IOhcDbContext _context;

        public DeleteSurveyCommandHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Surveys
                 .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Survey), request.Id);
            }

            _context.Surveys.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
