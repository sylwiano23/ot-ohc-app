namespace Domain.Entities
{
    public class FactorPosition
    {
        protected FactorPosition()
        {

        }

        public int FactorId { get; private set; }
        public Factor Factor { get; private set; }
        public int PositionId { get; private set; }
        public Position Position { get; private set; }

        public static FactorPosition CreateNew(Position position, Factor factor)
        {
            var factorPosition = new FactorPosition()
            {
                Factor = factor,
                Position = position,
                FactorId = factor.Id,
                PositionId = position.Id
            };

            return factorPosition;
        }
    }
}
