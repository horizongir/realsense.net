using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    class ContextHandle : RsHandle
    {
        internal ContextHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            IntPtr error;
            NativeMethods.rs_delete_context(handle, out error);
            if (error != IntPtr.Zero) NativeMethods.rs_free_error(error);
            return true;
        }
    }
}
