using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a RealSense device session.
    /// </summary>
    public partial class Device
    {
        readonly DeviceHandle handle;

        internal Device(DeviceHandle device)
        {
            handle = device ?? throw new ArgumentNullException(nameof(device));
        }

        internal DeviceHandle Handle
        {
            get { return handle; }
        }

        /// <summary>
        /// Gets camera specific information, such as versions of various internal components.
        /// </summary>
        /// <param name="info">The camera specific information that is to be retrieved.</param>
        /// <returns>
        /// The requested camera information string, in a format specific to the device model.
        /// </returns>
        public string GetDeviceInfo(CameraInfo info)
        {
            var infoPtr = NativeMethods.rs2_get_device_info(handle, info, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return Marshal.PtrToStringAnsi(infoPtr);
        }

        /// <summary>
        /// Checks if a camera supports a specific camera information type.
        /// </summary>
        /// <param name="info">The camera specific information that should be checked for support.</param>
        /// <returns>
        /// <b>true</b> if the parameter both exists and is well-defined for the specific device;
        /// otherwise, <b>false</b>.
        /// </returns>
        public bool SupportsDeviceInfo(CameraInfo info)
        {
            var result = NativeMethods.rs2_supports_device_info(handle, info, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Sends a hardware reset request to the device. The actual reset is asynchronous.
        /// </summary>
        public void HardwareReset()
        {
            NativeMethods.rs2_hardware_reset(handle, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Creates a static snapshot of all connected sensors within a specific device.
        /// </summary>
        /// <returns>The disposable collection of connected sensors.</returns>
        public SensorCollection QuerySensors()
        {
            var sensorList = NativeMethods.rs2_query_sensors(handle, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return new SensorCollection(sensorList);
        }
    }
}
