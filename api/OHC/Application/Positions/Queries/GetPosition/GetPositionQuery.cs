using Application.Positions.Queries.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Positions.Queries.GetPosition
{
    public class GetPositionQuery : IRequest<PositionVm>
    {
        public int Id { get; set; }
    }
}
