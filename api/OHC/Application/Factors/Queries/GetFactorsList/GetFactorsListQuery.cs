using Application.Factors.Queries.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Factors.Queries.GetFactorsList
{
    public class GetFactorsListQuery : IRequest<FactorsListVm>
    {
    }
}
