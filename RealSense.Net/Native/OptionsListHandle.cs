using System;
using System.Collections.Generic;
using System.Text;

namespace RealSense.Net.Native
{
    class OptionsListHandle : RsHandle
    {
        internal OptionsListHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.rs2_delete_options_list(handle);
            return true;
        }
    }
}
