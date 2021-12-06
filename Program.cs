using System;
using Lalolagi.Services;
using Lalolagi.Casting;
using Lalolagi.Scripting;
using System.Collections.Generic;

namespace Lalolagi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // The ScoreBoard
            // ScoreBoard scoreBoard = new ScoreBoard();
            // scoreBoard.SetPosition(new Point( 5 , Constants.MAX_Y - 40));
            // cast["scoreBoard"] = new List<Actor>();
            // cast["scoreBoard"].Add(scoreBoard);


            // Creating map
            Noise noise = new Noise();
            cast["tiles"] = new List<Actor>();

            int _beforeTile = 0;
            for(int x = 0; x <= Constants.MAX_X; x += Constants.TILE_WIDTH)
            {
                for(int y = 0; y <= Constants.MAX_Y; y += Constants.TILE_HEIGHT)
                {

                    Tile t = new Tile(x / 32, y / 32, _beforeTile, noise);
                    t.SetPosition(new Point(x, y));
                    cast["tiles"].Add(t);
                    _beforeTile = t.GetTileNum();
                }
            }




            // The player, created and added to cast
            cast["player"] = new List<Actor>();
            Player player = new Player();
            cast["player"].Add(player);

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();
            MoveActorsAction moveActors = new MoveActorsAction();
            HandleOffScreenActions handleOffScreenActions = new HandleOffScreenActions(audioService);
            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, audioService);

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);
            // UpdateScore updateScore = new UpdateScore(scoreBoard);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.
            script["update"].Add(moveActors);
            script["update"].Add(handleOffScreenActions);
            script["update"].Add(controlActorsAction);
            script["update"].Add(handleCollisionsAction);
            // script["update"].Add(updateScore);
            


            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Lalolagi", Constants.FRAME_RATE);
            audioService.StartAudio();
            // audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            // audioService.StopAudio();
            
        }
    }
}
