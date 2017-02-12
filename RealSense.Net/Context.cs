using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
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
        readonly DeviceCollection devices;

        private Context(int version)
        {
            IntPtr error;
            handle = NativeMethods.rs_create_context(version, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            devices = new DeviceCollection(handle);
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
            IntPtr error;
            var version = NativeMethods.rs_get_api_version(out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return version;
        }

        /// <summary>
        /// Gets the collection of connected RealSense devices.
        /// </summary>
        public DeviceCollection Devices
        {
            get { return devices; }
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
