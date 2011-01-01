// 
// Vector4.cs
//  
// Author:
//       Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (c) 2010 Novell, Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Runtime.InteropServices;

#if SIMD
using Mono.Simd;
#endif

namespace Mono.GameMath
{
	[Serializable]
	public struct Vector4 : IEquatable<Vector4>
	{
#if SIMD
		internal Vector4f v4;
		public float X { get { return v4.X; } set { v4.X = value; } }
		public float Y { get { return v4.Y; } set { v4.Y = value; } }
		public float Z { get { return v4.Z; } set { v4.Z = value; } }
		public float W { get { return v4.W; } set { v4.W = value; } }
		Vector4 (Vector4f v4) { this.v4 = v4; }
#else
		internal float x, y, z, w;
		public float X { get { return x; } set { x = value; } }
		public float Y { get { return y; } set { y = value; } }
		public float Z { get { return z; } set { z = value; } }
		public float W { get { return w; } set { w = value; } }
#endif
		
		#region Constructors
		
		public Vector4 (float value)
#if SIMD
		{
			v4 = new Vector4f (value);
		}
#else
		: this (value, value, value, value)
		{
		}
#endif
		
		public Vector4 (Vector2 value, float z, float w) : this (value.X, value.Y, z, w)
		{
		}
		
		public Vector4 (Vector3 value, float z, float w) : this (value.X, value.Y, value.Z, w)
		{
		}
		
		public Vector4 (float x, float y, float z, float w)
		{
#if SIMD
			v4 = new Vector4f (x, y, z, w);
#else
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
#endif
		}
		
		#endregion
		
		#region Static properties
		
		public static Vector4 UnitX {
			get { return new Vector4 (1f, 0f, 0f, 0f); }
		}
		
		public static Vector4 UnitY {
			get { return new Vector4 (0f, 1f, 0f, 0f); }
		}
		
		public static Vector4 UnitZ {
			get { return new Vector4 (0f, 0f, 1f, 0f); }
		}
		
		public static Vector4 UnitW {
			get { return new Vector4 (0f, 0f, 0f, 1f); }
		}
		
		public static Vector4 One {
			get { return new Vector4 (1f); }
		}
		
		public static Vector4 Zero {
			get { return new Vector4 (0f); }
		}
		
		#endregion
		
		#region Arithmetic
		
		public static Vector4 Add (Vector4 value1, Vector4 value2)
		{
#if SIMD
			return new Vector4 (value1.v4 + value2.v4);
#else
			return new Vector4 (value1.X + value2.X, value1.Y + value2.Y, value1.Z + value2.Z, value1.W + value2.W);
#endif
		}
		
		public static void Add (ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
#if SIMD
			result.v4 = value1.v4 + value2.v4;
#else
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
			result.W = value1.W + value2.W;
#endif
		}
		
		public static Vector4 Divide (Vector4 value1, float value2)
		{
#if SIMD
			return new Vector4 (value1.v4 / new Vector4f (value2));
#else
			return new Vector4 (value1.X / value2, value1.Y / value2, value1.Z / value2, value1.W / value2);
#endif
		}
		
		public static void Divide (ref Vector4 value1, float divider, out Vector4 result)
		{
#if SIMD
			result.v4 = value1.v4 / new Vector4f (divider);
#else
			result.X = value1.X / divider;
			result.Y = value1.Y / divider;
			result.Z = value1.Z / divider;
			result.W = value1.W / divider;
#endif
		}
		
		public static Vector4 Divide (Vector4 value1, Vector4 value2)
		{
#if SIMD
			return new Vector4 (value1.v4 / value2.v4);
#else
			return new Vector4 (value1.X / value2.X, value1.Y / value2.Y, value1.Z / value2.Z, value1.W / value2.W);
#endif
		}
		
		public static void Divide (ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
#if SIMD
			result.v4 = value1.v4 / value2.v4;
#else
			result.X = value1.X / value2.X;
			result.Y = value1.Y / value2.Y;
			result.Z = value1.Z / value2.Z;
			result.W = value1.W / value2.W;
#endif
		}
		
		public static Vector4 Multiply (Vector4 value1, float scaleFactor)
		{
#if SIMD
			return new Vector4 (value1.v4 * new Vector4f (scaleFactor));
#else
			return new Vector4 (value1.X * scaleFactor, value1.Y * scaleFactor, value1.Z * scaleFactor, value1.W * scaleFactor);
#endif
		}
		
