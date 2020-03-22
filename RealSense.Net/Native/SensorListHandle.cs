using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    class SensorListHandle : RsHandle
    {
        internal SensorListHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.rs2_delete_sensor_list(handle);
            return true;
        }
    }
}
