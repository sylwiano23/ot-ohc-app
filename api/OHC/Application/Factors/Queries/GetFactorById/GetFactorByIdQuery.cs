using Application.Factors.Queries.Models;
using MediatR;

namespace Application.Factors.Queries.GetFactorById
{
    public class GetFactorByIdQuery : IRequest<FactorDto>
    {
        public int Id { get; set; }
    }
}
