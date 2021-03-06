﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net.Native
{
    class SensorHandle : OptionsHandle
    {
        internal SensorHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.rs2_delete_sensor(handle);
            return true;
        }
    }
}
