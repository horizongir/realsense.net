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
        internal static extern int rs2_is_option_read_only(OptionsHandle options, Option option, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float rs2_get_option(OptionsHandle options, Option option, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_set_option(OptionsHandle options, Option option, float value, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern OptionsListHandle rs2_get_options_list(OptionsHandle options, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_get_options_list_size(OptionsListHandle options, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern string rs2_get_option_name(OptionsHandle options, Option option, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Option rs2_get_option_from_list(OptionsListHandle options, int i, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_delete_options_list(IntPtr list);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int rs2_supports_option(OptionsHandle options, Option option, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void rs2_get_option_range(
            OptionsHandle sensor,
            Option option,
            out float min,
            out float max,
            out float step,
            out float def,
            out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr rs2_get_option_description(OptionsHandle options, Option option, out RsError error);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern string rs2_get_option_value_description(OptionsHandle options, Option option, float value, out RsError error);
    }
}
