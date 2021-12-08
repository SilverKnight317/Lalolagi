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
            for(int a = 0; a < 1024; a++)
            {
                Tile tool = new Tile();
                cast["tiles"].Add(tool);
            }

            Actor anchor_tile = new Actor();
            anchor_tile.SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2));
            anchor_tile.SetImage(Constants.IMAGE_ANCHOR);
            cast["anchor"] = new List<Actor>();
            cast["anchor"].Add(anchor_tile);
            int _beforeTile = 0;
            for(int row = 0; row <= Constants.MAX_X; row += Constants.TILE_WIDTH)
            {
                for(int column = 0; column <= Constants.MAX_Y; column += Constants.TILE_HEIGHT)
                {
                    Tile tile = new Tile();
                    tile.SetTile((row + cast["anchor"][0].GetX()) / 32, (column + cast["anchor"][0].GetY()) / 32, _beforeTile);
                    // tile.ManualTileSet(2);
                    tile.SetPosition(new Point(row, column));
                    cast["tiles"].Add(tile);
                    _beforeTile = tile.GetTileNum();
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
