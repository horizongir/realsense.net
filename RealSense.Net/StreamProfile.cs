using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealSense.Net
{
    /// <summary>
    /// Represents an available stream profile from a RealSense sensor.
    /// </summary>
    public class StreamProfile
    {
        readonly StreamProfileHandle handle;

        internal StreamProfile(StreamProfileHandle mode)
        {
            handle = mode;
        }

        internal StreamProfileHandle Handle
        {
            get { return handle; }
        }

        /// <summary>
        /// Gets a value indicating whether the selected profile is recommended for the sensor.
        /// </summary>
        public bool IsDefault
        {
            get
            {
                var result = NativeMethods.rs2_is_stream_profile_default(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return result != 0;
            }
        }

        public Intrinsics GetIntrinsics()
        {
            GetIntrinsics(out Intrinsics intrinsics);
            return intrinsics;
        }

        public void GetIntrinsics(out Intrinsics intrinsics)
        {
            NativeMethods.rs2_get_video_stream_intrinsics(handle, out intrinsics, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        public MotionDeviceIntrinsics GetMotionIntrinsics()
        {
            GetMotionIntrinsics(out MotionDeviceIntrinsics intrinsics);
            return intrinsics;
        }

        public void GetMotionIntrinsics(out MotionDeviceIntrinsics intrinsics)
        {
            NativeMethods.rs2_get_motion_intrinsics(handle, out intrinsics, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Gets the extrinsic transformation from this sensor stream to another sensor stream.
        /// </summary>
        /// <param name="other">The target sensor stream profile.</param>
        /// <returns>The extrinsic transformation between the two sensor streams.</returns>
        public Extrinsics GetExtrinsicsTo(StreamProfile other)
        {
            GetExtrinsicsTo(other, out Extrinsics extrinsics);
            return extrinsics;
        }

        /// <summary>
        /// Gets the extrinsic transformation from this sensor stream to another sensor stream.
        /// </summary>
        /// <param name="other">The target sensor stream profile.</param>
        /// <param name="extrinsics">
        /// The result structure specifying the extrinsic transformation between the two sensor streams.
        /// </param>
        public void GetExtrinsicsTo(StreamProfile other, out Extrinsics extrinsics)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            NativeMethods.rs2_get_extrinsics(handle, other.handle, out extrinsics, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }
    }
}
