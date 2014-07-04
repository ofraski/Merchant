namespace Merchant
{
    public struct GalaxyValue
    {
        private readonly decimal _units;

        public GalaxyValue(decimal units)
        {
            _units = units;
        }

        public decimal Units
        {
            get { return _units; }
        }

        public static GalaxyValue None
        {
            get { return new GalaxyValue(0); }
        }
    }
}