using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents an image frame captured from a RealSense device stream.
    /// </summary>
    public class Frame
    {
        readonly FrameHandle handle;

        internal Frame(FrameHandle frame, Sensor sensor)
        {
            handle = frame ?? throw new ArgumentNullException(nameof(frame));
            Sensor = sensor;
        }

        /// <summary>
        /// Gets the sensor used to capture the frame.
        /// </summary>
        public Sensor Sensor { get; private set; }

        /// <summary>
        /// Gets the timestamp of the captured frame, in milliseconds since the device started.
        /// </summary>
        public double Timestamp
        {
            get
            {
                var timestamp = NativeMethods.rs2_get_frame_timestamp(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return timestamp;
            }
        }

        /// <summary>
        /// Gets the timestamp domain for the captured frame.
        /// </summary>
        public TimestampDomain TimestampDomain
        {
            get
            {
                var domain = NativeMethods.rs2_get_frame_timestamp_domain(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return domain;
            }
        }

        /// <summary>
        /// Gets the frame number of the captured frame.
        /// </summary>
        public ulong Number
        {
            get
            {
                var number = NativeMethods.rs2_get_frame_number(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return number;
            }
        }

        /// <summary>
        /// Gets the size of the captured frame content, in bytes.
        /// </summary>
        public int DataSize
        {
            get
            {
                var dataSize = NativeMethods.rs2_get_frame_data_size(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return dataSize;
            }
        }

        /// <summary>
        /// Gets a pointer to the contents of the captured frame.
        /// </summary>
        public IntPtr Data
        {
            get
            {
                var data = NativeMethods.rs2_get_frame_data(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return data;
            }
        }

        /// <summary>
        /// Gets the specified metadata from the captured frame.
        /// </summary>
        /// <param name="metadata">The metadata to retrieve from the captured frame.</param>
        /// <returns>The metadata value.</returns>
        public long GetMetadata(FrameMetadata metadata)
        {
            var value = NativeMethods.rs2_get_frame_metadata(handle, metadata, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return value;
        }

        /// <summary>
        /// Gets a value indicating whether the captured frame contains the specified metadata.
        /// </summary>
        /// <param name="metadata">The metadata to be queried.</param>
        /// <returns>
        /// <b>true</b> if the captured frame contains the specified metadata; otherwise, <b>false</b>.
        /// </returns>
        public bool SupportsMetadata(FrameMetadata metadata)
        {
            var result = NativeMethods.rs2_supports_frame_metadata(handle, metadata, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Removes the frame from the regular count of the frame pool, whenever you want to keep the frame
        /// alive for longer. Once this method is called, the SDK can no longer guarantee zero-allocations
        /// during frame cycling.
        /// </summary>
        public void Keep()
        {
            NativeMethods.rs2_keep_frame(handle);
        }

        /// <summary>
        /// Tests whether the frame can be extended to the specified type.
        /// </summary>
        /// <param name="extension">The extension to check.</param>
        /// <returns>
        /// <b>true</b> if the frame can be extended to the specified extension; otherwise, <b>false</b>.
        /// </returns>
        public bool IsExtendableTo(Extension extension)
        {
            var result = NativeMethods.rs2_is_frame_extendable_to(handle, extension, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }
    }
}
