using System;
using System.Collections.Generic;
using System.Text;

namespace CSDlab2
{
    public class Square : Shape
    {
        private double Side;
        private double Radius;
        private double InstancePoints;
        private const int TypePoint = 1;

        public Square(int x, int y, int length, double instancePoints)
        {
            this.X = x;
            this.Y = y;
            this.Side = length / 4;
            this.Radius = Side / 2;
            this.InstancePoints = instancePoints;
        }

        public override double Area => Math.Pow(Side, 2);

        public override double ShapeScore => (TypePoint * InstancePoints) / Area;

        public override bool IsInside(int x, int y)
        {
            if (x >= (X - Radius) && x <= (X + Radius) && y >= (Y - Radius) && y <= (Y + Radius))
            {
                return true;
            }
            else
            { return false; }
        }
    }
}
