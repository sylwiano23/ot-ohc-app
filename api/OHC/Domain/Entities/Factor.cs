using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Factor
    {
        protected Factor()
        {
            FactorPositions = new HashSet<FactorPosition>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public FactorTypeEnum FactorType { get; private set; }

        public ICollection<FactorPosition> FactorPositions { get; private set; }

        public static Factor CreateNew(string name, FactorTypeEnum factorType)
        {
            Factor factor = new Factor()
            {
                Name = name,
                FactorType = factorType
            };

            return factor;
        }

        public void ChangeDetails(string name, FactorTypeEnum factorType)
        {
            Name = name;
            FactorType = factorType;
        }
    }
}
