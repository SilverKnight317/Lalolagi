namespace Lalolagi.Casting
{
    public class Player: Actor
    {
        private int _playerWidth = Constants.TILE_HEIGHT;
        private int _playerHeigth = 20;

        public Player()
        {
            SetHeight(_playerHeigth);
            SetWidth(_playerWidth);
            SetImage(Constants.IMAGE_PLAYER);
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2));
        }
    }
}