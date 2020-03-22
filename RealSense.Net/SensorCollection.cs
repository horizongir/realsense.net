using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a collection of connected sensors within a specific device.
    /// </summary>
    public class SensorCollection : IReadOnlyCollection<Sensor>, IDisposable
    {
        readonly SensorListHandle handle;

        internal SensorCollection(SensorListHandle sensorList)
        {
            handle = sensorList ?? throw new ArgumentNullException(nameof(sensorList));
        }

        /// <summary>
        /// Creates a reference to the device sensor with the specified index. The <see cref="Sensor"/> object
        /// represents a handle to the connected sensor and provides the means to manipulate it.
        /// </summary>
        /// <param name="index">The zero-based index of the sensor to create.</param>
        /// <returns>The requested disposable sensor handle.</returns>
        public Sensor CreateSensor(int index)
        {
            var sensor = NativeMethods.rs2_create_sensor(handle, index, out IntPtr error);
            NativeHelper.ThrowExceptionForRsError(error);
            return new Sensor(sensor);
        }

        /// <summary>
        /// Gets the number of sensors in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                var count = NativeMethods.rs2_get_sensors_count(handle, out IntPtr error);
                NativeHelper.ThrowExceptionForRsError(error);
                return count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through all the sensors in the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="IEnumerator{Sensor}"/> that can be used to iterate through the sensor collection.
        /// </returns>
        public IEnumerator<Sensor> GetEnumerator()
        {
            var count = Count;
            for (int i = 0; i < count; i++)
            {
                yield return CreateSensor(i);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Releases all resources held by the sensor collection instance.
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
