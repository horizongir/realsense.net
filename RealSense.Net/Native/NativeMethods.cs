using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using RsError = System.IntPtr;

namespace RealSense.Net.Native
{
    [SuppressUnmanagedCodeSecurity]
    static partial class NativeMethods
    {
        const string libName = "realsense2";

        internal delegate void LogCallback(LogSeverity min_severity, IntPtr message, IntPtr user);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_get_api_version(out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs2_get_failed_function(RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs2_get_failed_args(RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs2_get_error_message(RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_free_error(RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_log_to_console(LogSeverity min_severity, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void rs2_log_to_file(LogSeverity min_severity, string file_path, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_log_to_callback(LogSeverity min_severity, LogCallback on_log, IntPtr user, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void rs2_log(LogSeverity severity, string message, out RsError error);
    }
}
