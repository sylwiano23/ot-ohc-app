using Common.Exceptions;
using Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Factors.Commands
{
    public class AddFactorCommandHandler : IRequestHandler<AddFactorCommand, int>
    {
        private readonly IOhcDbContext _context;

        public AddFactorCommandHandler(IOhcDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddFactorCommand request, CancellationToken cancellationToken)
        {
            var factorType = (FactorTypeEnum)Enum.Parse(typeof(FactorTypeEnum), request.FactorType);
           
            Factor entity = Factor.CreateNew(request.Name, factorType);
            _context.Factors.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
