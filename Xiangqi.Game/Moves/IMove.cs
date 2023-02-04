namespace Xiangqi.Game.Moves
{
    public interface IMove
    {
        public bool IsValid(Board board);
        public void Apply(Board board, bool validation = true);
    }
}