		public static void Multiply (ref Vector4 value1, float scaleFactor, out Vector4 result)
		{
#if SIMD
			result.v4 = value1.v4 * new Vector4f (scaleFactor);
#else
			result.X = value1.X * scaleFactor;
			result.Y = value1.Y * scaleFactor;
			result.Z = value1.Z * scaleFactor;
			result.W = value1.W * scaleFactor;
#endif
		}
		
		public static Vector4 Multiply (Vector4 value1, Vector4 value2)
		{
#if SIMD
		return new Vector4 (value1.v4 * value2.v4);	
#else
		return new Vector4 (value1.X * value2.X, value1.Y * value2.Y, value1.Z * value2.Z, value1.W * value2.W);
#endif
		}
		
		public static void Multiply (ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
#if SIMD
			result.v4 = value1.v4 * value2.v4;
#else
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.Y;
			result.Z = value1.Z * value2.Z;
			result.W = value1.W * value2.W;
#endif
		}
		
		public static Vector4 Negate (Vector4 value)
		{
#if SIMD
			return new Vector4 (value.v4 ^ new Vector4f (-0.0f));
#else
			return new Vector4 (- value.X, - value.Y, - value.Z, - value.W);
#endif
		}
		
		public static void Negate (ref Vector4 value, out Vector4 result)
		{
#if SIMD
			result.v4 = value.v4 ^ new Vector4f (-0.0f);
#else
			result.X = - value.X;
			result.Y = - value.Y;
			result.Z = - value.Z;
			result.W = - value.W;
#endif
		}
		
		public static Vector4 Subtract (Vector4 value1, Vector4 value2)
		{
#if SIMD
			return new Vector4 (value1.v4 - value2.v4);
#else
			return new Vector4 (value1.X - value2.X, value1.Y - value2.Y, value1.Z - value2.Z, value1.W - value2.W);
#endif
		}
		
		public static void Subtract (ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
#if SIMD
			result.v4 = value1.v4 - value2.v4;
#else
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
			result.W = value1.W - value2.W;
#endif
		}
		
		#endregion
		
		#region Operator overloads
		
		public static Vector4 operator + (Vector4 value1, Vector4 value2)
		{
			return Add (value1, value2);
		}
		
		public static Vector4 operator / (Vector4 value, float divider)
		{
			return Divide (value, divider);
		}
		
		public static Vector4 operator / (Vector4 value1, Vector4 value2)
		{
			return Divide (value1, value2);
		}
		
		public static Vector4 operator * (Vector4 value1, Vector4 value2)
		{
			return Multiply (value1, value2);
		}
		
		public static Vector4 operator * (Vector4 value1, float scaleFactor)
		{
			return Multiply (value1, scaleFactor);
		}
		
		public static Vector4 operator * (float scaleFactor, Vector4 value1)
		{
			return Multiply (value1, scaleFactor);
		}
		
		public static Vector4 operator - (Vector4 value1, Vector4 value2)
		{
			return Subtract (value1, value2);
		}
		
		public static Vector4 operator - (Vector4 value)
		{
			return Negate (value);
		}
		
		#endregion
		
		#region Interpolation
		
		public static Vector4 CatmullRom (Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, float amount)
		{
			CatmullRom (ref value1, ref value2, ref value3, ref value4, amount, out value1);
			return value1;
		}
		
		public static void CatmullRom (ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4,
			float amount, out Vector4 result)
		{
			//FIXME: probably more efficient to share work between values
			result.X = MathHelper.CatmullRom (value1.X, value2.X, value3.X, value4.X, amount);
			result.Y = MathHelper.CatmullRom (value1.Y, value2.Y, value3.Y, value4.Y, amount);
			result.Z = MathHelper.CatmullRom (value1.Z, value2.Z, value3.Z, value4.Z, amount);
			result.W = MathHelper.CatmullRom (value1.W, value2.W, value3.W, value4.W, amount);
		}
		
		public static Vector4 Hermite (Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float amount)
		{
			Hermite (ref value1, ref tangent1, ref value2, ref tangent2, amount, out value1);
			return value1;
		}
		
