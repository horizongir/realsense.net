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

        internal Frame(FrameHandle frame)
        {
            if (frame == null)
            {
                throw new ArgumentNullException("frame");
            }

            handle = frame;
        }

        /// <summary>
        /// Gets the timestamp of the captured frame, in milliseconds since the device started.
        /// </summary>
        public double Timestamp
        {
            get
            {
                IntPtr error;
                var timestamp = NativeMethods.rs_get_detached_frame_timestamp(handle, out error);
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
                IntPtr error;
                var domain = NativeMethods.rs_get_detached_frame_timestamp_domain(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return domain;
            }
        }

        /// <summary>
        /// Gets the frame number of the captured frame.
        /// </summary>
        public ulong FrameNumber
        {
            get
            {
                IntPtr error;
                var frameNumber = NativeMethods.rs_get_detached_frame_number(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return frameNumber;
            }
        }

        /// <summary>
        /// Gets a pointer to the contents of the captured frame.
        /// </summary>
        public IntPtr FrameData
        {
            get
            {
                IntPtr error;
                var frameData = NativeMethods.rs_get_detached_frame_data(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return frameData;
            }
        }

        /// <summary>
        /// Gets the width of the captured frame, in pixels.
        /// </summary>
        public int Width
        {
            get
            {
                IntPtr error;
                var width = NativeMethods.rs_get_detached_frame_width(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return width;
            }
        }

        /// <summary>
        /// Gets the height of the captured frame, in pixels.
        /// </summary>
        public int Height
        {
            get
            {
                IntPtr error;
                var height = NativeMethods.rs_get_detached_frame_height(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return height;
            }
        }

        /// <summary>
        /// Gets the framerate of the device stream which acquired the frame.
        /// </summary>
        public int Framerate
        {
            get
            {
                IntPtr error;
                var framerate = NativeMethods.rs_get_detached_framerate(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return framerate;
            }
        }

        /// <summary>
        /// Gets the total line width, in bytes, of the captured frame.
        /// </summary>
        public int Stride
        {
            get
            {
                IntPtr error;
                var stride = NativeMethods.rs_get_detached_frame_stride(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return stride;
            }
        }

        /// <summary>
        /// Gets the bits per pixel used by the captured frame format.
        /// </summary>
        public int BitsPerPixel
        {
            get
            {
                IntPtr error;
                var bpp = NativeMethods.rs_get_detached_frame_bpp(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return bpp;
            }
        }

        /// <summary>
        /// Gets the pixel format of the captured frame.
        /// </summary>
        public PixelFormat Format
        {
            get
            {
                IntPtr error;
                var format = NativeMethods.rs_get_detached_frame_format(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return format;
            }
        }

        /// <summary>
        /// Gets the type of the device stream which acquired the frame.
        /// </summary>
        public Stream StreamType
        {
            get
            {
                IntPtr error;
                var stream = NativeMethods.rs_get_detached_frame_stream_type(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return stream;
            }
        }

        /// <summary>
        /// Gets the specified metadata from the captured frame.
        /// </summary>
        /// <param name="metadata">The metadata to retrieve from the captured frame.</param>
        /// <returns>The metadata value.</returns>
        public double GetMetadata(FrameMetadata metadata)
        {
            IntPtr error;
            var value = NativeMethods.rs_get_detached_frame_metadata(handle, metadata, out error);
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
            IntPtr error;
            var result = NativeMethods.rs_supports_frame_metadata(handle, metadata, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }
    }
}
