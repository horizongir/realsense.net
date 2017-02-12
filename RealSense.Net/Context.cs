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
        readonly DeviceCollection devices;
        static NativeMethods.LogCallback logCallback;

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
        /// Starts logging API notifications to the standard output.
        /// </summary>
        /// <param name="minSeverity">The minimum severity of the messages to be logged.</param>
        public static void LogToConsole(LogSeverity minSeverity)
        {
            IntPtr error;
            NativeMethods.rs_log_to_console(minSeverity, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Starts logging API notifications to a file.
        /// </summary>
        /// <param name="minSeverity">The minimum severity of the messages to be logged.</param>
        /// <param name="filePath">The path of the file to log to.</param>
        public static void LogToFile(LogSeverity minSeverity, string filePath)
        {
            IntPtr error;
            NativeMethods.rs_log_to_file(minSeverity, filePath, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Starts logging API notifications through a custom user callback.
        /// </summary>
        /// <param name="minSeverity">The minimum severity of the messages to be logged.</param>
        /// <param name="onLog">The function that should be invoked whenever a new message needs to be logged.</param>
        public static void LogToCallback(LogSeverity minSeverity, LogCallback onLog)
        {
            if (onLog == null)
            {
                throw new ArgumentNullException("onLog");
            }

            IntPtr error;
            logCallback = (severity, message, user) =>
            {
                onLog(severity, Marshal.PtrToStringAnsi(message));
            };
            NativeMethods.rs_log_to_callback(minSeverity, logCallback, IntPtr.Zero, out error);
            NativeHelper.ThrowExceptionForRsError(error);
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
