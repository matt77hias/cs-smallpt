using System;

namespace cs_smallpt {

    public class Sampling {

        public static Vector3 UniformSampleOnHemisphere(double u1, double u2) {
            double sin_theta = Math.Sqrt(Math.Max(0.0, 1.0 - u1 * u1));
            double phi = 2.0 * MathUtils.M_PI * u2;
            return new Vector3(Math.Cos(phi) * sin_theta, Math.Sin(phi) * sin_theta, u1);
        }

        public static Vector3 CosineWeightedSampleOnHemisphere(double u1, double u2) {
            double cos_theta = Math.Sqrt(1.0 - u1);
            double sin_theta = Math.Sqrt(u1);
            double phi = 2.0 * MathUtils.M_PI * u2;
            return new Vector3(Math.Cos(phi) * sin_theta, Math.Sin(phi) * sin_theta, cos_theta);
        }
    }
}
