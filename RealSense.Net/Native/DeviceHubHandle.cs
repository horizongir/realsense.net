﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    class DeviceHubHandle : RsHandle
    {
        internal DeviceHubHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.rs2_delete_device_hub(handle);
            return true;
        }
    }
}
