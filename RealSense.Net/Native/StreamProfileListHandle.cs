using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    class StreamProfileListHandle : RsHandle
    {
        internal StreamProfileListHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.rs2_delete_stream_profiles_list(handle);
            return true;
        }
    }
}
