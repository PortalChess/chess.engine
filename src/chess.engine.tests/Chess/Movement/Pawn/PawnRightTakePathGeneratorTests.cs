using System.Linq;
using board.engine.Actions;
using chess.engine.Chess;
using chess.engine.Chess.Movement.ChessPieces.Pawn;
using chess.engine.Extensions;
using chess.engine.Game;
using chess.engine.tests.Builders;
using chess.engine.tests.Movement;
using NUnit.Framework;

namespace chess.engine.tests.Chess.Movement.Pawn
{
    [TestFixture]
    public class PawnRightTakePathGeneratorTests : PathGeneratorTestsBase
    {
        private PawnRightTakePathGenerator _gen;

        [SetUp]
        public new void SetUp()
        {
            _gen = new PawnRightTakePathGenerator();
        }
        [Test]
        public void PathsFrom_returns_empty_list_when_on_right_edge()
        {

            Assert.That(_gen.PathsFrom("H2".ToBoardLocation(), (int)Colours.White).Count(), Is.EqualTo(0));
            Assert.That(_gen.PathsFrom("A7".ToBoardLocation(), (int)Colours.Black).Count(), Is.EqualTo(0));
        }

        [Test]
        public void PathsFrom_returns_return_take()
        {
            var pieceLocation = "B2".ToBoardLocation();
            var paths = _gen.PathsFrom(pieceLocation, (int)Colours.White).ToList();

            var ep = new PathBuilder().From(pieceLocation)
                .To("C3", (int)DefaultActions.TakeOnly)
                .Build();

            AssertPathContains(paths, ep, Colours.White);
            Assert.That(paths.Count(), Is.EqualTo(1));
        }


        [Test]
        public void PathsFrom_returns_pawn_promotions()
        {
            var startLocation = "B7".ToBoardLocation();
            var whitePaths = _gen.PathsFrom(startLocation, (int)Colours.White).ToList();
            Assert.That(whitePaths.Count(), Is.EqualTo(4));

            AssertPathContains(whitePaths, new PathBuilder().From(startLocation)
                .ToUpdatePiece("C8", ChessPieceName.Queen)
                .Build(), Colours.White);
            AssertPathContains(whitePaths, new PathBuilder().From(startLocation)
                .ToUpdatePiece("C8", ChessPieceName.Rook)
                .Build(), Colours.White);
            AssertPathContains(whitePaths, new PathBuilder().From(startLocation)
                .ToUpdatePiece("C8", ChessPieceName.Bishop)
                .Build(), Colours.White);
            AssertPathContains(whitePaths, new PathBuilder().From(startLocation)
                .ToUpdatePiece("C8", ChessPieceName.Knight)
                .Build(), Colours.White);
        }
    }
}