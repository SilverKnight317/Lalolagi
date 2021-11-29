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

            // The paddle
            cast["player"] = new List<Actor>();

            // TODO: Add your paddle here
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
