using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Positions.Queries.Models
{
    public class PositionVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, List<int>> Factors { get; set; }
    }
}
