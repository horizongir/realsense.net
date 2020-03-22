using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    class DeviceListHandle : RsHandle
    {
        internal DeviceListHandle()
            : base(true)
        {
        }

        internal DeviceListHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.rs2_delete_device_list(handle);
            return true;
        }
    }
}
