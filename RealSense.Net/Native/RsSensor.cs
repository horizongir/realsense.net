using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using RsError = System.IntPtr;

namespace RealSense.Net.Native
{
    static partial class NativeMethods
    {
        internal delegate void FrameCallback(IntPtr frame, IntPtr user);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_delete_sensor_list(IntPtr info_list);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_get_sensors_count(SensorListHandle info_list, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_delete_sensor(IntPtr sensor);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern SensorHandle rs2_create_sensor(SensorListHandle list, int index, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs2_get_sensor_info(SensorHandle sensor, CameraInfo info, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_supports_sensor_info(SensorHandle sensor, CameraInfo info, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float rs2_get_depth_scale(SensorHandle sensor, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float rs2_get_stereo_baseline(SensorHandle sensor, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_open(SensorHandle device, StreamProfileHandle profile, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_open_multiple(SensorHandle device, [In]IntPtr[] profiles, int count, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_close(SensorHandle sensor, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_start(SensorHandle sensor, FrameCallback on_frame, IntPtr user, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_get_motion_intrinsics(StreamProfileHandle mode, out MotionDeviceIntrinsics intrinsics, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_is_stream_profile_default(StreamProfileHandle mode, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_get_stream_profiles_count(StreamProfileListHandle list, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_delete_stream_profiles_list(IntPtr list);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_get_extrinsics(
            StreamProfileHandle from,
            StreamProfileHandle to,
            out Extrinsics extrin,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_get_video_stream_intrinsics(StreamProfileHandle mode, out Intrinsics intrinsics, out RsError error);
    }
}
