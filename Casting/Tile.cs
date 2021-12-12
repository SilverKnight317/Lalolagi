using System;
namespace Lalolagi.Casting
{
    public class Tile : Actor
    {
        Noise noise;
        private int _tileHeight = Constants.TILE_HEIGHT;
        private int _tileWidth = Constants.TILE_WIDTH;
        private int _tile_rating;
        private int _previous_tile_number;
        private int _current_tile_number;
  
        public Tile(Noise _noise)
        {
            noise = _noise;
        }
        public void SetTile(int _x, int _y, int chunkTile)
        {
            SetHeight(_tileHeight);
            SetWidth(_tileWidth);

            
            _previous_tile_number = noise.Perlin_Noise(_x - 1, _y, _x - 1);

            _tile_rating = noise.Perlin_Noise(_x, _y, _x);

            int shift = 0;

            if(_previous_tile_number < 0)
            {
                shift = -1;
            }
            if(_previous_tile_number > 0)
            {
                shift = 1;
            }

            _current_tile_number = chunkTile + shift;  

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
                SetImage(Constants.IMG_LVL_0);
            }
            if(_current_tile_number == 1)
            {
                SetImage(Constants.IMG_LVL_1);
            }
            if(_current_tile_number == 2)
            {
                SetImage(Constants.IMG_LVL_2);
            }
            if(_current_tile_number == 3)
            {
                SetImage(Constants.IMG_LVL_3);
            }
            if(_current_tile_number == 4)
            {
                SetImage(Constants.IMG_LVL_4);
            }
            if(_current_tile_number == 5)
            {
                SetImage(Constants.IMG_LVL_5);
            }
            if(_current_tile_number == 6)
            {
                SetImage(Constants.IMG_LVL_6);
            }
            if(_current_tile_number == 7)
            {
                SetImage(Constants.IMG_LVL_7);
            }
            if(_current_tile_number == 8)
            {
                SetImage(Constants.IMG_LVL_8);
            }
            if(_current_tile_number == 9)
            {
                SetImage(Constants.IMG_LVL_9);
            }
            if(_current_tile_number == 10)
            {
                SetImage(Constants.IMG_LVL_10);
            }
            if(_current_tile_number == 11)
            {
                SetImage(Constants.IMG_LVL_11);
            }
            if(_current_tile_number == 12)
            {
                SetImage(Constants.IMG_LVL_12);
            }
            if(_current_tile_number == 13)
            {
                SetImage(Constants.IMG_LVL_13);
            }
            if(_current_tile_number == 14)
            {
                SetImage(Constants.IMG_LVL_14);
            }
        }
        public int ChunkTile(int _x, int _y)
        {
            int chunkOutput = noise.Perlin_Noise(_x, _y, _x);   
            if(chunkOutput < 1)
            {
                return 2;
            }
            if(chunkOutput > 1)
            {
                return 3;
            }
            else
            {
                return 1;
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