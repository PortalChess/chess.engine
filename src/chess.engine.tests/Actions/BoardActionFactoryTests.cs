﻿using System;
using board.engine;
using board.engine.Actions;
using board.engine.Movement;
using chess.engine.Chess.Actions;
using chess.engine.Chess.Entities;
using Moq;
using NUnit.Framework;

namespace chess.engine.tests.Actions
{
    [TestFixture]
    public class BoardActionFactoryTests
    {
        private BoardActionProvider<ChessPieceEntity> _provider;

        [SetUp]
        public void SetUp()
        {
            _provider = new ChessBoardActionProvider(
                new Mock<IBoardEntityFactory<ChessPieceEntity>>().Object
                );
        }
        [Test]
        public void FactorySupportsDefaultActions()
        {
            foreach (var type in Enum.GetValues(typeof(DefaultActions)))
            {
                Assert.DoesNotThrow(() => _provider.Create((int) type, null), $"{type} is not support");
            }
        }
        [Test]
        public void FactorySupportsChessActions()
        {
            foreach (var type in Enum.GetValues(typeof(ChessMoveTypes)))
            {
                Assert.DoesNotThrow(() => _provider.Create((int)type, null), $"{type} is not support");
            }
        }
    }
}