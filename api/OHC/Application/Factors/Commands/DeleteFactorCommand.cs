using MediatR;

namespace Application.Factors.Commands
{
    public class DeleteFactorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
