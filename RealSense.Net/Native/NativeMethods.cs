using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using RsError = System.IntPtr;

namespace RealSense.Net.Native
{
    [SuppressUnmanagedCodeSecurity]
    static class NativeMethods
    {
        const string libName = "realsense";

        internal delegate void FrameCallback(IntPtr dev, IntPtr frame, IntPtr user);

        internal delegate void MotionCallback(IntPtr dev, MotionData entry, IntPtr user);

        internal delegate void TimestampCallback(IntPtr dev, TimestampData entry, IntPtr user);

        internal delegate void LogCallback(LogSeverity min_severity, IntPtr message, IntPtr user);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ContextHandle rs_create_context(int api_version, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_delete_context(IntPtr context, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_device_count(ContextHandle context, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern DeviceHandle rs_get_device(ContextHandle context, int index, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_device_name(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_device_serial(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_device_info(DeviceHandle device, CameraInfo info, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_device_usb_port_id(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_device_firmware_version(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_get_device_extrinsics(
            DeviceHandle device,
            Stream from_stream,
            Stream to_stream,
            out Extrinsics extrin,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_get_motion_extrinsics_from(
            DeviceHandle device,
            Stream from,
            out Extrinsics extrin,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float rs_get_device_depth_scale(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_device_supports_option(DeviceHandle device, Option option, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_stream_mode_count(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_get_stream_mode(
            DeviceHandle device,
            Stream stream,
            int index,
            out int width,
            out int height,
            out PixelFormat format,
            out int framerate,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_enable_stream_ex(
            DeviceHandle device,
            Stream stream,
            int width,
            int height,
            PixelFormat format,
            int framerate,
            OutputBufferFormat output_format,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_enable_stream(
            DeviceHandle device,
            Stream stream,
            int width,
            int height,
            PixelFormat format,
            int framerate,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_enable_stream_preset(
            DeviceHandle device,
            Stream stream,
            Preset preset,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_disable_stream(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_is_stream_enabled(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_stream_width(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_stream_height(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PixelFormat rs_get_stream_format(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_stream_framerate(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_get_stream_intrinsics(DeviceHandle device, Stream stream, out Intrinsics intrin, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_get_motion_intrinsics(DeviceHandle device, out MotionIntrinsics intrinsic, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_set_frame_callback(DeviceHandle device, Stream stream, FrameCallback on_frame, IntPtr user, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_enable_motion_tracking(
            DeviceHandle device,
            MotionCallback on_motion_event,
            IntPtr motion_handler,
            TimestampCallback on_timestamp_event,
            IntPtr timestamp_handler,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_disable_motion_tracking(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_is_motion_tracking_active(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_start_device(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_stop_device(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_start_source(DeviceHandle device, Source source, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_stop_source(DeviceHandle device, Source source, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_is_device_streaming(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_get_device_option_range(
            DeviceHandle device,
            Option option,
            out double min,
            out double max,
            out double step,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_get_device_option_range_ex(
            DeviceHandle device,
            Option option,
            out double min,
            out double max,
            out double step,
            out double def,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_get_device_options(
            DeviceHandle device,
            [In]Option[] options,
            uint count,
            [Out]double[] values,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_set_device_options(
            DeviceHandle device,
            [In]Option[] options,
            uint count,
            [In]double[] values,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_reset_device_options_to_default(
            DeviceHandle device,
            [In]Option[] options,
            int count,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double rs_get_device_option(DeviceHandle device, Option option, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_device_option_description(DeviceHandle device, Option option, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_set_device_option(DeviceHandle device, Option option, double value, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_wait_for_frames(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_poll_for_frames(DeviceHandle device, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_supports(DeviceHandle device, Capabilities capability, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_supports_camera_info(DeviceHandle device, CameraInfo info_param, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double rs_get_detached_frame_metadata(FrameHandle frame, FrameMetadata frame_metadata, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_supports_frame_metadata(FrameHandle frame, FrameMetadata frame_metadata, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double rs_get_frame_timestamp(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ulong rs_get_frame_number(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_frame_data(DeviceHandle device, Stream stream, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_release_frame(DeviceHandle device, FrameHandle frame, IntPtr error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double rs_get_detached_frame_timestamp(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern TimestampDomain rs_get_detached_frame_timestamp_domain(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ulong rs_get_detached_frame_number(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_detached_frame_data(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_detached_frame_width(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_detached_frame_height(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_detached_framerate(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_detached_frame_stride(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_detached_frame_bpp(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PixelFormat rs_get_detached_frame_format(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Stream rs_get_detached_frame_stream_type(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_send_blob_to_device(DeviceHandle device, BlobType type, IntPtr data, int size, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs_get_api_version(out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_failed_function(RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_failed_args(RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs_get_error_message(RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_free_error(RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_log_to_console(LogSeverity min_severity, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void rs_log_to_file(LogSeverity min_severity, string file_path, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs_log_to_callback(LogSeverity min_severity, LogCallback on_log, IntPtr user, out RsError error);
    }
}
