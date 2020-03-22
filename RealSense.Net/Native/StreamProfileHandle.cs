using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    class StreamProfileHandle : RsHandle
    {
        internal StreamProfileHandle()
            : base(false)
        {
        }

        protected override bool ReleaseHandle()
        {
            return true;
        }
    }
}
