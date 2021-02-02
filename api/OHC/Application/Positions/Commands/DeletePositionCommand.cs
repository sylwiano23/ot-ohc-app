using MediatR;
using System;
using System.Text;

namespace Application.Positions.Commands
{
    public class DeletePositionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
