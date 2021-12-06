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
            List<Actor> tiles = cast["tiles"]; /* gets all tile actors from cast */
            List<Actor> removeTile = new List<Actor>();
            foreach (Actor actor in tiles)
            {
                Actor tile = (Actor)actor;
                if(tile.GetX() >= Constants.MAX_X || tile.GetY() >= Constants.MAX_Y || tile.GetX() <= 0 || tile.GetY() <= 0)
                {
                    removeTile.Add(tile);
                    // cast["tiles"].Remove(tile);
                }
            }
            foreach(Actor actor in removeTile)
            {
                cast["tiles"].Remove(actor);
            }

            // throw new System.NotImplementedException();
        }
    }
}