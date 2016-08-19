using System;

namespace cs_smallpt.core
{
    public class Specular
    {
        public static double Reflectance0(double n1, double n2)
        {
            double sqrt_R0 = (n1 - n2) / (n1 + n2);
            return sqrt_R0 * sqrt_R0;
        }

        public static double SchlickReflectance(double n1, double n2, double c)
        {
            double R0 = Reflectance0(n1, n2);
            return R0 + (1 - R0) * c * c * c * c * c;
        }

        public static Vector3 IdealSpecularReflect(Vector3 d, Vector3 n)
        {
	        return d - 2.0 * n.Dot(d) * n;
        }

        public static Vector3 IdealSpecularTransmit(Vector3 d, Vector3 n, double n_out, double n_in, out double pr, RNG rng)
        {
            Vector3 d_Re = IdealSpecularReflect(d, n);

            bool out_to_in = n.Dot(d) < 0;
            Vector3 nl = out_to_in ? n : -n;
            double nn = out_to_in ? n_out / n_in : n_in / n_out;
            double cos_theta = d.Dot(nl);
            double cos2_phi = 1.0 - nn * nn * (1.0 - cos_theta * cos_theta);

            // Total Internal Reflection
            if (cos2_phi < 0)
            {
                pr = 1.0;
                return d_Re;
            }

            Vector3 d_Tr = (nn * d - nl * (nn * cos_theta + Math.Sqrt(cos2_phi))).Normalize();
            double c = 1.0 - (out_to_in ? -cos_theta : d_Tr.Dot(n));

            double Re = SchlickReflectance(n_out, n_in, c);
            double p_Re = 0.25 + 0.5 * Re;
            if (rng.UniformFloat() < p_Re)
            {
                pr = (Re / p_Re);
                return d_Re;
            }
            else
            {
                double Tr = 1.0 - Re;
                double p_Tr = 1.0 - p_Re;
                pr = (Tr / p_Tr);
                return d_Tr;
            }
        }
    }
}
