using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    static class Version
    {
        const int Major = 2;
        const int Minor = 33;
        const int Patch = 1;

        internal static int GetApiVersion()
        {
            return Major * 10000 + Minor * 100 + Patch;
        }
    }
}
