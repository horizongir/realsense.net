using RealSense.Net.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a container of subdevice options.
    /// </summary>
    public class OptionCollection : IEnumerable<Option>
    {
        readonly OptionsHandle handle;

        internal OptionCollection(OptionsHandle options)
        {
            handle = options;
        }

        /// <summary>
        /// Gets or sets the current value of a single option.
        /// </summary>
        /// <param name="option">The option for which to get or set the value.</param>
        /// <returns>The current value of the specified option.</returns>
        public float this[Option option]
        {
            get
            {
                var value = NativeMethods.rs2_get_option(handle, option, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return value;
            }
            set
            {
                NativeMethods.rs2_set_option(handle, option, value, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
            }
        }

        /// <summary>
        /// Checks whether a particular option is supported by a subdevice.
        /// </summary>
        /// <param name="option">The option to be tested.</param>
        /// <returns>
        /// <b>true</b> if the specified option is supported by the subdevice; otherwise, <b>false</b>.
        /// </returns>
        public bool SupportsOption(Option option)
        {
            var result = NativeMethods.rs2_supports_option(handle, option, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Retrieves the available range of values for a supported option.
        /// </summary>
        /// <param name="option">The option for which to retrieve the value range.</param>
        /// <param name="min">The minimum value that is acceptable for this option.</param>
        /// <param name="max">The maximum value that is acceptable for this option.</param>
        /// <param name="step">
        /// The granularity of options that accept discrete values,
        /// or zero if the option accepts continuous values.
        /// </param>
        /// <param name="defaultValue">The default value for the option.</param>
        public void GetOptionRange(Option option, out float min, out float max, out float step, out float defaultValue)
        {
            NativeMethods.rs2_get_option_range(handle, option, out min, out max, out step, out defaultValue, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Gets a static description of what a particular option does on the current device.
        /// </summary>
        /// <param name="option">The option for which to retrieve the description.</param>
        /// <returns>The description of what the option does on the current device.</returns>
        public string GetOptionDescription(Option option)
        {
            var description = NativeMethods.rs2_get_option_description(handle, option, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return Marshal.PtrToStringAnsi(description);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the available subdevice options.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the available subdevice options.
        /// </returns>
        public IEnumerator<Option> GetEnumerator()
        {
            using (var optionsList = NativeMethods.rs2_get_options_list(handle, out IntPtr error))
            {
                NativeHelper.ThrowExceptionForRsError(error);
                var count = NativeMethods.rs2_get_options_list_size(optionsList, out error);
                NativeHelper.ThrowExceptionForRsError(error);

                for (int i = 0; i < count; i++)
                {
                    var option = NativeMethods.rs2_get_option_from_list(optionsList, i, out error);
                    NativeHelper.ThrowExceptionForRsError(error);
                    yield return option;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
