using MediatR;

namespace Application.Factors.Commands
{
    public class UpdateFactorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FactorType { get; set; }
    }
}
