using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a collection of RealSense device sessions.
    /// </summary>
    public class DeviceCollection : IReadOnlyList<Device>
    {
        readonly ContextHandle handle;

        internal DeviceCollection(ContextHandle context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            handle = context;
        }

        /// <summary>
        /// Gets the device at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the device to get.</param>
        /// <returns>The device at the specified index.</returns>
        public Device this[int index]
        {
            get
            {
                IntPtr error;
                var device = NativeMethods.rs_get_device(handle, index, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return new Device(device);
            }
        }

        /// <summary>
        /// Gets the number of devices in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                IntPtr error;
                var count = NativeMethods.rs_get_device_count(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Device> GetEnumerator()
        {
            var count = Count;
            for (int i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
