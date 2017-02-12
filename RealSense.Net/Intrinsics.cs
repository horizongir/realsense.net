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
    /// Represents video stream intrinsics.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Intrinsics : IEquatable<Intrinsics>
    {
        /// <summary>
        /// Width of the image in pixels.
        /// </summary>
        public int Width;

        /// <summary>
        /// Height of the image in pixels.
        /// </summary>
        public int Height;

        /// <summary>
        /// Horizontal coordinate of the principal point of the image, as a pixel offset from the left edge.
        /// </summary>
        public float Ppx;

        /// <summary>
        /// Vertical coordinate of the principal point of the image, as a pixel offset from the top edge.
        /// </summary>
        public float Ppy;

        /// <summary>
        /// Focal length of the image plane, as a multiple of pixel width.
        /// </summary>
        public float Fx;

        /// <summary>
        /// Focal length of the image plane, as a multiple of pixel height.
        /// </summary>
        public float Fy;

        /// <summary>
        /// Distortion model of the image.
        /// </summary>
        public Distortion Model;

        /// <summary>
        /// Distortion coefficients.
        /// </summary>
        public float Coeff0;

        /// <summary>
        /// Distortion coefficients.
        /// </summary>
        public float Coeff1;

        /// <summary>
        /// Distortion coefficients.
        /// </summary>
        public float Coeff2;

        /// <summary>
        /// Distortion coefficients.
        /// </summary>
        public float Coeff3;

        /// <summary>
        /// Distortion coefficients.
        /// </summary>
        public float Coeff4;

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="Intrinsics"/> value.
        /// </summary>
        /// <param name="other">An <see cref="Intrinsics"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same element values as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Intrinsics other)
        {
            return Width == other.Width &&
                   Height == other.Height &&
                   Ppx == other.Ppx &&
                   Ppy == other.Ppy &&
                   Fx == other.Fx &&
                   Fy == other.Fy &&
                   Model == other.Model &&
                   Coeff0 == other.Coeff0 &&
                   Coeff1 == other.Coeff1 &&
                   Coeff2 == other.Coeff2 &&
                   Coeff3 == other.Coeff3 &&
                   Coeff4 == other.Coeff4;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="Intrinsics"/> and
        /// has the same element values as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Intrinsics)
            {
                return Equals((Intrinsics)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^
                   Height.GetHashCode() ^
                   Ppx.GetHashCode() ^
                   Ppy.GetHashCode() ^
                   Fx.GetHashCode() ^
                   Fy.GetHashCode() ^
                   Model.GetHashCode() ^
                   Coeff0.GetHashCode() ^
                   Coeff1.GetHashCode() ^
                   Coeff2.GetHashCode() ^
                   Coeff3.GetHashCode() ^
                   Coeff4.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the video stream intrinsics.
        /// </returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{{Width: {0}, Height: {1}, Ppx: {2}, Ppy: {3}, Fx: {4}, Fy: {5}, Model: {6}, Coeffs: ({7}, {8}, {9}, {10}, {11})}}",
                Width, Height,
                Ppx, Ppy,
                Fx, Fy,
                Model,
                Coeff0, Coeff1, Coeff2, Coeff3, Coeff4);
        }

        /// <summary>
        /// Tests whether two <see cref="Intrinsics"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Intrinsics"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Intrinsics"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// all their elements equal; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Intrinsics left, Intrinsics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Intrinsics"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Intrinsics"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Intrinsics"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in any of their elements; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Intrinsics left, Intrinsics right)
        {
            return !left.Equals(right);
        }
    }
}
