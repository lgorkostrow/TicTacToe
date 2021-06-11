namespace TicTacToe
{
    public class Player
    {
        public string Name { get; }
        public MarkerEnum Marker { get; }

        public Player(string name, MarkerEnum marker)
        {
            Name = name;
            Marker = marker;
        }
    }
}