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

        /// <summary>
        /// Computes the corresponding pixel coordinates of a point in 3D space, assuming an image with no distortion or
        /// with forward distortion coefficients produced by the same camera.
        /// </summary>
        /// <param name="point">The 3D point to project into image space.</param>
        /// <param name="intrinsics">The intrinsic parameters of the camera.</param>
        /// <returns>The projected 2D point.</returns>
        public static Vector2 ProjectPoint(Vector3 point, Intrinsics intrinsics)
        {
            ProjectPoint(ref point, ref intrinsics, out Vector2 result);
            return result;
        }

        /// <summary>
        /// Computes the corresponding pixel coordinates of a point in 3D space, assuming an image with no distortion or
        /// with forward distortion coefficients produced by the same camera.
        /// </summary>
        /// <param name="point">The 3D point to project into image space.</param>
        /// <param name="intrinsics">The intrinsic parameters of the camera.</param>
        /// <param name="result">The projected 2D point.</param>
        public static void ProjectPoint(ref Vector3 point, ref Intrinsics intrinsics, out Vector2 result)
        {
            if (intrinsics.Model == Distortion.InverseBrownConrady || intrinsics.Model == Distortion.FTheta)
            {
                throw new ArgumentException("The specified intrinsics distortion model is not supported.", nameof(intrinsics));
            }

            var x = point.X / point.Z;
            var y = point.Y / point.Z;
            if (intrinsics.Model == Distortion.ModifiedBrownConrady)
            {
                var r2 = x * x + y * y;
                var f = 1 + intrinsics.Coeff0 * r2 + intrinsics.Coeff1 * r2 * r2 + intrinsics.Coeff4 * r2 * r2 * r2;
                x *= f;
                y *= f;
                var dx = x + 2 * intrinsics.Coeff2 * x * y + intrinsics.Coeff3 * (r2 + 2 * x * x);
                var dy = y + 2 * intrinsics.Coeff3 * x * y + intrinsics.Coeff2 * (r2 + 2 * y * y);
                x = dx;
                y = dy;
            }
            result.X = x * intrinsics.Fx + intrinsics.Ppx;
            result.Y = y * intrinsics.Fy + intrinsics.Ppy;
        }

        /// <summary>
        /// Computes the corresponding 3D coordinates of an image pixel with known depth, assuming an image with no distortion or
        /// with inverse distortion coefficients produced by the same camera.
        /// </summary>
        /// <param name="pixel">The 2D point to project into 3D space.</param>
        /// <param name="intrinsics">The intrinsic parameters of the camera.</param>
        /// <param name="depth">The depth of the image pixel.</param>
        /// <returns>The 3D coordinates of the 2D point relative to the camera.</returns>
        public static Vector3 DeprojectPoint(Vector2 pixel, Intrinsics intrinsics, float depth)
        {
            DeprojectPoint(ref pixel, ref intrinsics, depth, out Vector3 result);
            return result;
        }

        /// <summary>
        /// Computes the corresponding 3D coordinates of an image pixel with known depth, assuming an image with no distortion or
        /// with inverse distortion coefficients produced by the same camera.
        /// </summary>
        /// <param name="pixel">The 2D point to project into 3D space.</param>
        /// <param name="intrinsics">The intrinsic parameters of the camera.</param>
        /// <param name="depth">The depth of the image pixel.</param>
        /// <param name="result">The 3D coordinates of the 2D point relative to the camera.</param>
        public static void DeprojectPoint(ref Vector2 pixel, ref Intrinsics intrinsics, float depth, out Vector3 result)
        {
            if (intrinsics.Model == Distortion.ModifiedBrownConrady || intrinsics.Model == Distortion.FTheta)
            {
                throw new ArgumentException("The specified intrinsics distortion model is not supported.", nameof(intrinsics));
            }

            var x = (pixel.X - intrinsics.Ppx) / intrinsics.Fx;
            var y = (pixel.Y - intrinsics.Ppy) / intrinsics.Fy;
            if (intrinsics.Model == Distortion.InverseBrownConrady)
            {
                var r2 = x * x + y * y;
                var f = 1 + intrinsics.Coeff0 * r2 + intrinsics.Coeff1 * r2 * r2 + intrinsics.Coeff4 * r2 * r2 * r2;
                var ux = x * f + 2 * intrinsics.Coeff2 * x * y + intrinsics.Coeff3 * (r2 + 2 * x * x);
                var uy = y * f + 2 * intrinsics.Coeff3 * x * y + intrinsics.Coeff2 * (r2 + 2 * y * y);
                x = ux;
                y = uy;
            }
            result.X = depth * x;
            result.Y = depth * y;
            result.Z = depth;
        }
    }
}
