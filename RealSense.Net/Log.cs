using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RealSense.Net
{
    /// <summary>
    /// Provides a logging API for redirecting notifications of various operations.
    /// </summary>
    public static class Log
    {
        static NativeMethods.LogCallback logCallback;

        /// <summary>
        /// Starts logging API notifications to the standard output.
        /// </summary>
        /// <param name="minSeverity">The minimum severity of the messages to be logged.</param>
        public static void ToConsole(LogSeverity minSeverity)
        {
            NativeMethods.rs2_log_to_console(minSeverity, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Starts logging API notifications to a file.
        /// </summary>
        /// <param name="minSeverity">The minimum severity of the messages to be logged.</param>
        /// <param name="filePath">The path of the file to log to.</param>
        public static void ToFile(LogSeverity minSeverity, string filePath)
        {
            NativeMethods.rs2_log_to_file(minSeverity, filePath, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Starts logging API notifications through a custom user callback.
        /// </summary>
        /// <param name="minSeverity">The minimum severity of the messages to be logged.</param>
        /// <param name="onLog">The function that should be invoked whenever a new message needs to be logged.</param>
        public static void ToCallback(LogSeverity minSeverity, LogCallback onLog)
        {
            if (onLog == null)
            {
                throw new ArgumentNullException(nameof(onLog));
            }

            logCallback = (severity, message, user) =>
            {
                onLog(severity, Marshal.PtrToStringAnsi(message));
            };
            NativeMethods.rs2_log_to_callback(minSeverity, logCallback, IntPtr.Zero, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Adds a custom message to the RealSense log.
        /// </summary>
        /// <param name="severity">The log level under which to write the message.</param>
        /// <param name="message">The message to be logged.</param>
        public static void Message(LogSeverity severity, string message)
        {
            NativeMethods.rs2_log(severity, message, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }
    }
}
