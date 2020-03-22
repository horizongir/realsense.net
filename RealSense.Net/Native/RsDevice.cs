using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using RsError = System.IntPtr;

namespace RealSense.Net.Native
{
    static partial class NativeMethods
    {
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_get_device_count(DeviceListHandle info_list, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_delete_device_list(IntPtr info_list);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_device_list_contains(DeviceListHandle info_list, DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern DeviceHandle rs2_create_device(DeviceListHandle info_list, int index, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_delete_device(IntPtr device);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs2_get_device_info(DeviceHandle device, CameraInfo info, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_supports_device_info(DeviceHandle device, CameraInfo info, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_hardware_reset(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern SensorListHandle rs2_query_sensors(DeviceHandle device, out RsError error);
    }
}
