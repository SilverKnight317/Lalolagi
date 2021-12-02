using System;

namespace Lalolagi.Casting
{
    public class Tile : Actor
    {
        private int _tileHeight = Constants.TILE_HEIGHT;
        private int _tileWidth = Constants.TILE_WIDTH;
        private int _tile_rating;
        private int _previous_tile_number;
        private int _current_tile_number;

        Noise _noise;
        public Tile(int _x, int _y, Noise noise)
        {
            _noise = noise;
            SetHeight(_tileHeight);
            SetWidth(_tileWidth);

            _previous_tile_number = noise.Perlin_Noise(_x - 1, _y, _x - 1);
            _tile_rating = noise.Perlin_Noise(_x, _y, _x);

            _current_tile_number = _tile_rating + _previous_tile_number;
            
            if (_current_tile_number < -4)
            {
                _current_tile_number = -4;
            }
            if (_current_tile_number > 3)
            {
                _current_tile_number = 3;
            }
            if (_current_tile_number == -4)
            {
                SetImage(Constants.IMAGE_OceanTile_1);
            }
            if (_current_tile_number == 3)
            {
                SetImage(Constants.IMAGE_SANDTILE_1);
            }
            if (_current_tile_number == -2)
            {
                SetImage(Constants.IMAGE_SANDTILE_2);
            }
            if (_current_tile_number == -1)
            {
                SetImage(Constants.IMAGE_LANDTILE_1);
            }
            if (_current_tile_number == 0)
            {
                SetImage(Constants.IMAGE_LAND_TO_MTN_1);
            }
            if (_current_tile_number == 1)
            {
                SetImage(Constants.IMAGE_MTNTILE_1);
            }
            if (_current_tile_number == 2)
            {
                SetImage(Constants.IMAGE_MTN_TRANSITION);
            }
            if (_current_tile_number == 3)
            {
                SetImage(Constants.IMAGE_MtnTile_2);
            }
            /*
            if (_current_tile_number < -4)
            {
                _current_tile_number = -4;
            }
            if (_current_tile_number > 3)
            {
                _current_tile_number = 3;
            }
            if (_current_tile_number == -4)
            {
                SetImage(Constants._img_px_0);
            }
            if (_current_tile_number == -3)
            {
                SetImage(Constants._img_px_1);
            }
            if (_current_tile_number == -2)
            {
                SetImage(Constants._img_px_2);
            }
            if (_current_tile_number == -1)
            {
                SetImage(Constants._img_px_3);
            }
            if (_current_tile_number == 0)
            {
                SetImage(Constants._img_px_4);
            }
            if (_current_tile_number == 1)
            {
                SetImage(Constants._img_px_5);
            }
            if (_current_tile_number == 2)
            {
                SetImage(Constants._img_px_6);
            }
            if (_current_tile_number == 3)
            {
                SetImage(Constants._img_px_7);
            } */
            // SetImage(Constants.IMAGE_MTN_TRANSITION);
            // Console.WriteLine(noise.Perlin_Noise(_x, _y, _x));
        }
    }
}