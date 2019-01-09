using System;
using System.Runtime.CompilerServices;

namespace cs_smallpt {

    public struct Vector3 : IEquatable< Vector3 > {

		public double x;
		public double y;
		public double z;

        public Vector3(double a = 0.0)
			: this(a, a, a) {}

		public Vector3(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

		public Vector3(Vector3 v)
			: this(v.x, v.y, v.z) {}

        public bool HasNaNs() {
            return double.IsNaN(this.x)
				|| double.IsNaN(this.y)
				|| double.IsNaN(this.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator -(Vector3 v) {
            return new Vector3(-v.x, -v.y, -v.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator +(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator -(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator *(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator /(Vector3 v1, Vector3 v2) {
            return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator +(Vector3 v, double a) {
            return new Vector3(v.x + a, v.y + a, v.z + a);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator -(Vector3 v, double a) {
            return new Vector3(v.x - a, v.y - a, v.z - a);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator *(Vector3 v, double a) {
            return new Vector3(v.x * a, v.y * a, v.z * a);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator /(Vector3 v, double a) {
            double inv_a = 1.0 / a;
            return new Vector3(v.x * inv_a, v.y * inv_a, v.z * inv_a);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator +(double a, Vector3 v) {
            return new Vector3(a + v.x, a + v.y, a + v.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator -(double a, Vector3 v) {
            return new Vector3(a - v.x, a - v.y, a - v.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator *(double a, Vector3 v) {
            return new Vector3(a * v.x, a * v.y, a * v.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator /(double a, Vector3 v) {
            return new Vector3(a / v.x, a / v.y, a / v.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Dot(Vector3 v) {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 Cross(Vector3 v) {
            return new Vector3(this.y * v.z - this.z * v.y,
				               this.z * v.x - this.x * v.z,
				               this.x * v.y - this.y * v.x);
        }

		public override int GetHashCode() {
            int hashCode = 0;
            hashCode ^= this.x.GetHashCode();
            hashCode ^= this.y.GetHashCode();
            hashCode ^= this.z.GetHashCode();
            return hashCode;
        }

		public override bool Equals(System.Object obj) {
            if (obj == null) {
                return false;
            }

			return Equals((Vector3)obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Vector3 v) {
            return (this.x == v.x) && (this.y == v.y) && (this.z == v.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Vector3 v1, Vector3 v2) {
            return (v1.x == v2.x) && (v1.y == v2.y) && (v1.z == v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Vector3 v1, Vector3 v2) {
            return (v1.x != v2.x) || (v1.y != v2.y) || (v1.z != v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <(Vector3 v1, Vector3 v2) {
            return (v1.x < v2.x) && (v1.y < v2.y) && (v1.z < v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <=(Vector3 v1, Vector3 v2) {
            return (v1.x <= v2.x) && (v1.y <= v2.y) && (v1.z <= v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >(Vector3 v1, Vector3 v2) {
            return (v1.x > v2.x) && (v1.y > v2.y) && (v1.z > v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >=(Vector3 v1, Vector3 v2) {
            return (v1.x >= v2.x) && (v1.y >= v2.y) && (v1.z >= v2.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Sqrt(Vector3 v) {
            return new Vector3(Math.Sqrt(v.x), Math.Sqrt(v.y), Math.Sqrt(v.z));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Pow(Vector3 v, double a) {
            return new Vector3(Math.Pow(v.x, a),
				               Math.Pow(v.y, a),
							   Math.Pow(v.z, a));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Abs(Vector3 v) {
            return new Vector3(Math.Abs(v.x),
				              Math.Abs(v.y),
							  Math.Abs(v.z));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Min(Vector3 v1, Vector3 v2) {
            return new Vector3(Math.Min(v1.x, v2.x),
				               Math.Min(v1.y, v2.y),
							   Math.Min(v1.z, v2.z));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Max(Vector3 v1, Vector3 v2) {
            return new Vector3(Math.Max(v1.x, v2.x),
				               Math.Max(v1.y, v2.y),
							   Math.Max(v1.z, v2.z));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Round(Vector3 v1, Vector3 v2) {
            return new Vector3(Math.Round(v1.x),
				               Math.Round(v1.y),
				               Math.Round(v1.z));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Floor(Vector3 v1, Vector3 v2) {
            return new Vector3(Math.Floor(v1.x),
				               Math.Floor(v1.y),
							   Math.Floor(v1.z));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Ceil(Vector3 v1, Vector3 v2) {
            return new Vector3(Math.Ceiling(v1.x),
				               Math.Ceiling(v1.y),
							   Math.Ceiling(v1.z));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Trunc(Vector3 v1, Vector3 v2) {
            return new Vector3(Math.Truncate(v1.x),
				               Math.Truncate(v1.y),
							   Math.Truncate(v1.z));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Clamp(Vector3 v, double low = 0.0, double high = 1.0) {
            return new Vector3(MathUtils.Clamp(v.x, low, high),
				               MathUtils.Clamp(v.y, low, high),
							   MathUtils.Clamp(v.z, low, high));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Lerp(double a, Vector3 v1, Vector3 v2) {
            return v1 + a * (v2 - v1);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int MinDimension() {
            return (this.x < this.y && this.x < this.z) ? 0 : ((this.y < this.z) ? 1 : 2);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int MaxDimension() {
            return (this.x > this.y && this.x > this.z) ? 0 : ((this.y > this.z) ? 1 : 2);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Min() {
            return (this.x < this.y && this.x < this.z) ? this.x : ((this.y < this.z) ? this.y : this.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Max() {
            return (this.x > this.y && this.x > this.z) ? this.x : ((this.y > this.z) ? this.y : this.z);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Norm2_squared() {
            return this.x * this.x + this.y * this.y + this.z * this.z;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Norm2() {
            return Math.Sqrt(Norm2_squared());
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 Normalize() {
            double a = 1.0 / Norm2();
            this.x *= a;
            this.y *= a;
            this.z *= a;
            return this;
        }

        public override string ToString() {
            return "[" + this.x + ' ' + this.y + ' ' + this.z + ']';
        }
    }
}
