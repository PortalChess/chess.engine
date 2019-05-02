﻿using chess.engine.Actions;
using chess.engine.Entities;
using chess.engine.Game;
using Moq;
using NUnit.Framework;

namespace chess.engine.tests.Actions
{
    [TestFixture]
    public class MoveOnlyActionTests : ActionTestsBase<MoveOnlyAction>
    {
        [SetUp]
        public void Setup()
        {
            base.SetUp();
            Action = new MoveOnlyAction(StateMock.Object, FactoryMock.Object);
        }

        [Test]
        public void Execute_clears_from_location_and_replaces_to()
        {
            var piece = new PawnEntity(Colours.White);
            SetupPieceReturn(AnyMove.From, piece);

            Action.Execute(AnyMove);

            VerifyEntityWasRetrieved(AnyMove.From);
            VerifyLocationWasCleared(AnyMove.From);
            VerifyWasEntityPlaced(AnyMove.To, piece);
        }
        
    }
}