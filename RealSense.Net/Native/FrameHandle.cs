using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    class FrameHandle : RsHandle
    {
        internal FrameHandle(IntPtr handle)
            : base(false)
        {
            SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            return true;
        }
    }
}
