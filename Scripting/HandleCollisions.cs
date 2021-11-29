using System.Collections.Generic;
using Lalolagi.Casting;
using Lalolagi.Services;


namespace Lalolagi.Scripting
{
    /// <summary>
    /// An action to appropriately handle any collisions in the game.
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        PhysicsService _physicsService = new PhysicsService();
        AudioService _audioService;
        // ScoreBoard _scoreBoard;

        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
            // _scoreBoard = scoreBoard;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        { 
            
        }

    }
}