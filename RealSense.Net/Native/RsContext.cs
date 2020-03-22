using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using RsError = System.IntPtr;

namespace RealSense.Net.Native
{
    static partial class NativeMethods
    {
        internal delegate void DevicesChangedCallback(IntPtr removedListPtr, IntPtr addedListPtr, IntPtr user);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ContextHandle rs2_create_context(int api_version, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_delete_context(IntPtr context);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_set_devices_changed_callback(ContextHandle context, DevicesChangedCallback callback, IntPtr user, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_context_unload_tracking_module(ContextHandle ctx, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern DeviceListHandle rs2_query_devices(ContextHandle context, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern DeviceListHandle rs2_query_devices_ex(ContextHandle context, ProductLines mask, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern DeviceHubHandle rs2_create_device_hub(ContextHandle context, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_delete_device_hub(IntPtr hub);
    }
}
