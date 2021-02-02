using MediatR;
using System.Collections.Generic;
using System.Text;

namespace Application.Positions.Commands
{
    public class AddPositionCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> FactorsListIds { get; set; }
    }
}
