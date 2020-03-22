using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    static class NativeHelper
    {
        internal static void ThrowExceptionForRsError(IntPtr error)
        {
            if (error != IntPtr.Zero)
            {
                try
                {
                    var function = Marshal.PtrToStringAnsi(NativeMethods.rs2_get_failed_function(error));
                    var args = Marshal.PtrToStringAnsi(NativeMethods.rs2_get_failed_args(error));
                    var message = Marshal.PtrToStringAnsi(NativeMethods.rs2_get_error_message(error));
                    throw new RealSenseException(string.Format("Error calling '{0}' with {1}. {2}", function, args, message));
                }
                finally { NativeMethods.rs2_free_error(error); }
            }
        }
    }
}
