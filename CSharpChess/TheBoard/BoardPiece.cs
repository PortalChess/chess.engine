﻿namespace CSharpChess.TheBoard
{
    public class BoardPiece
    {
        public int File { get; }
        public int Rank { get; }
        public ChessPiece Piece { get; }

        public BoardPiece(int file, int rank, ChessPiece chessPiece)
        {
            File = file;
            Rank = rank;
            Piece = chessPiece;
        }
    }
}