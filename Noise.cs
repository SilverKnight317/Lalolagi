using System;

namespace Lalolagi
{
    public class Noise
    {
        private double x;
        private double y;
        // private int gradients[];
        private readonly int[] permutation = 
            { 210, 82, 166, 250, 43,
            81, 233, 28, 41, 177, 180, 12, 0, 100, 39, 230, 60, 132, 8,
            134, 127, 71, 54, 124, 62, 108, 190, 119, 222, 219, 133, 217,
            55, 197, 207, 227, 137, 115, 221, 162, 235, 67, 206, 128, 131,
            214, 99, 153, 253, 193, 140, 78, 23, 251, 66, 117, 58, 31, 36,
            13, 79, 70, 135, 223, 126, 254, 239, 240, 93, 92, 32, 172, 110,
            165, 249, 34, 220, 37, 125, 73, 76, 209, 208, 94, 89, 229, 103,
            234, 40, 196, 144, 77, 18, 114, 243, 183, 245, 45, 97, 116, 48,
            176, 22, 2, 178, 64, 68, 72, 50, 44, 158, 75, 6, 237, 247, 147,
            146, 241, 86, 69, 35, 24, 157, 16, 168, 215, 19, 252, 173, 105,
            155, 232, 27, 192, 98, 238, 9, 204, 160, 171, 63, 191, 164, 200,
            104, 113, 112, 211, 152, 5, 107, 121, 181, 7, 21, 189, 14, 188,
            148, 145, 187, 248, 122, 106, 169, 185, 46, 184, 51, 57, 174,
            120, 142, 85, 182, 123, 151, 216, 149, 218, 154, 118, 17, 255,
            42, 228, 202, 170, 29, 244, 53, 139, 161, 84, 47, 231, 194, 203,
            30, 213, 156, 59, 80, 167, 201, 61, 212, 130, 87, 101, 102, 159,
            163, 56, 242, 91, 111, 25, 65, 236, 38, 195, 186, 88, 175, 95,
            205, 20, 136, 74, 141, 3, 150, 179, 52, 129, 15, 225, 10, 11,
            224, 246, 143, 83, 26, 109, 198, 33, 96, 90, 4, 49, 199, 226, 1, 210, 82, 166, 250, 43,
            81, 233, 28, 41, 177, 180, 12, 0, 100, 39, 230, 60, 132, 8,
            134, 127, 71, 54, 124, 62, 108, 190, 119, 222, 219, 133, 217,
            55, 197, 207, 227, 137, 115, 221, 162, 235, 67, 206, 128, 131,
            214, 99, 153, 253, 193, 140, 78, 23, 251, 66, 117, 58, 31, 36,
            13, 79, 70, 135, 223, 126, 254, 239, 240, 93, 92, 32, 172, 110,
            165, 249, 34, 220, 37, 125, 73, 76, 209, 208, 94, 89, 229, 103,
            234, 40, 196, 144, 77, 18, 114, 243, 183, 245, 45, 97, 116, 48,
            176, 22, 2, 178, 64, 68, 72, 50, 44, 158, 75, 6, 237, 247, 147,
            146, 241, 86, 69, 35, 24, 157, 16, 168, 215, 19, 252, 173, 105,
            155, 232, 27, 192, 98, 238, 9, 204, 160, 171, 63, 191, 164, 200,
            104, 113, 112, 211, 152, 5, 107, 121, 181, 7, 21, 189, 14, 188,
            148, 145, 187, 248, 122, 106, 169, 185, 46, 184, 51, 57, 174,
            120, 142, 85, 182, 123, 151, 216, 149, 218, 154, 118, 17, 255,
            42, 228, 202, 170, 29, 244, 53, 139, 161, 84, 47, 231, 194, 203,
            30, 213, 156, 59, 80, 167, 201, 61, 212, 130, 87, 101, 102, 159,
            163, 56, 242, 91, 111, 25, 65, 236, 38, 195, 186, 88, 175, 95,
            205, 20, 136, 74, 141, 3, 150, 179, 52, 129, 15, 225, 10, 11,
            224, 246, 143, 83, 26, 109, 198, 33, 96, 90, 4, 49, 199, 226, 1};

            /// <summary>
            /// The Noise function is geared for "Pseudo-Random" for a quite natural-esque form of generation.
            /// </summary>
        public Noise()
        {
            int xx = Convert.ToInt32(x) & 255;
            int yy = Convert.ToInt32(y) & 255;

            double xdiff = Math.Floor(x);

        }
        public void Perlin_Noise(int px, int py, int z)
        {
            // This Perlin Noise would be based on a 2D scale
            x = (px / z) * 10;
            y = (py / z) * 10;
        }
        private void Gradient_Vector(double input)
        {
            
        }
        private double Linear_Interpolation(double a, double b, double c)
        {
            // Linear Interpolation is basically a "Connect the Dots" type of function
            return a + x * (b - a);
        }
        private double Dot_Product(double a, double b, double c)
        {
            // The Dot Product is a scalar value
            return (Math.Sqrt(a * Math.Exp(2) + b * Math.Exp(2) + c * Math.Exp(2)));
        }
        private double Fade_Function(double input)
        {
            // The Fade function eases the differentiating values between the current calculated tile with the others around it. 
            // You don't want to have neightboring tiles with a difference of something like 0 to 100!
            return (6 * (input * Math.Exp(6)) - 15 * (input * Math.Exp(4)) + 10 * (input * Math.Exp(3)));
        }
        public void Simplex(double xin, double yin)
        {
            double n0, n1, n2;
            double f2 = (0.5)*(Math.Sqrt(3.0)-1.0);
            double s = (xin + yin)*f2;
            int i = Convert.ToInt32(Math.Floor(xin + s));
            int j = Convert.ToInt32(Math.Floor(yin + s));
        }
    }
}