namespace Lalolagi.Casting
{
    public class Tile : Actor
    {
        private int _tileHeight = Constants.TILE_HEIGHT;
        private int _tileWidth = Constants.TILE_WIDTH;

        public Tile()
        {
            SetHeight(_tileHeight);
            SetWidth(_tileWidth);
            
        }
    }
}