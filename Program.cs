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

            // int _beforeTile = 0;
            // for(int x = 0; x <= Constants.MAX_X; x += Constants.TILE_WIDTH)
            // {
            //     for(int y = 0; y <= Constants.MAX_Y; y += Constants.TILE_HEIGHT)
            //     {

            //         Tile t = new Tile(x / 32, y / 32, _beforeTile, noise);
            //         t.SetPosition(new Point(x, y));
            //         cast["tiles"].Add(t);
            //         _beforeTile = t.GetTileNum();
            //     }
            // }


            // Create Anchor Tile
            // Tile anchor_tile = new Tile(Constants.ANCHOR_POINT_X, Constants.ANCHOR_POINT_Y, Constants.ANCHOR_POINT_X , noise);
            // anchor_tile.SetPosition(new Point(Constants.ANCHOR_POINT_X, Constants.ANCHOR_POINT_Y));
            // cast["Anchor"] = new List<Actor>();
            // cast["Anchor"].Add(anchor_tile);
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

            // for(int row = 0; row <= 1024; row += Constants.TILE_WIDTH)
            // {
            //     for(int column = 0; column <= 1024; column += Constants.TILE_HEIGHT)
            //     {
            //         Tile tile = new Tile();
            //         tile.SetTile(cast["anchor"][0].GetX() / 32, cast["anchor"][0].GetY() / 32, row);
            //         // tile.ManualTileSet(-1);
            //         tile.SetPosition(new Point(row, column));
            //         cast["tiles"].Add(tile);
            //     }
            // }

            // int faalotomaualaloina = 0;
            // foreach(Tile tile in cast["tiles"])
            // {
            //     tile.ManualTileSet(2);
            //     tile.SetPosition(new Point(faalotomaualaloina * 33, 32));
            //     faalotomaualaloina++;
            // }






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
