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
    /// Represents timestamp data from the motion microcontroller.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TimestampData
    {
        /// <summary>
        /// The timestamp in milliseconds.
        /// </summary>
        public double Timestamp;

        /// <summary>
        /// The physical component that originated the event.
        /// </summary>
        public EventSource SourceId;

        /// <summary>
        /// The frame number required to join timestamp data with the relevant frame.
        /// </summary>
        public ulong FrameNumber;

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the timestamp data.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{{Timestamp: {0}, SourceId: {1}, FrameNumber: {2}}}", Timestamp, SourceId, FrameNumber);
        }
    }
}
