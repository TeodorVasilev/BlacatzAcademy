namespace TrianglePerimeter
{
    public class Triangle
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double GetPerimeter()
        {
            return this.A + this.B + this.C;
        }
    }
}
