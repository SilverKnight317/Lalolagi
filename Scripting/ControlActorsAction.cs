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
            int t_c = 0;
            foreach(Actor actor in cast["tiles"])
            {
                
                Actor tile = cast["tiles"][t_c];
                Point velocity = direction.Scale(1);
                tile.SetVelocity(velocity);
                t_c += 1;
            }
            Actor anchor = cast["anchor"][0];
            Point vector = direction.Scale(1);
            anchor.SetVelocity(vector);
        }
        
    }
}