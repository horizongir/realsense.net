﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a vector with three components.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3 : IEquatable<Vector3>
    {
        /// <summary>
        /// Represents a <see cref="Vector3"/> with ones in all of its components.
        /// </summary>
        public static readonly Vector3 One = new Vector3(1, 1, 1);

        /// <summary>
        /// Represents a <see cref="Vector3"/> with all of its components set to zero.
        /// </summary>
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        /// <summary>
        /// Represents a unit-length <see cref="Vector3"/> that points towards the X axis.
        /// </summary>
        public static readonly Vector3 UnitX = new Vector3(1, 0, 0);

        /// <summary>
        /// Represents a unit-length <see cref="Vector3"/> that points towards the Y axis.
        /// </summary>
        public static readonly Vector3 UnitY = new Vector3(0, 1, 0);

        /// <summary>
        /// Represents a unit-length <see cref="Vector3"/> that points towards the Z axis.
        /// </summary>
        public static readonly Vector3 UnitZ = new Vector3(0, 0, 1);

        /// <summary>
        /// Specifies the x-component of the vector.
        /// </summary>
        public float X;

        /// <summary>
        /// Specifies the y-component of the vector.
        /// </summary>
        public float Y;

        /// <summary>
        /// Specifies the z-component of the vector.
        /// </summary>
        public float Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> structure
        /// with all components set to the same value.
        /// </summary>
        /// <param name="value">The value to initialize each component to.</param>
        public Vector3(float value)
        {
            X = Y = Z = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> structure
        /// with the specified component values.
        /// </summary>
        /// <param name="x">The value of the x-component of the vector.</param>
        /// <param name="y">The value of the y-component of the vector.</param>
        /// <param name="z">The value of the z-component of the vector.</param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="Vector3"/> value.
        /// </summary>
        /// <param name="other">A <see cref="Vector3"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same X, Y and Z components as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Vector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="Vector3"/> and
        /// has the same X, Y and Z components as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector3)
            {
                return Equals((Vector3)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of the X, Y and Z components of this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", X, Y, Z);
        }

        /// <summary>
        /// Returns a new vector pointing in the opposite direction of the
        /// source vector.
        /// </summary>
        /// <param name="value">The source vector.</param>
        /// <returns>A vector pointing in the opposite direction of the source vector.</returns>
        public static Vector3 Negate(Vector3 value)
        {
            Negate(ref value, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Returns a new vector pointing in the opposite direction of the
        /// source vector.
        /// </summary>
        /// <param name="value">The source vector.</param>
        /// <param name="result">A vector pointing in the opposite direction of the source vector.</param>
        public static void Negate(ref Vector3 value, out Vector3 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
        }

        /// <summary>
        /// Adds two vectors and returns the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The first vector to add.</param>
        /// <param name="value2">The second vector to add.</param>
        /// <returns>The sum of the two vectors.</returns>
        public static Vector3 Add(Vector3 value1, Vector3 value2)
        {
            Add(ref value1, ref value2, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Adds two vectors and returns the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The first vector to add.</param>
        /// <param name="value2">The second vector to add.</param>
        /// <param name="result">The sum of the two vectors.</param>
        public static void Add(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        /// <summary>
        /// Subtracts a vector from another vector and returns the result as a new
        /// <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The vector from which the other vector will be subtracted.</param>
        /// <param name="value2">The vector that is to be subtracted.</param>
        /// <returns>The result of the subtraction.</returns>
        public static Vector3 Subtract(Vector3 value1, Vector3 value2)
        {
            Subtract(ref value1, ref value2, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Subtracts a vector from another vector and returns the result as a new
        /// <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The vector from which the other vector will be subtracted.</param>
        /// <param name="value2">The vector that is to be subtracted.</param>
        /// <param name="result">The result of the subtraction.</param>
        public static void Subtract(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
        }

        /// <summary>
        /// Multiplies a vector by a scalar value and returns the result as
        /// a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The source vector.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The result of the multiplication.</returns>
        public static Vector3 Multiply(Vector3 value1, float value2)
        {
            Multiply(ref value1, value2, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Multiplies a vector by a scalar value and returns the result as
        /// a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The source vector.</param>
        /// <param name="value2">The scalar value.</param>
        /// <param name="result">The result of the multiplication.</param>
        public static void Multiply(ref Vector3 value1, float value2, out Vector3 result)
        {
            result.X = value1.X * value2;
            result.Y = value1.Y * value2;
            result.Z = value1.Z * value2;
        }

        /// <summary>
        /// Multiplies the components of two vectors by each other and returns
        /// the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The first vector to multiply the components of.</param>
        /// <param name="value2">The second vector to multiply the components of.</param>
        /// <returns>The result of the multiplication.</returns>
        public static Vector3 Multiply(Vector3 value1, Vector3 value2)
        {
            Multiply(ref value1, ref value2, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Multiplies the components of two vectors by each other and returns
        /// the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The first vector to multiply the components of.</param>
        /// <param name="value2">The second vector to multiply the components of.</param>
        /// <param name="result">The result of the multiplication.</param>
        public static void Multiply(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        /// <summary>
        /// Divides a vector by a scalar value and returns the result as
        /// a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The source vector.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The result of the division.</returns>
        public static Vector3 Divide(Vector3 value1, float value2)
        {
            Divide(ref value1, value2, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Divides a vector by a scalar value and returns the result as
        /// a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The source vector.</param>
        /// <param name="value2">The scalar value.</param>
        /// <param name="result">The result of the division.</param>
        public static void Divide(ref Vector3 value1, float value2, out Vector3 result)
        {
            result.X = value1.X / value2;
            result.Y = value1.Y / value2;
            result.Z = value1.Z / value2;
        }

        /// <summary>
        /// Divides the components of a vector by the components of another vector
        /// and returns the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The vector whose components will be divided.</param>
        /// <param name="value2">The divisor vector.</param>
        /// <returns>The result of the division.</returns>
        public static Vector3 Divide(Vector3 value1, Vector3 value2)
        {
            Divide(ref value1, ref value2, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Divides the components of a vector by the components of another vector
        /// and returns the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value1">The vector whose components will be divided.</param>
        /// <param name="value2">The divisor vector.</param>
        /// <param name="result">The result of the division.</param>
        public static void Divide(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="value1">The first source vector.</param>
        /// <param name="value2">The second source vector.</param>
        /// <returns>The dot product of the two source vectors.</returns>
        public static float Dot(Vector3 value1, Vector3 value2)
        {
            Dot(ref value1, ref value2, out float result);
            return result;
        }

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="value1">The first source vector.</param>
        /// <param name="value2">The second source vector.</param>
        /// <param name="result">The dot product of the two source vectors.</param>
        public static void Dot(ref Vector3 value1, ref Vector3 value2, out float result)
        {
            result = value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;
        }

        /// <summary>
        /// Tests whether two <see cref="Vector3"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// equal X, Y and Z components; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Vector3"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in X, Y or Z components; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a new vector pointing in the opposite direction of the
        /// source vector.
        /// </summary>
        /// <param name="value">The source vector.</param>
        /// <returns>A vector pointing in the opposite direction of the source vector.</returns>
        public static Vector3 operator -(Vector3 value)
        {
            Negate(ref value, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Adds two vectors and returns the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the addition operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the addition operator.
        /// </param>
        /// <returns>The sum of the two vectors.</returns>
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            Add(ref left, ref right, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Subtracts a vector from another vector and returns the result as a new
        /// <see cref="Vector3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the subtraction operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the subtraction operator.
        /// </param>
        /// <returns>The result of the subtraction.</returns>
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            Subtract(ref left, ref right, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Multiplies a vector by a scalar value and returns the result as
        /// a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="left">
        /// The scalar value on the left of the multiplication operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the multiplication operator.
        /// </param>
        /// <returns>The result of the multiplication.</returns>
        public static Vector3 operator *(float left, Vector3 right)
        {
            Multiply(ref right, left, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Multiplies a vector by a scalar value and returns the result as
        /// a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the multiplication operator.
        /// </param>
        /// <param name="right">
        /// The scalar value on the right of the multiplication operator.
        /// </param>
        /// <returns>The result of the multiplication.</returns>
        public static Vector3 operator *(Vector3 left, float right)
        {
            Multiply(ref left, right, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Multiplies the components of two vectors by each other and returns
        /// the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the multiplication operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the multiplication operator.
        /// </param>
        /// <returns>The result of the multiplication.</returns>
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            Multiply(ref left, ref right, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Divides a vector by a scalar value and returns the result as
        /// a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the division operator.
        /// </param>
        /// <param name="right">
        /// The scalar value on the right of the division operator.
        /// </param>
        /// <returns>The result of the division.</returns>
        public static Vector3 operator /(Vector3 left, float right)
        {
            Divide(ref left, right, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Divides the components of a vector by the components of another vector
        /// and returns the result as a new <see cref="Vector3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the division operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the division operator.
        /// </param>
        /// <returns>The result of the division.</returns>
        public static Vector3 operator /(Vector3 left, Vector3 right)
        {
            Divide(ref left, ref right, out Vector3 result);
            return result;
        }
    }
}
