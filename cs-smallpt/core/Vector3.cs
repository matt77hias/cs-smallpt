using System;

namespace cs_smallpt.core
{
	public class Vector3
	{
		protected double[] raw = new double[3];

		public double x
		{
			get
			{
				return raw[0];
			}
			set
			{
				raw[0] = value;
			}
		}
		public double y
		{
			get
			{
				return raw[1];
			}
			set
			{
				raw[1] = value;
			}
		}
		public double z
		{
			get
			{
				return raw[2];
			}
			set
			{
				raw[2] = value;
			}
		}

		public Vector3(double a = 0.0) : this(a, a, a)
		{
		}
		public Vector3(double x, double y, double z)
		{
			raw[0] = x;
			raw[1] = y;
			raw[2] = z;
		}
		public Vector3(Vector3 v) : this(v[0], v[1], v[2])
		{   
		}
		public Vector3 Clone()
		{
			return new Vector3(this);
		}

		public bool HasNaNs()
		{
			return double.IsNaN(raw[0]) || double.IsNaN(raw[1]) || double.IsNaN(raw[2]);
		}

		public double this[int i]
		{
			get
			{
				return raw[i];
			}
			set
			{
				raw[i] = value;
			}
		}
		
		public static Vector3 operator -(Vector3 v)
		{
			return new Vector3(-v[0], -v[1], -v[2]);
		}
		public static Vector3 operator +(Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1[0] + v2[0], v1[1] + v2[1], v1[2] + v2[2]);
		}
		public static Vector3 operator -(Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1[0] - v2[0], v1[1] - v2[1], v1[2] - v2[2]);
		}
		public static Vector3 operator *(Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1[0] * v2[0], v1[1] * v2[1], v1[2] * v2[2]);
		}
		public static Vector3 operator /(Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1[0] / v2[0], v1[1] / v2[1], v1[2] / v2[2]);
		}
		public static Vector3 operator +(Vector3 v, double a)
		{
			return new Vector3(v[0] + a, v[1] + a, v[2] + a);
		}
		public static Vector3 operator -(Vector3 v, double a)
		{
			return new Vector3(v[0] - a, v[1] - a, v[2] - a);
		}
		public static Vector3 operator *(Vector3 v, double a)
		{
			return new Vector3(v[0] * a, v[1] * a, v[2] * a);
		}
		public static Vector3 operator /(Vector3 v, double a)
		{
			double inv_a = 1.0 / a;
			return new Vector3(v[0] * inv_a, v[1] * inv_a, v[2] * inv_a);
		}
		public static Vector3 operator +(double a, Vector3 v)
		{
			return new Vector3(a + v[0], a + v[1], a + v[2]);
		}
		public static Vector3 operator -(double a, Vector3 v)
		{
			return new Vector3(a - v[0], a - v[1], a - v[2]);
		}
		public static Vector3 operator *(double a, Vector3 v)
		{
			return new Vector3(a * v[0], a * v[1], a * v[2]);
		}
		public static Vector3 operator /(double a, Vector3 v)
		{
			return new Vector3(a / v[0], a / v[1], a / v[2]);
		}

		public double Dot(Vector3 v)
		{ 
			return raw[0] * v[0] + raw[1] * v[1] + raw[2] * v[2];
		}
		public Vector3 Cross(Vector3 v)
		{ 
			return new Vector3(raw[1] * v[2] - raw[2] * v[1], raw[2] * v[0] - raw[0] * v[2], raw[0] * v[1] - raw[1] * v[0]);
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			hashCode ^= raw[0].GetHashCode();
			hashCode ^= raw[1].GetHashCode();
			hashCode ^= raw[2].GetHashCode();
			return hashCode;
		}
		public override bool Equals(System.Object obj)
		{
			if (obj == null)
			{
				return false;
			}

			Vector3 v1 = obj as Vector3;
			if ((System.Object)v1 == null)
			{
				return false;
			}

			return (raw[0] == v1[0]) && (raw[1] == v1[1]) && (raw[2] == v1[2]);
		}
		public static bool operator ==(Vector3 v1, Vector3 v2)
		{
			return (v1[0] == v2[0]) && (v1[1] == v2[1]) && (v1[2] == v2[2]);
		}
		public static bool operator !=(Vector3 v1, Vector3 v2)
		{
			return (v1[0] != v2[0]) || (v1[1] != v2[1]) || (v1[2] != v2[2]);
		}
		public static bool operator <(Vector3 v1, Vector3 v2)
		{
			return (v1[0] < v2[0]) && (v1[1] < v2[1]) && (v1[2] < v2[2]);
		}
		public static bool operator <=(Vector3 v1, Vector3 v2)
		{
			return (v1[0] <= v2[0]) && (v1[1] <= v2[1]) && (v1[2] <= v2[2]);
		}
		public static bool operator >(Vector3 v1, Vector3 v2)
		{
			return (v1[0] > v2[0]) && (v1[1] > v2[1]) && (v1[2] > v2[2]);
		}
		public static bool operator >=(Vector3 v1, Vector3 v2)
		{
			return (v1[0] >= v2[0]) && (v1[1] >= v2[1]) && (v1[2] >= v2[2]);
		}

		public static Vector3 Sqrt(Vector3 v)
		{
			return new Vector3(Math.Sqrt(v[0]), Math.Sqrt(v[1]), Math.Sqrt(v[2]));
		}
		public static Vector3 Pow(Vector3 v, double a)
		{
			return new Vector3(Math.Pow(v[0], a), Math.Pow(v[1], a), Math.Pow(v[2], a));
		}
		public static Vector3 Abs(Vector3 v)
		{
			return new Vector3(Math.Abs(v[0]), Math.Abs(v[1]), Math.Abs(v[2]));
		}
		public static Vector3 Min(Vector3 v1, Vector3 v2)
		{
			return new Vector3(Math.Min(v1[0], v2[0]), Math.Min(v1[1], v2[1]), Math.Min(v1[2], v2[2]));
		}
		public static Vector3 Max(Vector3 v1, Vector3 v2)
		{
			return new Vector3(Math.Max(v1[0], v2[0]), Math.Max(v1[1], v2[1]), Math.Max(v1[2], v2[2]));
		}
		public static Vector3 Round(Vector3 v1, Vector3 v2)
		{
			return new Vector3(Math.Round(v1[0]), Math.Round(v1[1]), Math.Round(v1[2]));
		}
		public static Vector3 Floor(Vector3 v1, Vector3 v2)
		{
			return new Vector3(Math.Floor(v1[0]), Math.Floor(v1[1]), Math.Floor(v1[2]));
		}
		public static Vector3 Ceil(Vector3 v1, Vector3 v2)
		{
			return new Vector3(Math.Ceiling(v1[0]), Math.Ceiling(v1[1]), Math.Ceiling(v1[2]));
		}
		public static Vector3 Trunc(Vector3 v1, Vector3 v2)
		{
			return new Vector3(Math.Truncate(v1[0]), Math.Truncate(v1[1]), Math.Truncate(v1[2]));
		}
		public static Vector3 Clamp(Vector3 v, double low = 0.0, double high = 1.0)
		{
			return new Vector3(MathUtils.Clamp(v[0], low, high), MathUtils.Clamp(v[1], low, high), MathUtils.Clamp(v[2], low, high));
		}
		public static Vector3 Lerp(double a, Vector3 v1, Vector3 v2)
		{
			return v1 + a * (v2 - v1);
		}
		public static Vector3 Permute(Vector3 v, int x, int y, int z)
		{
			return new Vector3(v[x], v[y], v[z]);
		}

		public int MinDimension()
		{
			return (raw[0] < raw[1] && raw[0] < raw[2]) ? 0 : ((raw[1] < raw[2]) ? 1 : 2);
		}
		public int MaxDimension()
		{
			return (raw[0] > raw[1] && raw[0] > raw[2]) ? 0 : ((raw[1] > raw[2]) ? 1 : 2);
		}
		public double Min()
		{
			return (raw[0] < raw[1] && raw[0] < raw[2]) ? raw[0] : ((raw[1] < raw[2]) ? raw[1] : raw[2]);
		}
		public double Max()
		{
			return (raw[0] > raw[1] && raw[0] > raw[2]) ? raw[0] : ((raw[1] > raw[2]) ? raw[1] : raw[2]);
		}

		public double Norm2_squared()
		{ 
			return raw[0] * raw[0] + raw[1] * raw[1] + raw[2] * raw[2];
		}
		public double Norm2()
		{ 
			return Math.Sqrt(Norm2_squared());
		}
		public Vector3 Normalize()
		{
			double a = 1.0 / Norm2();
			raw[0] *= a;
			raw[1] *= a;
			raw[2] *= a;
			return this;
		}

		public override string ToString()
		{
			return "[" + raw[0] + ' ' + raw[1] + ' ' + raw[2] + ']';
		}
	}
}
