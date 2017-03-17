using System;

namespace cs_smallpt
{
	public class Sphere
	{
		public enum Reflection_t { DIFFUSE, SPECULAR, REFRACTIVE };

		public const double EPSILON_SPHERE = 1e-4;

		public double r { get; set; }
		public Vector3 p { get; set; }
		public Vector3 e { get; set; }
		public Vector3 f { get; set; }
		public Reflection_t reflection_t { get; set; }

		public Sphere(double r, Vector3 p, Vector3 e, Vector3 f, Reflection_t reflection_t)
		{
			this.r = r;
			this.p = p.Clone();
			this.e = e.Clone();
			this.f = f.Clone();
			this.reflection_t = reflection_t;
		}
		
		public bool Intersect(Ray ray)
		{
			// (o + t*d - p) . (o + t*d - p) - r*r = 0
			// <=> (d . d) * t^2 + 2 * d . (o - p) * t + (o - p) . (o - p) - r*r = 0
			// 
			// Discriminant check
			// (2 * d . (o - p))^2 - 4 * (d . d) * ((o - p) . (o - p) - r*r) <? 0
			// <=> (d . (o - p))^2 - (d . d) * ((o - p) . (o - p) - r*r) <? 0
			// <=> (d . op)^2 - 1 * (op . op - r*r) <? 0
			// <=> b^2 - (op . op) + r*r <? 0
			// <=> D <? 0
			//
			// Solutions
			// t = (- 2 * d . (o - p) +- 2 * sqrt(D)) / (2 * (d . d))
			// <=> t = dop +- sqrt(D)

			Vector3 op = p - ray.o;
			double dop = ray.d.Dot(op);
			double D = dop * dop - op.Dot(op) + r * r;

			if (D < 0)
				return false;

			double sqrtD = Math.Sqrt(D);

			double tmin = dop - sqrtD;
			if (ray.tmin < tmin && tmin < ray.tmax)
			{
				ray.tmax = tmin;
				return true;
			}

			double tmax = dop + sqrtD;
			if (ray.tmin < tmax && tmax < ray.tmax)
			{
				ray.tmax = tmax;
				return true;
			}

			return false;
		}
	}
}
