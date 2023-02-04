namespace Xiangqi.Game
{
    public record File (Color Color, int FileCol)
    {
        public int ToColumn()
        { 
            if (Color == Color.Black) { return FileCol - 1; }
            return Board.Cols - FileCol;
        }
    }
}
