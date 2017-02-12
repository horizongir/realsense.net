using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a 3x3 matrix in column-major order.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3 : IEquatable<Matrix3>
    {
        /// <summary>
        /// Represents the identity matrix.
        /// </summary>
        public static readonly Matrix3 Identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);

        /// <summary>
        /// Specifies the first column of the matrix.
        /// </summary>
        public Vector3 Column1;

        /// <summary>
        /// Specifies the second column of the matrix.
        /// </summary>
        public Vector3 Column2;

        /// <summary>
        /// Specifies the third column of the matrix.
        /// </summary>
        public Vector3 Column3;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3"/> structure
        /// with the specified element values.
        /// </summary>
        /// <param name="m11">The value at the first row and first column of the matrix.</param>
        /// <param name="m12">The value at the first row and second column of the matrix.</param>
        /// <param name="m13">The value at the first row and third column of the matrix.</param>
        /// <param name="m21">The value at the second row and first column of the matrix.</param>
        /// <param name="m22">The value at the second row and second column of the matrix.</param>
        /// <param name="m23">The value at the second row and third column of the matrix.</param>
        /// <param name="m31">The value at the third row and first column of the matrix.</param>
        /// <param name="m32">The value at the third row and second column of the matrix.</param>
        /// <param name="m33">The value at the third row and third column of the matrix.</param>
        public Matrix3(
            float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            Column1.X = m11;
            Column1.Y = m21;
            Column1.Z = m31;
            Column2.X = m12;
            Column2.Y = m22;
            Column2.Z = m32;
            Column3.X = m13;
            Column3.Y = m23;
            Column3.Z = m33;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="Matrix3"/> value.
        /// </summary>
        /// <param name="other">A <see cref="Matrix3"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same element values as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Matrix3 other)
        {
            return Column1 == other.Column1 && Column2 == other.Column2 && Column3 == other.Column3;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="Matrix3"/> and
        /// has the same element values as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Matrix3)
            {
                return Equals((Matrix3)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Column1.GetHashCode() ^ Column2.GetHashCode() ^ Column3.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the matrix.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", Column1, Column2, Column3);
        }

        /// <summary>
        /// Negates all the elements in the source matrix and returns the result
        /// as a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value">The source matrix.</param>
        /// <returns>The result of negating all the elements in the source matrix.</returns>
        public static Matrix3 Negate(Matrix3 value)
        {
            Matrix3 result;
            Negate(ref value, out result);
            return result;
        }

        /// <summary>
        /// Negates all the elements in the source matrix and returns the result
        /// as a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value">The source matrix.</param>
        /// <param name="result">The result of negating all the elements in the source matrix.</param>
        public static void Negate(ref Matrix3 value, out Matrix3 result)
        {
            Vector3.Negate(ref value.Column1, out result.Column1);
            Vector3.Negate(ref value.Column2, out result.Column2);
            Vector3.Negate(ref value.Column3, out result.Column3);
        }

        /// <summary>
        /// Adds a matrix to another matrix and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The first matrix to add.</param>
        /// <param name="value2">The second matrix to add.</param>
        /// <returns>The sum of the two matrices.</returns>
        public static Matrix3 Add(Matrix3 value1, Matrix3 value2)
        {
            Matrix3 result;
            Add(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Adds a matrix to another matrix and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The first matrix to add.</param>
        /// <param name="value2">The second matrix to add.</param>
        /// <param name="result">The sum of the two matrices.</param>
        public static void Add(ref Matrix3 value1, ref Matrix3 value2, out Matrix3 result)
        {
            Vector3.Add(ref value1.Column1, ref value2.Column1, out result.Column1);
            Vector3.Add(ref value1.Column2, ref value2.Column2, out result.Column2);
            Vector3.Add(ref value1.Column3, ref value2.Column3, out result.Column3);
        }

        /// <summary>
        /// Subtracts a matrix from another matrix and returns the result as a new
        /// <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The matrix from which the other matrix will be subtracted.</param>
        /// <param name="value2">The matrix that is to be subtracted.</param>
        /// <returns>The result of the subtraction.</returns>
        public static Matrix3 Subtract(Matrix3 value1, Matrix3 value2)
        {
            Matrix3 result;
            Subtract(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Subtracts a matrix from another matrix and returns the result as a new
        /// <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The matrix from which the other matrix will be subtracted.</param>
        /// <param name="value2">The matrix that is to be subtracted.</param>
        /// <param name="result">The result of the subtraction.</param>
        public static void Subtract(ref Matrix3 value1, ref Matrix3 value2, out Matrix3 result)
        {
            Vector3.Subtract(ref value1.Column1, ref value2.Column1, out result.Column1);
            Vector3.Subtract(ref value1.Column2, ref value2.Column2, out result.Column2);
            Vector3.Subtract(ref value1.Column3, ref value2.Column3, out result.Column3);
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The source matrix.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The result of the multiplication.</returns>
        public static Matrix3 Multiply(Matrix3 value1, float value2)
        {
            Matrix3 result;
            Multiply(ref value1, value2, out result);
            return result;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The source matrix.</param>
        /// <param name="value2">The scalar value.</param>
        /// <param name="result">The result of the multiplication.</param>
        public static void Multiply(ref Matrix3 value1, float value2, out Matrix3 result)
        {
            Vector3.Multiply(ref value1.Column1, value2, out result.Column1);
            Vector3.Multiply(ref value1.Column2, value2, out result.Column2);
            Vector3.Multiply(ref value1.Column3, value2, out result.Column3);
        }

        /// <summary>
        /// Multiplies a matrix by another matrix and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The first matrix to multiply.</param>
        /// <param name="value2">The second matrix to multiply.</param>
        /// <returns>The result of the multiplication.</returns>
        public static Matrix3 Multiply(Matrix3 value1, Matrix3 value2)
        {
            Matrix3 result;
            Multiply(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Multiplies a matrix by another matrix and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The first matrix to multiply.</param>
        /// <param name="value2">The second matrix to multiply.</param>
        /// <param name="result">The result of the multiplication.</param>
        public static void Multiply(ref Matrix3 value1, ref Matrix3 value2, out Matrix3 result)
        {
            result.Column1.X = value1.Column1.X * value2.Column1.X + value1.Column2.X * value2.Column1.Y + value1.Column3.X * value2.Column1.Z;
            result.Column1.Y = value1.Column1.Y * value2.Column1.X + value1.Column2.Y * value2.Column1.Y + value1.Column3.Y * value2.Column1.Z;
            result.Column1.Z = value1.Column1.Z * value2.Column1.X + value1.Column2.Z * value2.Column1.Y + value1.Column3.Z * value2.Column1.Z;
            result.Column2.X = value1.Column1.X * value2.Column2.X + value1.Column2.X * value2.Column2.Y + value1.Column3.X * value2.Column2.Z;
            result.Column2.Y = value1.Column1.Y * value2.Column2.X + value1.Column2.Y * value2.Column2.Y + value1.Column3.Y * value2.Column2.Z;
            result.Column2.Z = value1.Column1.Z * value2.Column2.X + value1.Column2.Z * value2.Column2.Y + value1.Column3.Z * value2.Column2.Z;
            result.Column3.X = value1.Column1.X * value2.Column3.X + value1.Column2.X * value2.Column3.Y + value1.Column3.X * value2.Column3.Z;
            result.Column3.Y = value1.Column1.Y * value2.Column3.X + value1.Column2.Y * value2.Column3.Y + value1.Column3.Y * value2.Column3.Z;
            result.Column3.Z = value1.Column1.Z * value2.Column3.X + value1.Column2.Z * value2.Column3.Y + value1.Column3.Z * value2.Column3.Z;
        }

        /// <summary>
        /// Divides a matrix by a scalar value and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The source matrix.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The result of the division.</returns>
        public static Matrix3 Divide(Matrix3 value1, float value2)
        {
            Matrix3 result;
            Divide(ref value1, value2, out result);
            return result;
        }

        /// <summary>
        /// Divides a matrix by a scalar value and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The source matrix.</param>
        /// <param name="value2">The scalar value.</param>
        /// <param name="result">The result of the division.</param>
        public static void Divide(ref Matrix3 value1, float value2, out Matrix3 result)
        {
            Vector3.Divide(ref value1.Column1, value2, out result.Column1);
            Vector3.Divide(ref value1.Column2, value2, out result.Column2);
            Vector3.Divide(ref value1.Column3, value2, out result.Column3);
        }

        /// <summary>
        /// Divides the components of a matrix by the components of another matrix
        /// and returns the result as a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The matrix whose components will be divided.</param>
        /// <param name="value2">The divisor matrix.</param>
        /// <returns>The result of the division.</returns>
        public static Matrix3 Divide(Matrix3 value1, Matrix3 value2)
        {
            Matrix3 result;
            Divide(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Divides the components of a matrix by the components of another matrix
        /// and returns the result as a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value1">The matrix whose components will be divided.</param>
        /// <param name="value2">The divisor matrix.</param>
        /// <param name="result">The result of the division.</param>
        public static void Divide(ref Matrix3 value1, ref Matrix3 value2, out Matrix3 result)
        {
            Vector3.Divide(ref value1.Column1, ref value2.Column1, out result.Column1);
            Vector3.Divide(ref value1.Column2, ref value2.Column2, out result.Column2);
            Vector3.Divide(ref value1.Column3, ref value2.Column3, out result.Column3);
        }

        /// <summary>
        /// Tests whether two <see cref="Matrix3"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// all their elements equal; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Matrix3 left, Matrix3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Matrix3"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in any of their elements; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Matrix3 left, Matrix3 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Negates all the elements in the source matrix and returns the result
        /// as a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="value">The source matrix.</param>
        /// <returns>The result of negating all the elements in the source matrix.</returns>
        public static Matrix3 operator -(Matrix3 value)
        {
            Matrix3 result;
            Negate(ref value, out result);
            return result;
        }

        /// <summary>
        /// Adds a matrix to another matrix and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the addition operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the addition operator.
        /// </param>
        /// <returns>The sum of the two matrices.</returns>
        public static Matrix3 operator +(Matrix3 left, Matrix3 right)
        {
            Matrix3 result;
            Add(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Subtracts a matrix from another matrix and returns the result as a new
        /// <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the subtraction operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the subtraction operator.
        /// </param>
        /// <returns>The result of the subtraction.</returns>
        public static Matrix3 operator -(Matrix3 left, Matrix3 right)
        {
            Matrix3 result;
            Subtract(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="left">
        /// The scalar value on the left of the multiplication operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the multiplication operator.
        /// </param>
        /// <returns>The result of the multiplication.</returns>
        public static Matrix3 operator *(float left, Matrix3 right)
        {
            Matrix3 result;
            Multiply(ref right, left, out result);
            return result;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the multiplication operator.
        /// </param>
        /// <param name="right">
        /// The scalar value on the right of the multiplication operator.
        /// </param>
        /// <returns>The result of the multiplication.</returns>
        public static Matrix3 operator *(Matrix3 left, float right)
        {
            Matrix3 result;
            Multiply(ref left, right, out result);
            return result;
        }

        /// <summary>
        /// Multiplies a matrix by another matrix and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the multiplication operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the multiplication operator.
        /// </param>
        /// <returns>The result of the multiplication.</returns>
        public static Matrix3 operator *(Matrix3 left, Matrix3 right)
        {
            Matrix3 result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Divides a matrix by a scalar value and returns the result as
        /// a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the division operator.
        /// </param>
        /// <param name="right">
        /// The scalar value on the right of the division operator.
        /// </param>
        /// <returns>The result of the division.</returns>
        public static Matrix3 operator /(Matrix3 left, float right)
        {
            Matrix3 result;
            Divide(ref left, right, out result);
            return result;
        }

        /// <summary>
        /// Divides the components of a matrix by the components of another matrix
        /// and returns the result as a new <see cref="Matrix3"/>.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the division operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the division operator.
        /// </param>
        /// <returns>The result of the division.</returns>
        public static Matrix3 operator /(Matrix3 left, Matrix3 right)
        {
            Matrix3 result;
            Divide(ref left, ref right, out result);
            return result;
        }
    }
}
