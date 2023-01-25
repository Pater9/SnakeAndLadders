namespace SnakeAndLadders.Library
{
    internal class DiceThrower : IDiceThrower
    {
        private readonly Random _random = new Random();

        private int Minimum = 1;
        private int Maximum = 6;

        public int Roll()
        {
            return _random.Next(Minimum, Maximum);
        }
    }
}
