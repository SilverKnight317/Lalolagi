using System.Collections.Generic;
using Lalolagi.Casting;
using Lalolagi.Services;


namespace Lalolagi.Scripting
{
    /// <summary>
    /// An action to get user input and update actors accordingly.
    /// </summary>
    public class ControlActorsAction : Action
    {
        InputService _inputService;

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            
            Actor player = cast["player"][0];

            Point velocity = direction.Scale(5);
            player.SetVelocity(velocity);
        }
        
    }
}