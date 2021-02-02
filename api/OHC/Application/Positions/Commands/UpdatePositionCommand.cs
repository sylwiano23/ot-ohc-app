using MediatR;
using System.Collections.Generic;

namespace Application.Positions.Commands
{
    public class UpdatePositionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> FactorsListIds { get; set; }
    }
}

