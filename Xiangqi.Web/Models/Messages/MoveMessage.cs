namespace Xiangqi.Web.Models.Messages
{
    public class MoveMessage
    {
        public class Position
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }

        public string GameId;
        public Position OldPosition;
        public Position NewPosition;
    }
}
