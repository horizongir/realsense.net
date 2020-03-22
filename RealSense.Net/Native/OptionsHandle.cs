using System;
using System.Collections.Generic;
using System.Text;

namespace RealSense.Net.Native
{
    abstract class OptionsHandle : RsHandle
    {
        internal OptionsHandle(bool ownsHandle)
            : base(ownsHandle)
        {
        }
    }
}
