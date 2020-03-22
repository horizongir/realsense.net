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
        internal static extern long rs2_get_frame_metadata(FrameHandle frame, FrameMetadata frame_metadata, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_supports_frame_metadata(FrameHandle frame, FrameMetadata frame_metadata, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern TimestampDomain rs2_get_frame_timestamp_domain(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double rs2_get_frame_timestamp(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ulong rs2_get_frame_number(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_get_frame_data_size(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs2_get_frame_data(FrameHandle frame, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_release_frame(IntPtr frame);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_keep_frame(FrameHandle frame);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_is_frame_extendable_to(FrameHandle frame, Extension extension_type, out RsError error);
    }
}
