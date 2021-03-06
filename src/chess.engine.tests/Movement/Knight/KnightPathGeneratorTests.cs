using System.Linq;
using board.engine.Actions;
using chess.engine.Extensions;
using chess.engine.Game;
using chess.engine.Movement.Knight;
using chess.engine.tests.Builders;
using NUnit.Framework;
using Shouldly;

namespace chess.engine.tests.Movement.Knight
{
    [TestFixture]
    public class KnightPathGeneratorTests : ChessPathGeneratorTestsBase
    {
        private KnightPathGenerator _gen;

        [SetUp]
        public new void SetUp()
        {
            _gen = new KnightPathGenerator();
        }

        [Test]
        public void PathsFrom_generates_all_directions()
        {
            var boardLocation = "E4".ToBoardLocation();
            var whitePaths = _gen.PathsFrom(boardLocation, (int) Colours.White).ToList();

            whitePaths.Count().ShouldBe(8);

            PathsShouldContain(whitePaths,
                new ChessPathBuilder().From("E4").To("F6", (int) DefaultActions.MoveOrTake).Build(), Colours.White);
            PathsShouldContain(whitePaths,
                new ChessPathBuilder().From("E4").To("D6", (int) DefaultActions.MoveOrTake).Build(), Colours.White);
            PathsShouldContain(whitePaths,
                new ChessPathBuilder().From("E4").To("F2", (int) DefaultActions.MoveOrTake).Build(), Colours.White);
            PathsShouldContain(whitePaths,
                new ChessPathBuilder().From("E4").To("D2", (int) DefaultActions.MoveOrTake).Build(), Colours.White);
            PathsShouldContain(whitePaths,
                new ChessPathBuilder().From("E4").To("G5", (int) DefaultActions.MoveOrTake).Build(), Colours.White);
            PathsShouldContain(whitePaths,
                new ChessPathBuilder().From("E4").To("G3", (int) DefaultActions.MoveOrTake).Build(), Colours.White);
            PathsShouldContain(whitePaths,
                new ChessPathBuilder().From("E4").To("C5", (int) DefaultActions.MoveOrTake).Build(), Colours.White);
            PathsShouldContain(whitePaths,
                new ChessPathBuilder().From("E4").To("C3", (int) DefaultActions.MoveOrTake).Build(), Colours.White);
        }
    }

}