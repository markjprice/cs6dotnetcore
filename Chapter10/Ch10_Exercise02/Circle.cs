using System;

namespace Ch10_Exercise02
{
    public class Circle : Shape
    {
        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public double Radius { get; set; }
    }
}
