using System.Collections.Generic;
using Lalolagi.Casting;
using Lalolagi.Services;

namespace Lalolagi.Scripting
{
    public class HandleOffScreenActions : Action
    {
        AudioService _audioService;
        Noise noise;
        public HandleOffScreenActions(AudioService audioService, Noise _noise)
        {
            _audioService = audioService;
            noise = _noise;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> actors = cast["tiles"];
            Actor anchor = cast["anchor"][0];
            int _beforeTile = 0;
            foreach(Actor actor in actors)
            {
                Tile tile = new Tile(noise);
                int x = actor.GetX();
                int y = actor.GetY();

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
        }
        private void MoveIt(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();

            int dx = actor.GetVelocity().GetX();
            int dy = actor.GetVelocity().GetY();

            int newX = x + dx;
            int newY = y + dy;

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