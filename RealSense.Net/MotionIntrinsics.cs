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
    /// Represents the intrinsic parameters of a motion module.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MotionIntrinsics : IEquatable<MotionIntrinsics>
    {
        /// <summary>
        /// The intrinsic device parameters for the accelerometer.
        /// </summary>
        public MotionDeviceIntrinsics Accelerometer;

        /// <summary>
        /// The intrinsic device parameters for the gyroscope.
        /// </summary>
        public MotionDeviceIntrinsics Gyroscope;

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="MotionIntrinsics"/> value.
        /// </summary>
        /// <param name="other">A <see cref="MotionIntrinsics"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same element values as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(MotionIntrinsics other)
        {
            return Accelerometer == other.Accelerometer && Gyroscope == other.Gyroscope;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="MotionIntrinsics"/> and
        /// has the same element values as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is MotionIntrinsics)
            {
                return Equals((MotionIntrinsics)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Accelerometer.GetHashCode() ^ Gyroscope.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the motion module intrinsics.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{{Accelerometer: {0}, Gyroscope: {1}}}", Accelerometer, Gyroscope);
        }

        /// <summary>
        /// Tests whether two <see cref="MotionIntrinsics"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="MotionIntrinsics"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="MotionIntrinsics"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// all their elements equal; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(MotionIntrinsics left, MotionIntrinsics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="MotionIntrinsics"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="MotionIntrinsics"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="MotionIntrinsics"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in any of their elements; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(MotionIntrinsics left, MotionIntrinsics right)
        {
            return !left.Equals(right);
        }
    }
}
