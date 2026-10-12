//A Vector that uses integers instead of floats, for movement and coordinates

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class VectorInt
    {
        internal VectorInt(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal int X { get; set; }
        internal int Y { get; set; }

        static internal VectorInt Add (VectorInt A, VectorInt B) => new( A.X + B.X , A.Y + B.Y );
        static internal VectorInt Subtract (VectorInt A, VectorInt B) => new(A.X - B.X, A.Y - B.Y);

        static internal VectorInt Up => new(0,-1);
        static internal VectorInt Down => new(0, 1);
        static internal VectorInt Left => new(-1, 0);
        static internal VectorInt Right => new(1, 0);
        static internal VectorInt Zero => new(0, 0);
    }
}
