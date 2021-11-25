
using System.Collections.Generic;
using Lalolagi.Casting;
using Lalolagi.Services;

namespace Lalolagi
{
    public class HandleOffScreenActions : Action
    {
        AudioService _audioService;
        public HandleOffScreenActions(AudioService audioService)
        {
            _audioService = audioService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            // throw new System.NotImplementedException();
            List<Actor> balls = cast["balls"];
            foreach(Actor ball in balls)
            {
                if (ball.GetRightEdge() >= Constants.MAX_X || ball.GetLeftEdge() <= 0)
                {
                    ball.ChangeVelocityX();
                    // _audioService.PlaySound(Constants.SOUND_BOUNCE);
                }
                if (ball.GetBottomEdge() >= Constants.MAX_Y || ball.GetTopEdge() <= 0)
                {
                    ball.ChangeVelocityY();
                    // _audioService.PlaySound(Constants.SOUND_BOUNCE);
                }
            }
        }
    }
}