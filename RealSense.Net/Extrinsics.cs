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
    /// Represents cross-stream extrinsics encoding the topology describing how
    /// the different devices are connected.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Extrinsics : IEquatable<Extrinsics>
    {
        /// <summary>
        /// Specifies the column-major 3x3 rotation matrix.
        /// </summary>
        public Matrix3 Rotation;

        /// <summary>
        /// Specifies the three-element translation vector, in meters.
        /// </summary>
        public Vector3 Translation;

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="Extrinsics"/> value.
        /// </summary>
        /// <param name="other">A <see cref="Extrinsics"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same element values as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Extrinsics other)
        {
            return Rotation == other.Rotation && Translation == other.Translation;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="Extrinsics"/> and
        /// has the same element values as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Extrinsics)
            {
                return Equals((Extrinsics)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Rotation.GetHashCode() ^ Translation.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the cross-stream extrinsics.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", Rotation, Translation);
        }

        /// <summary>
        /// Tests whether two <see cref="Extrinsics"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Extrinsics"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Extrinsics"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// all their elements equal; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Extrinsics left, Extrinsics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Extrinsics"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Extrinsics"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Extrinsics"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in any of their elements; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Extrinsics left, Extrinsics right)
        {
            return !left.Equals(right);
        }
    }
}
