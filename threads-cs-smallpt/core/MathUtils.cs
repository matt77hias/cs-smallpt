using System;
using System.Runtime.CompilerServices;

namespace cs_smallpt {

    public static class MathUtils {

        public const double M_PI = 3.14159265358979323846;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Clamp(double x, double low = 0.0, double high = 1.0) {
            return (x < high) ? ((x > low) ? x : low) : high;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte ToByte(double x, double gamma = 2.2) {
            return (byte)Clamp(255.0 * Math.Pow(x, 1 / gamma), 0.0, 255.0);
        }
    }
}
