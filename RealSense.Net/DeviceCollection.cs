using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a collection of connected RealSense devices.
    /// </summary>
    public class DeviceCollection : IReadOnlyCollection<Device>, IDisposable
    {
        readonly DeviceListHandle handle;

        internal DeviceCollection(DeviceListHandle deviceList)
        {
            handle = deviceList ?? throw new ArgumentNullException(nameof(deviceList));
        }

        /// <summary>
        /// Determines whether the specified device is in the collection.
        /// </summary>
        /// <param name="device">The device to locate in the collection.</param>
        /// <returns>
        /// <b>true</b> if the device is in the collection; otherwise, <b>false</b>.
        /// </returns>
        public bool Contains(Device device)
        {
            var result = NativeMethods.rs2_device_list_contains(handle, device.Handle, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Opens a connection to the device with the specified index. The <see cref="Device"/> object
        /// represents a handle to the connected device and provides the means to manipulate it.
        /// </summary>
        /// <param name="index">The zero-based index of the device to create.</param>
        /// <returns>The requested disposable device handle.</returns>
        public Device CreateDevice(int index)
        {
            var device = NativeMethods.rs2_create_device(handle, index, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return new Device(device);
        }

        /// <summary>
        /// Gets the number of devices in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                var count = NativeMethods.rs2_get_device_count(handle, out IntPtr error);
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
                yield return CreateDevice(i);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Releases all resources held by the device collection instance.
        /// </summary>
        public void Dispose()
        {
            if (!handle.IsClosed)
            {
                handle.Close();
            }
        }
    }
}
