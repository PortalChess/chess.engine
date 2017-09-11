﻿using System.Collections.Generic;
using System.Linq;

namespace CSharpChess.Extensions
{
    public static class BoardPieceExtensions
    {
        public static IEnumerable<BoardPiece> OfColour(this IEnumerable<BoardPiece> pieces, Colours colour) 
            => pieces.Where(p => p.Piece.Is(colour));
    }
}