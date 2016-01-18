namespace Ch10_Exercise02
{
    public class Rectangle : Shape
    {
        public override double Area
        {
            get
            {
                return Height * Width;
            }
        }

        public double Height { get; set; }
        public double Width { get; set; }
    }
}
