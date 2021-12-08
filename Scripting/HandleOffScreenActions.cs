using System.Collections.Generic;
using Lalolagi.Casting;
using Lalolagi.Services;

namespace Lalolagi.Scripting
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
            List<Actor> actors = cast["tiles"];
            Actor anchor = cast["anchor"][0];
            int _beforeTile = 0;
            foreach(Actor actor in actors)
            {
                Tile tile = new Tile();
                int x = actor.GetX();
                int y = actor.GetY();

                // int dx = actor.GetVelocity().GetX();
                // int dy = actor.GetVelocity().GetY();

                // int newX = (x + dx) % Constants.MAX_X;
                // int newY = (y + dy) % Constants.MAX_Y;
                // if(x > Constants.MAX_X)
                // {

                // }
                int newX = x % (Constants.MAX_X);
                if(newX == 0)
                {
                    tile.SetTile((newX + anchor.GetX()) / 32, (actor.GetY() + anchor.GetY()) / 32, _beforeTile);
                    ChangeImage(actor, _beforeTile);
                    _beforeTile = tile.GetTileNum();


                }
                int newY = y % (Constants.MAX_Y);
                if(newY == 0)
                {
                    tile.SetTile((actor.GetX() + anchor.GetX()) / 32, (newY + anchor.GetY()) / 32, _beforeTile);
                    ChangeImage(actor, _beforeTile);
                    _beforeTile = tile.GetTileNum();
                }



                if (newX < 0)
                {
                    newX = Constants.MAX_X;
                    tile.SetTile((newX + anchor.GetX()) / 32, (actor.GetY() + anchor.GetY()) / 32, _beforeTile);
                    ChangeImage(actor, _beforeTile);
                    _beforeTile = tile.GetTileNum();
                }

                if (newY < 0)
                {
                    newY = Constants.MAX_Y;
                    tile.SetTile((actor.GetX() + anchor.GetX()) / 32, (newY + anchor.GetY()) / 32, _beforeTile);
                    ChangeImage(actor, _beforeTile);
                    _beforeTile = tile.GetTileNum();
                }

                actor.SetPosition(new Point(newX, newY));
            }

            // List<Actor> tiles = cast["tiles"]; /* gets all tile actors from cast */
            // List<Actor> removeTile = new List<Actor>();
            // foreach (Actor actor in tiles)
            // {
            //     Actor tile = (Actor)actor;
            //     if(tile.GetX() >= Constants.MAX_X || tile.GetY() >= Constants.MAX_Y || tile.GetX() <= 0 || tile.GetY() <= 0)
            //     {
            //         removeTile.Add(tile);
            //         // cast["tiles"].Remove(tile);
            //     }
            // }
            // foreach(Actor actor in removeTile)
            // {
            //     cast["tiles"].Remove(actor);
            // }

            // List<Actor> tiles = cast["tiles"];
            // foreach(Actor actor in tiles)
            // {
            //     if(actor.GetX() < 0)
            //     {
            //         actor.SetPosition(new Point(Constants.MAX_X, actor.GetY()));
            //     }
            //     if(actor.GetY() < 0)
            //     {
            //         actor.SetPosition(new Point(actor.GetX(), Constants.MAX_Y));
            //     }
            // }
            // throw new System.NotImplementedException();
        }
        private void MoveIt(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();

            int dx = actor.GetVelocity().GetX();
            int dy = actor.GetVelocity().GetY();

            // int newX = (x + dx) % Constants.MAX_X;
            // int newY = (y + dy) % Constants.MAX_Y;
            int newX = x + dx;
            int newY = y + dy;

            // if (newX < 0)
            // {
            //     newX = Constants.MAX_X;
            // }

            // if (newY < 0)
            // {
            //     newY = Constants.MAX_Y;
            // }

            actor.SetPosition(new Point(newX, newY));
        }
        private void ChangeImage(Actor actor, int current_tile_number)
        {
            if (current_tile_number < -4)
            {
                current_tile_number = -4;
            }
            if (current_tile_number > 3)
            {
                current_tile_number = 3;
            }
            if (current_tile_number == -4)
            {
                actor.SetImage(Constants.IMAGE_O_0);
            }
            if (current_tile_number == -3)
            {
                actor.SetImage(Constants.IMAGE_O_1);
            }
            if (current_tile_number == -2)
            {
                actor.SetImage(Constants.IMAGE_O_2);
            }
            if (current_tile_number == -1)
            {
                actor.SetImage(Constants.IMAGE_O_3);
            }
            if (current_tile_number == 0)
            {
                actor.SetImage(Constants.IMAGE_SANDTILE_1);
            }
            if (current_tile_number == 1)
            {
                actor.SetImage(Constants.IMAGE_SANDTILE_2);
            }
            if (current_tile_number == 2)
            {
                actor.SetImage(Constants.IMAGE_LANDTILE_1);
            }
            if (current_tile_number == 3)
            {
                actor.SetImage(Constants.IMAGE_MTNTILE_1);
            } 
        }
    }
}