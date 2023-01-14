﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game
{
    public class Board
    {
        public const int Rows = 10;
        public const int Cols = 9;
        public const int BlackRiver = 4;
        public const int RedRiver = 5;

        public IPiece[,] Pieces { get; init; }

        public IPiece GetPieceOn(Position position)
        {
            if (!position.IsValid()) { return null; }
            return Pieces[position.Row, position.Col];
        }

        public void SetPieceOn(Position position, IPiece piece)
        {
            Pieces[position.Row, position.Col] = piece;
        }

        public static Color GetPositionSide(Position position)
        {
            if (position.Row >= RedRiver) 
            { 
                return Color.Red; 
            }
            return Color.Black;
        }

        public IList<IPiece> GetHorizontalPiecesBetween(Position p1, Position p2)
        {
            if (p1.Row != p2.Row) { throw new Exception("Positions are not on the same row"); }
            int row = p1.Row;
            IList<IPiece> piecesBetween = new List<IPiece>();
            if (p1.Col > p2.Col) { (p1, p2) = (p2, p1); }
            for (int col = p1.Col + 1; col < p2.Col; col++)
            {
                IPiece piece = Pieces[row, col];
                if (piece == null) { continue; }
                piecesBetween.Add(piece);
            }
            return piecesBetween;
        }

        public IList<IPiece> GetVerticalPiecesBetween(Position p1, Position p2)
        {
            if (p1.Col != p2.Col) { throw new Exception("Positions are not on the same column"); }
            int col = p1.Col;
            IList<IPiece> piecesBetween = new List<IPiece>();
            if (p1.Row > p2.Row) { (p1, p2) = (p2, p1); }
            for (int row = p1.Row + 1; row < p2.Row; row++)
            {
                IPiece piece = Pieces[row, col];
                if (piece == null) { continue; }
                piecesBetween.Add(piece);
            }
            return piecesBetween;
        }

        public override string ToString()
        {
            string[] rowString = new string[Rows];
            for (int i = 0; i < Rows; i++)
            {
                string[] colString = new string[Cols];
                for (int j = 0; j < Cols; j++)
                {
                    IPiece p = Pieces[i,j];
                    colString[j] = p != null ? p.ToString() : "。";
                }
                rowString[i] = string.Join("|", colString);
            }
            return string.Join("\n", rowString);
        }
    }
}
