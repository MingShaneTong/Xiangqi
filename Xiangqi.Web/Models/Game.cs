﻿using Xiangqi.Game;
using Xiangqi.Web.Hubs;

namespace Xiangqi.Web.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public ChessGame ChessGame { get; set; }
        public bool HasStarted { get; set; }

        public string RedPlayerConnection { get; set; }
        public bool RedAck { get; set; }
        public string BlackPlayerConnection { get; set; }
        public bool BlackAck { get; set; }

        public Game()
        { 
            GameId = System.Guid.NewGuid();
            ChessGame = new ChessGame();
        }

        public void Start()
        { 

        }
    }
}
