using System;

namespace cs_smallpt.core
{
    public class Ray
    {
        public Vector3 o { get; set; }
        public Vector3 d { get; set; }
        public double tmin { get; set; }
        public double tmax { get; set; }
        public int depth { get; set; }

        public Ray(Vector3 o, Vector3 d, double tmin = 0.0, double tmax = double.PositiveInfinity, int depth = 0)
        {
            this.o = o.Clone();
            this.d = d.Clone();
            this.tmin = tmin;
            this.tmax = tmax;
            this.depth = depth;
        }

        public Vector3 Eval(double t) 
        {
            return o + d * t;
        }

        public override string ToString()
        {
            return "o: " + o.ToString() + '\n' + "d: " + d.ToString() + '\n';
        }
	}
}
