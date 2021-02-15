using System;
using System.Collections.Generic;
using System.Text;

namespace CSDlab2
{
    public abstract class Shape
    {
        public int X, Y;

        /// <summary>
        /// The shape's area.
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// The shapescore for the shape. 
        /// </summary>
        public abstract double ShapeScore { get; }

        /// <summary>
        /// Checks whether a specific point (x,y) is inside the shape.
        /// </summary>
        /// <returns>True if the point is inside the shape, otherwise false </returns>
        public abstract bool IsInside(int x, int y);
    }
}
