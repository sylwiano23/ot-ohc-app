using Application.Factors.Queries.Models;
using Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Factors.Queries.GetFactorsList
{
    public class GetFactorsListQueryHandler : IRequestHandler<GetFactorsListQuery, FactorsListVm>
    {
        private readonly IOhcDbContext _context;

        public GetFactorsListQueryHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<FactorsListVm> Handle(GetFactorsListQuery request, CancellationToken cancellationToken)
        {
            var factorsListDto = await _context.Factors
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
