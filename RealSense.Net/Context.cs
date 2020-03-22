using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a RealSense device context session.
    /// </summary>
    public class Context : IDisposable
    {
        readonly ContextHandle handle;
        NativeMethods.DevicesChangedCallback devicesChangedCallback;

        private Context(int version)
        {
            handle = NativeMethods.rs2_create_context(version, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Initializes a new RealSense device context session.
        /// </summary>
        /// <returns>The new device context instance.</returns>
        public static Context Create()
        {
            var version = Version.GetApiVersion();
            return new Context(version);
        }

        /// <summary>
        /// Gets the API version of the compiled library DLL.
        /// </summary>
        /// <returns>The API version encoded as an integer value.</returns>
        public static int GetApiVersion()
        {
            var version = NativeMethods.rs2_get_api_version(out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return version;
        }

        /// <summary>
        /// Sets up a callback that is invoked whenever a new RealSense device is connected
        /// or an existing device is disconnected.
        /// </summary>
        /// <param name="callback">The function to be called whenever a device is connected or disconnected.</param>
        public void SetDevicesChangedCallback(DevicesChangedCallback callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            devicesChangedCallback = (removedListPtr, addedListPtr, user) =>
            {
                var removedList = new DeviceListHandle(removedListPtr);
                var addedList = new DeviceListHandle(addedListPtr);
                using (var removed = new DeviceCollection(removedList))
                using (var added = new DeviceCollection(addedList))
                {
                    callback(removed, added);
                }
            };
            NativeMethods.rs2_set_devices_changed_callback(handle, devicesChangedCallback, IntPtr.Zero, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Removes the tracking module from the context. If the tracking module is not used by this context it should
        /// be removed using this method so that other applications can find it.
        /// </summary>
        public void UnloadTrackingModule()
        {
            NativeMethods.rs2_context_unload_tracking_module(handle, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Creates a static snapshot of all connected devices at the time of call.
        /// </summary>
        /// <param name="mask">An optional product mask controlling what kind of devices should be returned.</param>
        /// <returns>The disposable collection of connected devices.</returns>
        public DeviceCollection QueryDevices(ProductLines mask = ProductLines.AnyIntel)
        {
            var deviceList = NativeMethods.rs2_query_devices_ex(handle, mask, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return new DeviceCollection(deviceList);
        }

        /// <summary>
        /// Releases all resources held by the device context instance.
        /// </summary>
        public void Dispose()
        {
            if (!handle.IsClosed)
            {
                handle.Close();
            }
        }
    }
}
