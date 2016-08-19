using System;

namespace cs_smallpt.core
{
    public class Sampling
    {
        public static Vector3 UniformSampleOnHemisphere(double u1, double u2)
        {
            double r = Math.Sqrt(Math.Max(0.0, 1.0 - u1 * u1));
            double phi = 2.0 * MathUtils.M_PI * u2;
            return new Vector3(r * Math.Cos(phi), r * Math.Sin(phi), u1);
        }
    }
}
