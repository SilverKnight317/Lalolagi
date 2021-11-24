using System.Collections.Generic;
using Lalolagi.Casting;

namespace Lalolagi.Scripting
{
    public class UpdateScore : Action
    {
        ScoreBoard _scoreBoard = new ScoreBoard();

        public UpdateScore(ScoreBoard scoreBoard)
        {
            _scoreBoard = scoreBoard;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            // throw new System.NotImplementedException();
            _scoreBoard.AddScoreBoardPoint();
        }
    }
}