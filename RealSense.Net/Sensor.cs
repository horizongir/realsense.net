using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a connected device sensor.
    /// </summary>
    public class Sensor
    {
        readonly SensorHandle handle;
        readonly OptionCollection options;
        NativeMethods.FrameCallback frameCallback;

        internal Sensor(SensorHandle sensor)
        {
            handle = sensor;
            options = new OptionCollection(handle);
        }

        /// <summary>
        /// Gets the collection of options for the sensor.
        /// </summary>
        public OptionCollection Options
        {
            get { return options; }
        }

        /// <summary>
        /// Gets the number of meters represented by a single depth unit in a depth sensor.
        /// </summary>
        public float DepthScale
        {
            get
            {
                var scale = NativeMethods.rs2_get_depth_scale(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return scale;
            }
        }

        /// <summary>
        /// Gets the stereoscopic baseline value from a stereo-based depth sensor.
        /// </summary>
        public float StereoBaseline
        {
            get
            {
                var baseline = NativeMethods.rs2_get_stereo_baseline(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return baseline;
            }
        }

        /// <summary>
        /// Gets sensor specific information, such as versions of various internal components.
        /// </summary>
        /// <param name="info">The camera specific information that is to be retrieved.</param>
        /// <returns>
        /// The requested camera information string, in a format specific to the device model.
        /// </returns>
        public string GetSensorInfo(CameraInfo info)
        {
            var infoPtr = NativeMethods.rs2_get_sensor_info(handle, info, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return Marshal.PtrToStringAnsi(infoPtr);
        }

        /// <summary>
        /// Checks if a sensor supports a specific camera information type.
        /// </summary>
        /// <param name="info">The camera specific information that should be checked for support.</param>
        /// <returns>
        /// <b>true</b> if the parameter both exists and is well-defined for the specific sensor;
        /// otherwise, <b>false</b>.
        /// </returns>
        public bool SupportsSensorInfo(CameraInfo info)
        {
            var result = NativeMethods.rs2_supports_sensor_info(handle, info, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        public void Open(StreamProfile profile)
        {
            NativeMethods.rs2_open(handle, profile.Handle, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        public void OpenMultiple(params StreamProfile[] profiles)
        {
            if (profiles == null)
            {
                throw new ArgumentNullException(nameof(profiles));
            }

            var profileHandles = Array.ConvertAll(profiles, profile => profile.Handle.DangerousGetHandle());
            NativeMethods.rs2_open_multiple(handle, profileHandles, profileHandles.Length, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            GC.KeepAlive(profiles);
        }

        public void Close()
        {
            NativeMethods.rs2_close(handle, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Sets up a frame callback that is called immediately when an image is available,
        /// with no synchronization logic applied.
        /// </summary>
        /// <param name="onFrame">The function to be called whenever a new image is available.</param>
        public void Start(FrameCallback onFrame)
        {
            if (onFrame == null)
            {
                throw new ArgumentNullException(nameof(onFrame));
            }

            frameCallback = (frame, user) =>
            {
                var frameHandle = new FrameHandle(frame);
                onFrame(new Frame(frameHandle, this));
            };
            NativeMethods.rs2_start(handle, frameCallback, IntPtr.Zero, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }
    }
}
