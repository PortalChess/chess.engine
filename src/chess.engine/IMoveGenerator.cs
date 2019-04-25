﻿using System.Collections.Generic;
using chess.engine.Pieces;

namespace chess.engine
{
    public interface IMoveGenerator
    {
        IEnumerable<Path> MovesFrom(BoardLocation location, Colours forPlayer);
        IEnumerable<Path> MovesFrom(string location, Colours forPlayer);
    }
}