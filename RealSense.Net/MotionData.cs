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
    /// Represents motion data from the gyroscope and accelerometer in the microcontroller.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MotionData
    {
        /// <summary>
        /// The timestamp data associated with the motion data frame.
        /// </summary>
        public TimestampData TimestampData;

        /// <summary>
        /// A flag signalled by the microcontroller in case of an error.
        /// </summary>
        public bool IsValid;

        /// <summary>
        /// The three axial values; 16-bit data for gyroscope (in rad/sec),
        /// 12-bit for accelerometer; 2's complement (in m/sec^2).
        /// </summary>
        public Vector3 Axes;

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the motion data.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{{TimestampData: {0}, IsValid: {1}, Axes: {2}}}", TimestampData, IsValid, Axes);
        }
    }
}
