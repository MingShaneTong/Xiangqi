namespace Xiangqi.Web.Models.Messages
{
    public class MoveMessage
    {
        public record Position(int Row, int Col);

        public string GameId;
        public Position OldPosition;
        public Position NewPosition;
    }
}
