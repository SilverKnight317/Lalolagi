using System;

namespace Lalolagi
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 1024;
        public const int MAX_Y = 1024;
        public const int FRAME_RATE = 30;
        public const int ANCHOR_POINT_X = MAX_X / 32;
        public const int ANCHOR_POINT_Y = MAX_Y / 32;
        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;
        public const string IMAGE_OceanTile_1 = "./Assets/OceanTile_1.png";
        public const string IMAGE_SANDTILE_1 = "./Assets/SandTile_1.png";
        public const string IMAGE_SANDTILE_2 = "./Assets/SandToLand_1.png";
        public const string IMAGE_LANDTILE_1 = "./Assets/LandTile_1.png";
        public const string IMAGE_LAND_TO_MTN_1 = "./Assets/LandToMtn_1.png";
        public const string IMAGE_MTNTILE_1 = "./Assets/MtnTile_1.png";
        public const string IMAGE_MTN_TRANSITION = "./Assets/Mtn1ToMtn2_1.png";
        public const string IMAGE_MtnTile_2 = "./Assets/MtnTile_2.png";
        public const string IMAGE_PLAYER = "./Assets/bird.png";
        public const string IMAGE_O_0 = "./Assets/Ocean_D_0.png";
        public const string IMAGE_O_1 = "./Assets/Ocean_D_1.png";
        public const string IMAGE_O_2 = "./Assets/Ocean_D_2.png";
        public const string IMAGE_O_3 = "./Assets/Ocean_D_3.png";
        public const string IMAGE_ANCHOR = "./Assets/Anchor_point.png";
        
        public const int TILE_HEIGHT = 32;
        public const int TILE_WIDTH = 32;
        public const string IMAGE_BRICK = "./Assets/brick-3.png";
        public const string IMAGE_PADDLE = "./Assets/bat.png";
        public const string IMAGE_BALL = "./Assets/ball.png";

        public const string SOUND_START = "./Assets/start.wav";
        public const string SOUND_BOUNCE = "./Assets/boing.wav";
        public const string SOUND_OVER = "./Assets/over.wav";

        public const int BALL_X = MAX_X / 2;
        public const int BALL_Y = MAX_Y - 125;

        public const int BALL_DX = 8;
        public const int BALL_DY = BALL_DX * -1;

        public const int PADDLE_X = MAX_X / 2;
        public const int PADDLE_Y = MAX_Y - 25;

        public const int BRICK_WIDTH = 48;
        public const int BRICK_HEIGHT = 24;

        public const int BRICK_SPACE = 5;

        public const int PADDLE_SPEED = 15;

        public const int PADDLE_WIDTH = 96;
        public const int PADDLE_HEIGHT = 24;

        public const int BALL_WIDTH = 24;
        public const int BALL_HEIGHT = 24;

    }



}