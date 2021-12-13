using System;

namespace Lalolagi
{
    public class Noise
    {
        private int x;
        private int y;
        private int z;
        
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
            
        }
        public int Perlin_Noise(int px, int py, int pz)
        {
            // This Perlin Noise would be based on a 2D scale

            x = px & 255;
            y = py & 255;
            z = pz & 255;

            // The fade function is used to... well fade the numbers when there's a 
            double fx = Fade_Function(x);
            double fy = Fade_Function(y);
            double fz = Fade_Function(z);

            int aaa = permutation[permutation[permutation[x    ] +  y     ] +  z     ];
            int aab = permutation[permutation[permutation[x    ] + (y + 1)] +  z     ];
            int aba = permutation[permutation[permutation[x    ] +  y     ] + (z + 1)];
            int abb = permutation[permutation[permutation[x    ] + (y + 1)] + (z + 1)];
            int baa = permutation[permutation[permutation[x + 1] + (y    )] + (z    )];
            int bab = permutation[permutation[permutation[x + 1] + (y + 1)] + (z    )];
            int bba = permutation[permutation[permutation[x + 1] + (y    )] + (z + 1)];
            int bbb = permutation[permutation[permutation[x + 1] + (y + 1)] + (z + 1)];

            double x_1 = Linear_Interpolation(Second_Dot_Product(aaa, x, y), Second_Dot_Product(aab, x - 1, y), fx);
            double x_2 = Linear_Interpolation(Second_Dot_Product(aba, x, y), Second_Dot_Product(abb, x - 1, y), fx);
            
            double y_1 = Linear_Interpolation(x_1, x_2, fy);

            x_1 = Linear_Interpolation(Second_Dot_Product(baa, x, y), Second_Dot_Product(bab, x - 1, y), fx);
            x_2 = Linear_Interpolation(Second_Dot_Product(bba, x, y), Second_Dot_Product(bbb, x - 1, y), fx);

            double y_2 = Linear_Interpolation(x_1, x_2, fy);

            int output = Convert.ToInt32(((Linear_Interpolation(y_1, y_2, fz) + 1) / 2) % 3);
            
            return output;
        }
        private double Linear_Interpolation(double a, double b, double c)
        {
            // Linear Interpolation is basically a "Connect the Dots" type of function
            return a + x * (b - a);
        }
        
        private double Fade_Function(double input)
        {
            // The Fade function eases the differentiating values between the current calculated tile with the others around it. 
            // You don't want to have neightboring tiles with a difference of something like 0 to 100!
            return (6 * (input * Math.Exp(6)) - 15 * (input * Math.Exp(4)) + 10 * (input * Math.Exp(3)));
        }

        private int[] Gradient_Vector(int input)
        {
            int[] gradie = {0, 0, 0};
            if (input == 0)
            {
                gradie[0] = 1;
                gradie[1] = 1;
                gradie[2] = 0;
            }
            if (input == 1)
            {
                gradie[0] = -1;
                gradie[1] = 1;
                gradie[2] = 0;
            }
            if (input == 2)
            {
                gradie[0] = 1;
                gradie[1] = -1;
                gradie[2] = 0;
            }
            if (input == 3)
            {
                gradie[0] = -1;
                gradie[1] = -1;
                gradie[2] = 0;
            }
            if (input == 4)
            {
                gradie[0] = 1;
                gradie[1] = 0;
                gradie[2] = 1;
            }
            if (input == 5)
            {
                gradie[0] = -1;
                gradie[1] = 0;
                gradie[2] = 1;
            }
            if (input == 6)
            {
                gradie[0] = 1;
                gradie[1] = 0;
                gradie[2] = -1;
            }
            if (input == 7)
            {
                gradie[0] = -1;
                gradie[1] = 0;
                gradie[2] = -1;
            }
            if (input == 8)
            {
                gradie[0] = 0;
                gradie[1] = 1;
                gradie[2] = 1;
            }
            if (input == 9)
            {
                gradie[0] = 0;
                gradie[1] = -1;
                gradie[2] = 1;
            }
            if (input == 10)
            {
                gradie[0] = 0;
                gradie[1] = 1;
                gradie[2] = -1;
            }
            if (input == 11)
            {
                gradie[0] = 0;
                gradie[1] = -1;
                gradie[2] = -1;
            }

            return gradie;
        }
        private double Dot_Product(int[] a, double xx, double yy)
        {
            // The Dot Product is a scalar value
            return (Math.Sqrt(a[0] * xx + a[1] * yy));
            // Remember Andy: Dot Product is not like getting magnitude of a vector!
            // return (Math.Sqrt(a[0] * Math.Exp(2) + b * Math.Exp(2) + c * Math.Exp(2)));
        }
        private double Second_Dot_Product(int a, int i, int j)
        {
            return ((a * i) + (a * j));
        }

        /// <Summary>
        /// Simplex noise uses a slightly differernt form of caluculation than Perlin Noise.
        /// It uses cells, skews them one way to determine the location, unskews them afterwards, and then calculates with gradients.
        /// <summary>
        public void Simplex(double xin, double yin)
        {
            int i1, j1;
            double n0, n1, n2;
            double f2 = (0.5)*(Math.Sqrt(3.0)-1.0);
            double s = (xin + yin)*f2;
            int i = Convert.ToInt32(Math.Floor(xin + s));
            int j = Convert.ToInt32(Math.Floor(yin + s));

            double g2 = (3.0 - Math.Sqrt(3.0)) / 6.0;
            double t = (i + j) * g2;
            double x0 = i - t;
            double y0 = j - t;
            double xo = xin - x0;
            double yo = yin - y0;

            if(xo > yo)
            {
                i1 = 1;
                j1 = 0;
            }
            else 
            {
                i1 = 0;
                j1 = 1;
            }

            // this is to offset for the skewer
            double x1 = x0 - i1 + g2;
            double y1 = y0 - j1 + g2;
            double x2 = x0 - 1.0 + 2.0 * g2;
            double y2 = y0 - 1.0 + 2.0 * g2;

            int ii = i & 255;
            int jj = j & 255;

            int grad_i_0 = permutation[ii +      permutation[jj     ]] % 4;
            int grad_i_1 = permutation[ii + i1 + permutation[jj + j1]] % 4;
            int grad_i_2 = permutation[ii +  1 + permutation[jj + 1 ]] % 4;

            double t0 = 0.5 - xo * xo - yo * yo;
            if (t0 < 0 )
            {
                n0 = 0.0;
            }
            else
            {
                n0 = t0 * t0 * Dot_Product(Gradient_Vector(grad_i_0), xo, yo);
            }

            double t1 = 0.5 - x1 * x1 - y1 * y1;
            if (t1 < 0 )
            {
                n1 = 0.0;
            }
            else
            {
                n1 = t1 * t1 * Dot_Product(Gradient_Vector(grad_i_1), x1, y1);
            }

            double t2 = 0.5 - x2 * x2 - y2 * y2;
            if (t2 < 0)
            {
                n2 = 0.0;
            }
            else 
            {
                n2 = t2 * t2 * Dot_Product(Gradient_Vector(grad_i_2), x2, y2);
            }

            double output_fix = n0 + n1 + n2;
            if (output_fix < 0)
            {
                output_fix = 0;
            }
            // int output_final = Convert.ToInt32(Math.Floor(output_fix));

            // double output_value = (n0 + n1 + n2) * 100;
            // int output_value = Convert.ToInt32(n0 + n1 + n2);
            // return Convert.ToInt32(n0 + n1 + n2);
            Console.WriteLine($"({xin}, {yin}): {output_fix}");
        }
    }
}