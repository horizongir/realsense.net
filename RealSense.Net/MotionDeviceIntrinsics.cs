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
    /// Represents the intrinsic parameters of a motion device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MotionDeviceIntrinsics : IEquatable<MotionDeviceIntrinsics>
    {
        /// <summary>
        /// The scale matrix for the X, Y, and Z axis.
        /// </summary>
        public Matrix3 Scale;

        /// <summary>
        /// The bias for the X, Y, and Z axis.
        /// </summary>
        public Vector3 Bias;

        /// <summary>
        /// The variance of the noise for the X, Y, and Z axis.
        /// </summary>
        public Vector3 NoiseVariances;

        /// <summary>
        /// The variance of the bias for the X, Y, and Z axis.
        /// </summary>
        public Vector3 BiasVariances;

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="MotionDeviceIntrinsics"/> value.
        /// </summary>
        /// <param name="other">A <see cref="MotionDeviceIntrinsics"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same element values as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(MotionDeviceIntrinsics other)
        {
            return Scale == other.Scale && Bias == other.Bias && NoiseVariances == other.NoiseVariances && BiasVariances == other.BiasVariances;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="MotionDeviceIntrinsics"/> and
        /// has the same element values as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is MotionDeviceIntrinsics)
            {
                return Equals((MotionDeviceIntrinsics)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Scale.GetHashCode() ^ Bias.GetHashCode() ^ NoiseVariances.GetHashCode() ^ BiasVariances.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the motion device intrinsics.
        /// </returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{{Scale: {0}, Bias: {1}, NoiseVariances: {2}, BiasVariances: {3}}}",
                Scale,
                Bias,
                NoiseVariances,
                BiasVariances);
        }

        /// <summary>
        /// Tests whether two <see cref="MotionDeviceIntrinsics"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="MotionDeviceIntrinsics"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="MotionDeviceIntrinsics"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// all their elements equal; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(MotionDeviceIntrinsics left, MotionDeviceIntrinsics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="MotionDeviceIntrinsics"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="MotionDeviceIntrinsics"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="MotionDeviceIntrinsics"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in any of their elements; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(MotionDeviceIntrinsics left, MotionDeviceIntrinsics right)
        {
            return !left.Equals(right);
        }
    }
}
