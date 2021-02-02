using Application.Positions.Queries.Models;
using Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Positions.Queries.GetPositionsList
{
    public class GetPositionListQueryHandler : IRequestHandler<GetPositionsListQuery, PositionsListVm>
    {
        private readonly IOhcDbContext _context;

        public GetPositionListQueryHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<PositionsListVm> Handle(GetPositionsListQuery request, CancellationToken cancellationToken)
        {
            var positionsDto = await _context.Positions
                .Select(p => new PositionDto { Id = p.Id, Name = p.Name })
                .ToListAsync(cancellationToken);

            var vm = new PositionsListVm
            {
                Positions = positionsDto,
            };

            return vm;
        }
    }
}
