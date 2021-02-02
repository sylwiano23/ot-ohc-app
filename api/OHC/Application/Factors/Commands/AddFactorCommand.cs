using MediatR;

namespace Application.Factors.Commands
{
    public class AddFactorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FactorType { get; set; }
    }
}
