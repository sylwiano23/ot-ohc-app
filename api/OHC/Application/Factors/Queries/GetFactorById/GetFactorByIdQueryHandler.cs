using Application.Factors.Queries.Models;
using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Factors.Queries.GetFactorById
{
    public class GetFactorByIdQueryHandler : IRequestHandler<GetFactorByIdQuery, FactorDto>
    {
        private readonly IOhcDbContext _context;

        public GetFactorByIdQueryHandler(IOhcDbContext context)
        {
            _context = context;
        }
        public async Task<FactorDto> Handle(GetFactorByIdQuery request, CancellationToken cancellationToken)
        {
            var factor = await _context.Factors      
              .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (factor == null)
            {
                throw new NotFoundException(nameof(Factor), request.Id);
            }

            var factorDto = new FactorDto
            {
                FactorType = factor.FactorType.ToString(),
                Id = factor.Id,
                Name = factor.Name
            };

            return factorDto;
        }
    }
}
