﻿using System.Linq;
using board.engine;
using board.engine.Board;
using chess.engine;
using chess.engine.Chess;
using chess.engine.Chess.Entities;
using chess.engine.Extensions;
using chess.engine.Game;
using Microsoft.Extensions.Logging;

namespace chess.webapi.Services
{
    public class ChessGameService : IChessService
    {
        private readonly ILogger<ChessGameService> _logger;
        private readonly ILogger<ChessGame> _chessGameLogger;
        private readonly IBoardEngineProvider<ChessPieceEntity> _boardEngineProvider;
        private readonly IBoardEntityFactory<ChessPieceEntity> _entityFactory;
        private readonly IChessGameStateService _chessGameStateService;

        public ChessGameService(
            ILogger<ChessGameService> logger,
            ILogger<ChessGame> chessGameLogger, 
            IChessGameStateService chessGameStateService, 
            IBoardEngineProvider<ChessPieceEntity> boardEngineProvider,
            IBoardEntityFactory<ChessPieceEntity> entityFactory
            )
        {
            _chessGameStateService = chessGameStateService;
            _entityFactory = entityFactory;
            _chessGameLogger = chessGameLogger;
            _boardEngineProvider = boardEngineProvider;
            _logger = logger;
        }

        public ChessGameResult GetNewBoard()
        {
            var game = new ChessGame(
                _chessGameLogger,
                _boardEngineProvider,
                _entityFactory,
                _chessGameStateService
            );
            var result = new ChessGameResult(game, game.BoardState.GetAllItems().ToArray());
            return result;
        }

        public ChessGameResult PlayMove(string board, string move)
        {
            var game= CreateChessGame(board);
            var msg = game.Move(move);
            return new ChessGameResult(game, msg);
        }

        public ChessGameResult GetMoves(string board)
        {
            var game = CreateChessGame(board);
            var items = game.BoardState.GetAllItems();
            return new ChessGameResult(game, items.ToArray());
        }

        public ChessGameResult GetMovesForPlayer(string board, Colours forPlayer)
        {
            var game = CreateChessGame(board);
            var items = game.BoardState.GetItems((int) forPlayer);
            return new ChessGameResult(game, items.ToArray());
        }

        public ChessGameResult GetMovesForLocation(string board, string location)
        {
            var game = CreateChessGame(board);
            var loc = location.ToBoardLocation();
            var item = game.BoardState.GetItem(loc);
            return new ChessGameResult(game, item);
        }


        private static ChessGame CreateChessGame(string board)
            => ChessGameConvert.Deserialise(board);
    }
}