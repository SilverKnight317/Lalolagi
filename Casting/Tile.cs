using System;
namespace Lalolagi.Casting
{
    public class Tile : Actor
    {
        Noise noise = new Noise();
        private int _tileHeight = Constants.TILE_HEIGHT;
        private int _tileWidth = Constants.TILE_WIDTH;
        private int _tile_rating;
        private int _previous_tile_number;
        private int _current_tile_number;
  
        public Tile()
        {
        
        }
        public void SetTile(int _x, int _y, int _prevTile)
        {
            SetHeight(_tileHeight);
            SetWidth(_tileWidth);

            
            _previous_tile_number = noise.Perlin_Noise(_x - 1, _y, _x - 1);
            _tile_rating = noise.Perlin_Noise(_x, _y, _x);

            // _current_tile_number = _prevTile + (_tile_rating + _previous_tile_number);
            _current_tile_number = _previous_tile_number + _tile_rating;


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
                SetImage(Constants.IMAGE_O_0);
                Console.WriteLine(Constants.IMAGE_O_0);
            }
            if (_current_tile_number == -3)
            {
                SetImage(Constants.IMAGE_O_1);
                Console.WriteLine(Constants.IMAGE_O_1);
            }
            if (_current_tile_number == -2)
            {
                SetImage(Constants.IMAGE_O_2);
                Console.WriteLine(Constants.IMAGE_O_2);
            }
            if (_current_tile_number == -1)
            {
                SetImage(Constants.IMAGE_O_3);
                Console.WriteLine(Constants.IMAGE_O_3);
            }
            if (_current_tile_number == 0)
            {
                SetImage(Constants.IMAGE_SANDTILE_1);
                Console.WriteLine(Constants.IMAGE_SANDTILE_1);
            }
            if (_current_tile_number == 1)
            {
                SetImage(Constants.IMAGE_SANDTILE_2);
                Console.WriteLine(Constants.IMAGE_SANDTILE_2);
            }
            if (_current_tile_number == 2)
            {
                SetImage(Constants.IMAGE_LANDTILE_1);
                Console.WriteLine(Constants.IMAGE_LANDTILE_1);
            }
            if (_current_tile_number == 3)
            {
                SetImage(Constants.IMAGE_MTNTILE_1);
                Console.WriteLine(Constants.IMAGE_MTNTILE_1);
            }        
        }
        public void ManualTileSet(int current_tile_number)
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
                SetImage(Constants.IMAGE_O_0);
            }
            if (current_tile_number == -3)
            {
                SetImage(Constants.IMAGE_O_1);
            }
            if (current_tile_number == -2)
            {
                SetImage(Constants.IMAGE_O_2);
            }
            if (current_tile_number == -1)
            {
                SetImage(Constants.IMAGE_O_3);
            }
            if (current_tile_number == 0)
            {
                SetImage(Constants.IMAGE_SANDTILE_1);
            }
            if (current_tile_number == 1)
            {
                SetImage(Constants.IMAGE_SANDTILE_2);
            }
            if (current_tile_number == 2)
            {
                SetImage(Constants.IMAGE_LANDTILE_1);
            }
            if (current_tile_number == 3)
            {
                SetImage(Constants.IMAGE_MTNTILE_1);
            } 
        }
        public int GetTileNum()
        {
            return _current_tile_number;
        }
    }
}