using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    static class Version
    {
        const int Major = 1;
        const int Minor = 12;
        const int Patch = 1;

        internal static int GetApiVersion()
        {
            return Major * 10000 + Minor * 100 + Patch;
        }
    }
}
