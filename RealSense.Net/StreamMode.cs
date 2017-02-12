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
    /// Represents the properties of a specific streaming mode.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct StreamMode : IEquatable<StreamMode>
    {
        /// <summary>
        /// The width of a frame image in pixels.
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of a frame image in pixels.
        /// </summary>
        public int Height;

        /// <summary>
        /// The pixel format of a frame image.
        /// </summary>
        public PixelFormat Format;

        /// <summary>
        /// The number of frames that will be streamed per second.
        /// </summary>
        public int Framerate;

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="StreamMode"/> value.
        /// </summary>
        /// <param name="other">A <see cref="StreamMode"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same element values as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(StreamMode other)
        {
            return Width == other.Width && Height == other.Height && Format == other.Format && Framerate == other.Framerate;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="StreamMode"/> and
        /// has the same element values as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is StreamMode)
            {
                return Equals((StreamMode)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode() ^ Format.GetHashCode() ^ Framerate.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the stream mode structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}x{1}@{3}fps ({2})", Width, Height, Format, Framerate);
        }

        /// <summary>
        /// Tests whether two <see cref="StreamMode"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="StreamMode"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="StreamMode"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// all their elements equal; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(StreamMode left, StreamMode right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="StreamMode"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="StreamMode"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="StreamMode"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in any of their elements; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(StreamMode left, StreamMode right)
        {
            return !left.Equals(right);
        }
    }
}
