﻿namespace chess.engine.Board
{
    public interface IBoardEngineProvider<TEntity> where TEntity : class, IBoardEntity
    {
        BoardEngine<TEntity> Provide(IGameSetup<TEntity> gameSetup);
    }
}