		public static void Hermite (ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2,
			float amount, out Vector4 result)
		{
			//FIXME: probably more efficient to share work between values
			result.X = MathHelper.Hermite (value1.X, tangent1.X, value2.X, tangent2.X, amount);
			result.Y = MathHelper.Hermite (value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
			result.Z = MathHelper.Hermite (value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
			result.W = MathHelper.Hermite (value1.W, tangent1.W, value2.W, tangent2.W, amount);
		}
		
		public static Vector4 Lerp (Vector4 value1, Vector4 value2, float amount)
		{
			Lerp (ref value1, ref value2, amount, out value1);
			return value1;
		}
		
		public static void Lerp (ref Vector4 value1, ref Vector4 value2, float amount, out Vector4 result)
		{
			Subtract (ref value2, ref value1, out result);
			Multiply (ref result, amount, out result);
			Add (ref value1, ref result, out result);
		}
		
		public static Vector4 SmoothStep (Vector4 value1, Vector4 value2, float amount)
		{
			SmoothStep (ref value1, ref value2, amount, out value1);
			return value1;
		}
		
		public static void SmoothStep (ref Vector4 value1, ref Vector4 value2, float amount, out Vector4 result)
		{
			float scale = (amount * amount * (3 - 2 * amount));
			Subtract (ref value2, ref value1, out result);
			Multiply (ref result, scale, out result);
			Add (ref value1, ref result, out result);
		}
		
		#endregion
		
		#region Other maths
		
		public static Vector4 Barycentric (Vector4 value1, Vector4 value2, Vector4 value3, float amount1, float amount2)
		{
			Barycentric (ref value1, ref value2, ref value3, amount1, amount2, out value1);
			return value1;
		}
		
		public static void Barycentric (ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, float amount1,
			float amount2, out Vector4 result)
		{
			//FIXME: probably more efficient to share work between values
			result.X = MathHelper.Barycentric (value1.X, value2.X, value3.X, amount1, amount2);
			result.Y = MathHelper.Barycentric (value1.Y, value2.Y, value3.Y, amount1, amount2);
			result.Z = MathHelper.Barycentric (value1.Z, value2.Z, value3.Z, amount1, amount2);
			result.W = MathHelper.Barycentric (value1.W, value2.W, value3.W, amount1, amount2);
		}
		
		public static Vector4 Clamp (Vector4 value1, Vector4 min, Vector4 max)
		{
			Clamp (ref value1, ref min, ref max, out value1);
			return value1;
		}
		
		public static void Clamp (ref Vector4 value1, ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			result.X = MathHelper.Clamp (value1.X, min.X, max.X);
			result.Y = MathHelper.Clamp (value1.Y, min.Y, max.Y);
			result.Z = MathHelper.Clamp (value1.Z, min.Z, max.Z);
			result.W = MathHelper.Clamp (value1.W, min.W, max.W);
		}
		
		public static float Distance (Vector4 value1, Vector4 value2)
		{
			float result;
			Distance (ref value1, ref value2, out result);
			return result;
		}
		
		public static void Distance (ref Vector4 value1, ref Vector4 value2, out float result)
		{
			DistanceSquared (ref value1, ref value2, out result);
			result = (float) System.Math.Sqrt (result);
		}
		
		public static float DistanceSquared (Vector4 value1, Vector4 value2)
		{
			float result;
			DistanceSquared (ref value1, ref value2, out result);
			return result;
		}
		
		public static void DistanceSquared (ref Vector4 value1, ref Vector4 value2, out float result)
		{
			Subtract (ref value1, ref value2, out value1);
			result = value1.LengthSquared ();
		}
		
		public static float Dot (Vector4 vector1, Vector4 vector2)
		{
			float result;
			Dot (ref vector1, ref vector2, out result);
			return result;
		}
		
		public static void Dot (ref Vector4 vector1, ref Vector4 vector2, out float result)
		{
			result = (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z) + (vector1.W * vector2.W);
		}
		
		public float Length ()
		{
			return (float) System.Math.Sqrt (LengthSquared ());
		}
		
		public float LengthSquared ()
		{
			return (X * X) + (Y * Y) + (Z * Z) + (W * W);
		}
		
		public static Vector4 Max (Vector4 value1, Vector4 value2)
		{
			Max (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Max (ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.X = System.Math.Max (value1.X, value2.X);
			result.Y = System.Math.Max (value1.Y, value2.Y);
			result.Z = System.Math.Max (value1.Z, value2.Z);
			result.W = System.Math.Max (value1.W, value2.W);
		}
		
		public static Vector4 Min (Vector4 value1, Vector4 value2)
		{
			Min (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Min (ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.X = System.Math.Min (value1.X, value2.X);
			result.Y = System.Math.Min (value1.Y, value2.Y);
			result.Z = System.Math.Min (value1.Z, value2.Z);
			result.W = System.Math.Min (value1.W, value2.W);
		}
		
		public void Normalize ()
		{
			Normalize (ref this, out this);
		}
		
		public static Vector4 Normalize (Vector4 value)
		{
			value.Normalize ();
			return value;
		}
		
		public static void Normalize (ref Vector4 value, out Vector4 result)
		{
			Multiply (ref value, 1f / value.Length (), out result);
		}
		
		#endregion
		
		#region Transform
		
		public static Vector4 Transform (Vector2 position, Matrix matrix)
		{
			Vector4 result;
			Transform (ref position, ref matrix, out result);
			return result;
		}
		
		public static void Transform (ref Vector2 position, ref Matrix matrix, out Vector4 result)
		{
			throw new NotImplementedException ();
		}
		
		public static Vector4 Transform (Vector2 value, Quaternion rotation)
		{
			Vector4 result;
			Transform (ref value, ref rotation, out result);
			return result;
		}
		
		public static void Transform (ref Vector2 value, ref Quaternion rotation, out Vector4 result)
		{
			throw new NotImplementedException ();
		}
		
		public static Vector4 Transform (Vector3 position, Matrix matrix)
		{
			Vector4 result;
			Transform (ref position, ref matrix, out result);
			return result;
		}
		
		public static void Transform (ref Vector3 position, ref Matrix matrix, out Vector4 result)
		{
			throw new NotImplementedException ();
		}
		
		public static Vector4 Transform (Vector3 value, Quaternion rotation)
		{
			Vector4 result;
			Transform (ref value, ref rotation, out result);
			return result;
		}
		
		public static void Transform (ref Vector3 value, ref Quaternion rotation, out Vector4 result)
		{
			throw new NotImplementedException ();
		}
		
		public static Vector4 Transform (Vector4 position, Matrix matrix)
		{
			Vector4 result;
			Transform (ref position, ref matrix, out result);
			return result;
		}
		
		public static void Transform (ref Vector4 position, ref Matrix matrix, out Vector4 result)
		{
			throw new NotImplementedException ();
		}
		
		public static Vector4 Transform (Vector4 value, Quaternion rotation)
		{
			Vector4 result;
			Transform (ref value, ref rotation, out result);
			return result;
		}
		
		public static void Transform (ref Vector4 value, ref Quaternion rotation, out Vector4 result)
		{
			throw new NotImplementedException ();
		}
		
		static void CheckArrayArgs (Vector4[] sourceArray, int sourceIndex, Vector4[] destinationArray,
			int destinationIndex, int length)
		{
			if (sourceArray == null)
				throw new ArgumentNullException ("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException ("destinationArray");
			if (sourceIndex + length > sourceArray.Length)
				throw new ArgumentException ("Source is smaller than specified length and index");
			if (destinationIndex + length > destinationArray.Length)
				throw new ArgumentException ("Destination is smaller than specified length and index");
		}
		
		static void CheckArrayArgs (Vector4[] sourceArray, Vector4[] destinationArray)
		{
			if (sourceArray == null)
				throw new ArgumentNullException ("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException ("destinationArray");
			if (destinationArray.Length < sourceArray.Length)
				throw new ArgumentException ("Destination is smaller than source", "destinationArray");
		}
		
		public static void Transform (Vector4[] sourceArray, int sourceIndex, ref Matrix matrix,
			Vector4[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				Transform (ref sourceArray[s], ref matrix, out destinationArray[d]);
		}
		
		public static void Transform (Vector4[] sourceArray, int sourceIndex, ref Quaternion rotation,
			Vector4[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				Transform (ref sourceArray[s], ref rotation, out destinationArray[d]);
		}
		
		public static void Transform (Vector4[] sourceArray, ref Matrix matrix, Vector4[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				Transform (ref sourceArray[i], ref matrix, out destinationArray[i]);
		}
		
		public static void Transform (Vector4[] sourceArray, ref Quaternion rotation, Vector4[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				Transform (ref sourceArray[i], ref rotation, out destinationArray[i]);
		}
		
		#endregion
		
		#region Equality
		
		public bool Equals (Vector4 other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is Vector4 && ((Vector4)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return X.GetHashCode () ^ Y.GetHashCode () ^ Z.GetHashCode () ^ W.GetHashCode ();
		}
		
		public static bool operator == (Vector4 a, Vector4 b)
		{
			return a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;
		}
		
		public static bool operator != (Vector4 a, Vector4 b)
		{
			return a.X != b.X || a.Y != b.Y || a.Z != b.Z || a.W != b.W;
		}
		
		# endregion
		
		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}

