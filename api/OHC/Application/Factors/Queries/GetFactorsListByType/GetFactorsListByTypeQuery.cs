using Application.Factors.Queries.Models;
using Domain.Enums;
using MediatR;

namespace Application.Factors.Queries.GetFactorsListByType
{
    public class GetFactorsListByTypeQuery : IRequest<FactorsListVm>
    {        
        public FactorTypeEnum FactorType { get; set; }
    }
}
