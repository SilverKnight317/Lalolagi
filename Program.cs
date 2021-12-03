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
            /*
            List<Student> people = new List<Student>();
            Student p1 = new Student();
            p1.Set_First_Name("Jeffy");
            p1.Set_Last_Name("Burrito");
            p1.Set_GPA(2);
            people.Add(p1);
            Student p2 = new Student();
            p2.Set_First_Name("Beffy");
            p2.Set_Last_Name("Dorito");
            p2.Set_GPA(3);
            people.Add(p2);
            Student p3 = new Student();
            p3.Set_First_Name("Pepsi");
            p3.Set_Last_Name("Longito");
            p3.Set_GPA(4);
            people.Add(p3);
            foreach(Student person in people)
            {
                Console.WriteLine(person.Get_Full_Info());
            }
            */

            
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // The ScoreBoard
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.SetPosition(new Point( 5 , Constants.MAX_Y - 40));
            cast["scoreBoard"] = new List<Actor>();
            cast["scoreBoard"].Add(scoreBoard);


            // Creating map
            Noise noise = new Noise();
            cast["tiles"] = new List<Actor>();
            // for(int x = 0; x <= Constants.MAX_X; x += Constants.TILE_WIDTH)
            // {
            //     for(int y = 0; y <= Constants.MAX_Y; y += Constants.TILE_HEIGHT)
            //     {

            //         Tile t = new Tile(x / 32, y /32, noise);
            //         t.SetPosition(new Point(x, y));
            //         cast["tiles"].Add(t);
            //     }
            // }

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

            // for(int x = 0; x <= Constants.MAX_X; x += 2)
            // {
            //     for(int y = 0; y <= Constants.MAX_Y; y += 2)
            //     {
            //         Console.WriteLine($"{x / 2}, {y / 2}");
            //         Tile t = new Tile(x / 2, y / 2, noise);
            //         t.SetPosition(new Point(x, y));
            //         cast["tiles"].Add(t);
            //     }
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
            UpdateScore updateScore = new UpdateScore(scoreBoard);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.
            script["update"].Add(moveActors);
            script["update"].Add(handleOffScreenActions);
            script["update"].Add(controlActorsAction);
            script["update"].Add(handleCollisionsAction);
            script["update"].Add(updateScore);
            


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
