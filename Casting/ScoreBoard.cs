using System.Collections.Generic;
using Lalolagi.Casting;
using Lalolagi.Services;

namespace Lalolagi.Casting
{
    public class ScoreBoard : Actor
    {
        private int _BillboardWidth = 150;
        private int _BillboardHeight = 30;
        private int scoreBoardPoint;
        private string _BoardMessage;
        public ScoreBoard()
        {
            SetHeight(_BillboardHeight);
            SetWidth(_BillboardWidth);
            UpdateBoard();
        }
        public void AddScoreBoardPoint()
        {
            scoreBoardPoint += 1;
        }
        public void UpdateBoard()
        {
            _BoardMessage = $"Score: {scoreBoardPoint}";
            SetText(_BoardMessage);
        }
    }
}