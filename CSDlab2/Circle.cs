using System;
using System.Collections.Generic;
using System.Text;

namespace CSDlab2
{
    public class Circle : Shape
    {
        private double InstancePoints;
        private double Length;
        private double Radius;
        private const int TypePoint = 2;

        public Circle(int x, int y, int length, double instancePoints)
        {
            this.X = x;
            this.Y = y;
            this.Length = length;
            this.InstancePoints = instancePoints;
            this.Radius = (length / Math.PI) / 2;
        }
        public override double Area => Math.Pow(Length,2) / (4 * Math.PI);

        public override double ShapeScore => (TypePoint * InstancePoints) / Area;

        public override bool IsInside(int x, int y)
        {
            if ( Math.Pow((x - X), 2) + Math.Pow(y - Y, 2) <= Math.Pow(Radius, 2))      // inspired by : https://stackoverflow.com/questions/481144/equation-for-testing-if-a-point-is-inside-a-circle
            {
                return true;
            }
            else { return false; }
        }
    }
}
