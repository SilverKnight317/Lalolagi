using System.Collections.Generic;
using System;
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
                    tile.SetTile((newX + anchor.GetX()) / 16, (actor.GetY() + anchor.GetY()) / 16, _beforeTile);
                    ChangeImage(actor, _beforeTile);
                    _beforeTile = tile.GetTileNum();


                }
                
                int newY = y % (Constants.MAX_Y);

                if(newY == 0)
                {
                    tile.SetTile((actor.GetX() + anchor.GetX()) / 16, (newY + anchor.GetY()) / 16, _beforeTile);
                    ChangeImage(actor, _beforeTile);
                    _beforeTile = tile.GetTileNum();
                }
                if (newX < 0)
                {
                    newX = Constants.MAX_X;
                    tile.SetTile((newX + anchor.GetX()) / 16, (actor.GetY() + anchor.GetY()) / 16, _beforeTile);
                    ChangeImage(actor, _beforeTile);
                    _beforeTile = tile.GetTileNum();
                }

                if (newY < 0)
                {
                    newY = Constants.MAX_Y;
                    tile.SetTile((actor.GetX() + anchor.GetX()) / 16, (newY + anchor.GetY()) / 16, _beforeTile);
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
        private void ChangeImage(Actor actor, int _current_tile_number)
        {
            if(_current_tile_number < 0)
            {
                _current_tile_number = 0;
            } 
            if(_current_tile_number > 14)
            {
                _current_tile_number = 14;
            }
            if(_current_tile_number == 0)
            {
                actor.SetImage(Constants.IMG_LVL_0);
            }
            if(_current_tile_number == 1)
            {
                actor.SetImage(Constants.IMG_LVL_1);
            }
            if(_current_tile_number == 2)
            {
                actor.SetImage(Constants.IMG_LVL_2);
            }
            if(_current_tile_number == 3)
            {
                actor.SetImage(Constants.IMG_LVL_3);
            }
            if(_current_tile_number == 4)
            {
                actor.SetImage(Constants.IMG_LVL_4);
            }
            if(_current_tile_number == 5)
            {
                actor.SetImage(Constants.IMG_LVL_5);
            }
            if(_current_tile_number == 6)
            {
                actor.SetImage(Constants.IMG_LVL_6);
            }
            if(_current_tile_number == 7)
            {
                actor.SetImage(Constants.IMG_LVL_7);
            }
            if(_current_tile_number == 8)
            {
                actor.SetImage(Constants.IMG_LVL_8);
            }
            if(_current_tile_number == 9)
            {
                actor.SetImage(Constants.IMG_LVL_9);
            }
            if(_current_tile_number == 10)
            {
                actor.SetImage(Constants.IMG_LVL_10);
            }
            if(_current_tile_number == 11)
            {
                actor.SetImage(Constants.IMG_LVL_11);
            }
            if(_current_tile_number == 12)
            {
                actor.SetImage(Constants.IMG_LVL_12);
            }
            if(_current_tile_number == 13)
            {
                actor.SetImage(Constants.IMG_LVL_13);
            }
            if(_current_tile_number == 14)
            {
                actor.SetImage(Constants.IMG_LVL_14);
            }
        }
    }
}