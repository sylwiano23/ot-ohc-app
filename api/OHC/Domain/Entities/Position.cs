using System.Collections.Generic;

namespace Domain.Entities
{
    public class Position
    {
        protected Position()
        {
            FactorPositions = new HashSet<FactorPosition>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<FactorPosition> FactorPositions { get; private set; }

        public static Position CreateNew()
        {
            Position position = new Position
            {
            };

            return position;
        }

        public void ChangeDetails(string name, string description, ICollection<FactorPosition> factorPositions)
        {
            Name = name;
            Description = description;
            FactorPositions = factorPositions;
        }
    }
}
