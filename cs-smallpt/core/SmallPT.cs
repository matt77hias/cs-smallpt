using System;

namespace cs_smallpt {

	static class SmallPT {

		static void Main(string[] args) {
			RNG rng = new RNG();
			int nb_samples = (args.Length > 0) ? int.Parse(args[0]) / 4 : 1;

			const int w = 1024;
			const int h = 768;

			Vector3 eye = new Vector3(50, 52, 295.6);
			Vector3 gaze = new Vector3(0, -0.042612, -1).Normalize();
			const double fov = 0.5135;
			Vector3 cx = new Vector3(w * fov / h, 0.0, 0.0);
			Vector3 cy = (cx.Cross(gaze)).Normalize() * fov;

			Vector3[] Ls = new Vector3[w * h];
			for (int i = 0; i < w * h; ++i) {
				Ls[i] = new Vector3();
			}

			for (int y = 0; y < h; ++y) {
				// pixel row
				Console.Write("\rRendering ({0} spp) {1:0.00}%", nb_samples * 4, 100.0 * y / (h - 1));
				for (int x = 0; x < w; ++x) {
					// pixel column
					for (int sy = 0, i = (h - 1 - y) * w + x; sy < 2; ++sy) {
						// 2 subpixel row
						for (int sx = 0; sx < 2; ++sx) {
							// 2 subpixel column
							Vector3 L = new Vector3();
							for (int s = 0; s < nb_samples; ++s) {
								// samples per subpixel
								double u1 = 2.0 * rng.UniformFloat();
								double u2 = 2.0 * rng.UniformFloat();
								double dx = u1 < 1 ? Math.Sqrt(u1) - 1.0 : 1.0 - Math.Sqrt(2.0 - u1);
								double dy = u2 < 1 ? Math.Sqrt(u2) - 1.0 : 1.0 - Math.Sqrt(2.0 - u2);
								Vector3 d = cx * (((sx + 0.5 + dx) / 2 + x) / w - 0.5) +
											cy * (((sy + 0.5 + dy) / 2 + y) / h - 0.5) + gaze;
								L += Radiance(new Ray(eye + d * 130, d.Normalize(), Sphere.EPSILON_SPHERE), rng) * (1.0 / nb_samples);
							}
							Ls[i] += 0.25 * Vector3.Clamp(L);
						}
					}
				}
			}

			ImageIO.WritePPM(w, h, Ls);
		}

		// Scene
		public const double REFRACTIVE_INDEX_OUT = 1.0;
		public const double REFRACTIVE_INDEX_IN  = 1.5;

		public static readonly Sphere[] spheres =
		{
			new Sphere(1e5,  new Vector3(1e5 + 1, 40.8, 81.6),   new Vector3(),   new Vector3(0.75,0.25,0.25), Sphere.Reflection_t.DIFFUSE),    //Left
			new Sphere(1e5,  new Vector3(-1e5 + 99, 40.8, 81.6), new Vector3(),   new Vector3(0.25,0.25,0.75), Sphere.Reflection_t.DIFFUSE),	//Right
			new Sphere(1e5,  new Vector3(50, 40.8, 1e5),         new Vector3(),   new Vector3(0.75),           Sphere.Reflection_t.DIFFUSE),	//Back
			new Sphere(1e5,  new Vector3(50, 40.8, -1e5 + 170),  new Vector3(),   new Vector3(),               Sphere.Reflection_t.DIFFUSE),	//Front
			new Sphere(1e5,  new Vector3(50, 1e5, 81.6),         new Vector3(),   new Vector3(0.75),           Sphere.Reflection_t.DIFFUSE),    //Bottom
			new Sphere(1e5,  new Vector3(50, -1e5 + 81.6, 81.6), new Vector3(),   new Vector3(0.75),           Sphere.Reflection_t.DIFFUSE),	//Top
			new Sphere(16.5, new Vector3(27, 16.5, 47),          new Vector3(),   new Vector3(0.999),          Sphere.Reflection_t.SPECULAR),	//Mirror
			new Sphere(16.5, new Vector3(73, 16.5, 78),          new Vector3(),   new Vector3(0.999),          Sphere.Reflection_t.REFRACTIVE),	//Glass
			new Sphere(600,  new Vector3(50, 681.6 - .27, 81.6), new Vector3(12), new Vector3(),               Sphere.Reflection_t.DIFFUSE)		//Light
		};

		public static bool Intersect(Ray ray, out int id) {
			id = 0;
			bool hit = false;
			for (int i = 0; i < spheres.Length; ++i) {
				if (spheres[i].Intersect(ray)) {
					hit = true;
					id = i;
				}
			}
			return hit;
		}

		public static bool Intersect(Ray ray) {
			for (int i = 0; i < spheres.Length; ++i) {
				if (spheres[i].Intersect(ray)) {
					return true;
				}
			}
			return false;
		}

		public static Vector3 Radiance(Ray ray, RNG rng) {
			Ray r = ray;
			Vector3 L = new Vector3();
			Vector3 F = new Vector3(1.0);

			while (true) {
				int id;
				if (!Intersect(r, out id)) {
					return L;
				}

				Sphere shape = spheres[id];
				Vector3 p = r.Eval(r.tmax);
				Vector3 n = (p - shape.p).Normalize();

				L += F * shape.e;
				F *= shape.f;

				// Russian roulette
				if (r.depth > 4) {
					double continue_probability = shape.f.Max();
					if (rng.UniformFloat() >= continue_probability) {
						return L;
					}
					F /= continue_probability;
				}

				// Next path segment
				switch (shape.reflection_t) {
					case Sphere.Reflection_t.SPECULAR: {
							Vector3 d = Specular.IdealSpecularReflect(r.d, n);
							r = new Ray(p, d, Sphere.EPSILON_SPHERE, double.PositiveInfinity, r.depth + 1);
							break;
						}
					case Sphere.Reflection_t.REFRACTIVE: {
							double pr;
							Vector3 d = Specular.IdealSpecularTransmit(r.d, n, REFRACTIVE_INDEX_OUT, REFRACTIVE_INDEX_IN, out pr, rng);
							F *= pr;
							r = new Ray(p, d, Sphere.EPSILON_SPHERE, double.PositiveInfinity, r.depth + 1);
							break;
						}
					default: {
							Vector3 w = n.Dot(r.d) < 0 ? n : -n;
							Vector3 u = ((Math.Abs(w.x) > 0.1 ? new Vector3(0.0, 1.0, 0.0) : new Vector3(1.0, 0.0, 0.0)).Cross(w)).Normalize();
							Vector3 v = w.Cross(u);

							Vector3 sample_d = Sampling.CosineWeightedSampleOnHemisphere(rng.UniformFloat(), rng.UniformFloat());
							Vector3 d = (sample_d.x * u + sample_d.y * v + sample_d.z * w).Normalize();
							r = new Ray(p, d, Sphere.EPSILON_SPHERE, double.PositiveInfinity, r.depth + 1);
							break;
						}
				}
			}
		}
	}
}
