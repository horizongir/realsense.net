using RealSense.Net.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Represents a RealSense device session.
    /// </summary>
    public class Device
    {
        readonly DeviceHandle handle;
        readonly EventHandlerList callbacks;
        static readonly object MotionEventHandler = new object();
        static readonly object TimestampEventHandler = new object();

        internal Device(DeviceHandle device)
        {
            if (device == null)
            {
                throw new ArgumentNullException("device");
            }

            handle = device;
            callbacks = new EventHandlerList();
        }

        /// <summary>
        /// Gets the human-readable device model.
        /// </summary>
        public string Name
        {
            get
            {
                IntPtr error;
                var namePtr = NativeMethods.rs_get_device_name(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return Marshal.PtrToStringAnsi(namePtr);
            }
        }

        /// <summary>
        /// Gets the unique serial number of the device, in a format specific to the device model.
        /// </summary>
        public string Serial
        {
            get
            {
                IntPtr error;
                var serialPtr = NativeMethods.rs_get_device_serial(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return Marshal.PtrToStringAnsi(serialPtr);
            }
        }

        /// <summary>
        /// Gets the USB port number of the device.
        /// </summary>
        public string UsbPortId
        {
            get
            {
                IntPtr error;
                var idPtr = NativeMethods.rs_get_device_usb_port_id(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return Marshal.PtrToStringAnsi(idPtr);
            }
        }

        /// <summary>
        /// Gets the version of the firmware currently installed on the device.
        /// </summary>
        public string FirmwareVersion
        {
            get
            {
                IntPtr error;
                var versionPtr = NativeMethods.rs_get_device_firmware_version(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return Marshal.PtrToStringAnsi(versionPtr);
            }
        }

        /// <summary>
        /// Gets the scale mapping between the units of the depth image and meters.
        /// </summary>
        public float DepthScale
        {
            get
            {
                IntPtr error;
                var scale = NativeMethods.rs_get_device_depth_scale(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return scale;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the device is currently streaming.
        /// </summary>
        public bool Streaming
        {
            get
            {
                IntPtr error;
                var result = NativeMethods.rs_is_device_streaming(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return result != 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether motion tracking is active.
        /// </summary>
        public bool MotionTrackingActive
        {
            get
            {
                IntPtr error;
                var result = NativeMethods.rs_is_motion_tracking_active(handle, out error);
                NativeHelper.ThrowExceptionForRsError(error);
                return result != 0;
            }
        }

        /// <summary>
        /// Gets camera specific information, such as versions of various internal components.
        /// </summary>
        /// <param name="info">The camera specific information that is to be retrieved.</param>
        /// <returns>
        /// The requested camera information string, in a format specific to the device model.
        /// </returns>
        public string GetCameraInfo(CameraInfo info)
        {
            IntPtr error;
            var infoPtr = NativeMethods.rs_get_device_info(handle, info, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return Marshal.PtrToStringAnsi(infoPtr);
        }

        /// <summary>
        /// Gets the extrinsic transformation between the viewpoints of two different streams.
        /// </summary>
        /// <param name="fromStream">The stream whose coordinate space to transform from.</param>
        /// <param name="toStream">The stream whose coordinate space to transform to.</param>
        /// <returns>The extrinsic transformation between the two streams.</returns>
        public Extrinsics GetExtrinsics(Stream fromStream, Stream toStream)
        {
            Extrinsics result;
            GetExtrinsics(fromStream, toStream, out result);
            return result;
        }

        /// <summary>
        /// Gets the extrinsic transformation between the viewpoints of two different streams.
        /// </summary>
        /// <param name="fromStream">The stream whose coordinate space to transform from.</param>
        /// <param name="toStream">The stream whose coordinate space to transform to.</param>
        /// <param name="extrinsics">
        /// The result structure specifying the extrinsic transformation between the two streams.
        /// </param>
        public void GetExtrinsics(Stream fromStream, Stream toStream, out Extrinsics extrinsics)
        {
            IntPtr error;
            NativeMethods.rs_get_device_extrinsics(handle, fromStream, toStream, out extrinsics, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Gets the extrinsic transformation between a specific stream and the motion module.
        /// </summary>
        /// <param name="fromStream">The stream whose coordinate space to transform from.</param>
        /// <returns>The extrinsic transformation between the specific stream and the motion module.</returns>
        public Extrinsics GetMotionExtrinsics(Stream fromStream)
        {
            Extrinsics result;
            GetMotionExtrinsics(fromStream, out result);
            return result;
        }

        /// <summary>
        /// Gets the extrinsic transformation between a specific stream and the motion module.
        /// </summary>
        /// <param name="fromStream">The stream whose coordinate space to transform from.</param>
        /// <param name="extrinsics">
        /// The result structure specifying the extrinsic transformation between the
        /// specific stream and the motion module.
        /// </param>
        public void GetMotionExtrinsics(Stream fromStream, out Extrinsics extrinsics)
        {
            IntPtr error;
            NativeMethods.rs_get_motion_extrinsics_from(handle, fromStream, out extrinsics, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Gets a value indicating whether the device allows a specific option to be queried and set.
        /// </summary>
        /// <param name="option">The option to be queried.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="option"/> can be queried and set; otherwise, <b>false</b>.
        /// </returns>
        public bool SupportsOption(Option option)
        {
            IntPtr error;
            var result = NativeMethods.rs_device_supports_option(handle, option, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Gets the available streaming modes for a specific stream.
        /// </summary>
        /// <param name="stream">The stream for which to retrieve the available streaming modes.</param>
        /// <returns>
        /// The collection of streaming modes that are available for the specified stream.
        /// </returns>
        public IEnumerable<StreamMode> GetStreamModes(Stream stream)
        {
            IntPtr error;
            var count = NativeMethods.rs_get_stream_mode_count(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            for (int i = 0; i < count; i++)
            {
                StreamMode mode;
                NativeMethods.rs_get_stream_mode(
                    handle,
                    stream, i,
                    out mode.Width,
                    out mode.Height,
                    out mode.Format,
                    out mode.Framerate,
                    out error);
                NativeHelper.ThrowExceptionForRsError(error);
                yield return mode;
            }
        }

        /// <summary>
        /// Enables a specific stream and requests streaming properties following a preset.
        /// </summary>
        /// <param name="stream">The stream to enable.</param>
        /// <param name="preset">The preset used to enable the stream.</param>
        public void EnableStream(Stream stream, Preset preset)
        {
            IntPtr error;
            NativeMethods.rs_enable_stream_preset(handle, stream, preset, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Enables a specific stream with the specified streaming properties.
        /// </summary>
        /// <param name="stream">The stream to enable.</param>
        /// <param name="mode">The streaming properties used to enable the stream.</param>
        public void EnableStream(Stream stream, StreamMode mode)
        {
            EnableStream(stream, mode.Width, mode.Height, mode.Format, mode.Framerate);
        }

        /// <summary>
        /// Enables a specific stream with the specified streaming properties.
        /// </summary>
        /// <param name="stream">The stream to enable.</param>
        /// <param name="mode">The streaming properties used to enable the stream.</param>
        /// <param name="outputFormat">The output buffer format.</param>
        public void EnableStream(Stream stream, StreamMode mode, OutputBufferFormat outputFormat)
        {
            EnableStream(stream, mode.Width, mode.Height, mode.Format, mode.Framerate, outputFormat);
        }

        /// <summary>
        /// Enables a specific stream with the specified streaming properties.
        /// </summary>
        /// <param name="stream">The stream to enable.</param>
        /// <param name="width">Desired width of a frame image in pixels, or 0 if any width is acceptable.</param>
        /// <param name="height">Desired height of a frame image in pixels, or 0 if any height is acceptable.</param>
        /// <param name="format">Pixel format of a frame image.</param>
        /// <param name="framerate">Number of frames that will be streamed per second, or 0 if any frame rate is acceptable.</param>
        public void EnableStream(Stream stream, int width, int height, PixelFormat format, int framerate)
        {
            IntPtr error;
            NativeMethods.rs_enable_stream(handle, stream, width, height, format, framerate, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Enables a specific stream with the specified streaming properties.
        /// </summary>
        /// <param name="stream">The stream to enable.</param>
        /// <param name="width">Desired width of a frame image in pixels, or 0 if any width is acceptable.</param>
        /// <param name="height">Desired height of a frame image in pixels, or 0 if any height is acceptable.</param>
        /// <param name="format">Pixel format of a frame image.</param>
        /// <param name="framerate">Number of frames that will be streamed per second, or 0 if any frame rate is acceptable.</param>
        /// <param name="outputFormat">The output buffer format.</param>
        public void EnableStream(Stream stream, int width, int height, PixelFormat format, int framerate, OutputBufferFormat outputFormat)
        {
            IntPtr error;
            NativeMethods.rs_enable_stream_ex(handle, stream, width, height, format, framerate, outputFormat, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Disables a specific stream.
        /// </summary>
        /// <param name="stream">The stream to disable.</param>
        public void DisableStream(Stream stream)
        {
            IntPtr error;
            NativeMethods.rs_disable_stream(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Determines whether a specific stream is enabled.
        /// </summary>
        /// <param name="stream">The stream to be queried.</param>
        /// <returns>
        /// <b>true</b> if the stream is currently enabled; otherwise, <b>false</b>.
        /// </returns>
        public bool IsStreamEnabled(Stream stream)
        {
            IntPtr error;
            var result = NativeMethods.rs_is_stream_enabled(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Gets the currently enabled streaming mode for the specified stream.
        /// </summary>
        /// <param name="stream">The stream for which to retrieve the currently enabled streaming mode.</param>
        /// <returns>The currently enabled streaming mode for the specified stream.</returns>
        public StreamMode GetEnabledStreamMode(Stream stream)
        {
            StreamMode result;
            GetEnabledStreamMode(stream, out result);
            return result;
        }

        /// <summary>
        /// Gets the currently enabled streaming mode for the specified stream.
        /// </summary>
        /// <param name="stream">The stream for which to retrieve the currently enabled streaming mode.</param>
        /// <param name="mode">
        /// The result structure specifying the currently enabled streaming mode for the specified stream.
        /// </param>
        public void GetEnabledStreamMode(Stream stream, out StreamMode mode)
        {
            IntPtr error;
            mode.Width = NativeMethods.rs_get_stream_width(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            mode.Height = NativeMethods.rs_get_stream_height(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            mode.Format = NativeMethods.rs_get_stream_format(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            mode.Framerate = NativeMethods.rs_get_stream_framerate(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Gets the intrinsic camera parameters for a specific stream.
        /// </summary>
        /// <param name="stream">The stream for which to retrieve the intrinsic camera parameters.</param>
        /// <returns>The intrinsic camera parameters for the specified stream.</returns>
        public Intrinsics GetStreamIntrinsics(Stream stream)
        {
            Intrinsics result;
            GetStreamIntrinsics(stream, out result);
            return result;
        }

        /// <summary>
        /// Gets the intrinsic camera parameters for a specific stream.
        /// </summary>
        /// <param name="stream">The stream for which to retrieve the intrinsic camera parameters.</param>
        /// <param name="intrinsics">
        /// The result structure specifying the intrinsic camera parameters for the specified stream.
        /// </param>
        public void GetStreamIntrinsics(Stream stream, out Intrinsics intrinsics)
        {
            IntPtr error;
            NativeMethods.rs_get_stream_intrinsics(handle, stream, out intrinsics, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Gets the intrinsic parameters of the motion module.
        /// </summary>
        /// <returns>The intrinsic parameters of the motion module.</returns>
        public MotionIntrinsics GetMotionIntrinsics()
        {
            MotionIntrinsics result;
            GetMotionIntrinsics(out result);
            return result;
        }

        /// <summary>
        /// Gets the intrinsic parameters of the motion module.
        /// </summary>
        /// <param name="intrinsics">
        /// The result structure specifying the intrinsic parameters of the motion module.
        /// </param>
        public void GetMotionIntrinsics(out MotionIntrinsics intrinsics)
        {
            IntPtr error;
            NativeMethods.rs_get_motion_intrinsics(handle, out intrinsics, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Sets up a frame callback that is called immediately when an image is available,
        /// with no synchronization logic applied.
        /// </summary>
        /// <param name="stream">The stream for which to setup the callback.</param>
        /// <param name="onFrame">The function to be called whenever a new image is available.</param>
        public void SetFrameCallback(Stream stream, FrameCallback onFrame)
        {
            if (onFrame == null)
            {
                throw new ArgumentNullException("onFrame");
            }

            IntPtr error;
            NativeMethods.FrameCallback callback = (dev, frame, user) =>
            {
                var frameHandle = new FrameHandle(frame);
                onFrame(new Frame(frameHandle));
                NativeMethods.rs_release_frame(handle, frameHandle, IntPtr.Zero);
            };

            NativeMethods.rs_set_frame_callback(handle, stream, callback, IntPtr.Zero, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            callbacks.AddHandler(stream, callback);
        }

        /// <summary>
        /// Enables and configures motion-tracking data handlers.
        /// </summary>
        /// <param name="onMotion">The function to be called whenever new motion data arrives.</param>
        /// <param name="onTimestamp">The function to be called whenever new timestamp data arrives.</param>
        public void EnableMotionTracking(MotionCallback onMotion, TimestampCallback onTimestamp)
        {
            if (onMotion == null)
            {
                throw new ArgumentNullException("onMotion");
            }

            if (onTimestamp == null)
            {
                throw new ArgumentNullException("onTimestamp");
            }

            IntPtr error;
            NativeMethods.MotionCallback motionCallback = (dev, entry, user) => onMotion(entry);
            NativeMethods.TimestampCallback timestampCallback = (dev, entry, user) => onTimestamp(entry);
            NativeMethods.rs_enable_motion_tracking(handle, motionCallback, IntPtr.Zero, timestampCallback, IntPtr.Zero, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            callbacks.AddHandler(MotionEventHandler, motionCallback);
            callbacks.AddHandler(TimestampEventHandler, timestampCallback);
        }

        /// <summary>
        /// Disables motion-tracking event handlers.
        /// </summary>
        public void DisableMotionTracking()
        {
            IntPtr error;
            NativeMethods.rs_disable_motion_tracking(handle, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            callbacks[MotionEventHandler] = null;
            callbacks[TimestampEventHandler] = null;
        }

        /// <summary>
        /// Begins streaming on all enabled streams for this device.
        /// </summary>
        public void Start()
        {
            IntPtr error;
            NativeMethods.rs_start_device(handle, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Begins streaming on all enabled streams for this device.
        /// </summary>
        /// <param name="source">The data source to be activated.</param>
        public void Start(Source source)
        {
            IntPtr error;
            NativeMethods.rs_start_source(handle, source, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Ends data acquisition for all source providers.
        /// </summary>
        public void Stop()
        {
            IntPtr error;
            NativeMethods.rs_stop_device(handle, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Ends data acquisition for the specified source providers.
        /// </summary>
        /// <param name="source">The data source to be terminated.</param>
        public void Stop(Source source)
        {
            IntPtr error;
            NativeMethods.rs_stop_source(handle, source, out error);
            NativeHelper.ThrowExceptionForRsError(error);
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
        public void GetOptionRange(Option option, out double min, out double max, out double step)
        {
            IntPtr error;
            NativeMethods.rs_get_device_option_range(handle, option, out min, out max, out step, out error);
            NativeHelper.ThrowExceptionForRsError(error);
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
        public void GetOptionRange(Option option, out double min, out double max, out double step, out double defaultValue)
        {
            IntPtr error;
            NativeMethods.rs_get_device_option_range_ex(handle, option, out min, out max, out step, out defaultValue, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Gets the current value of a single option.
        /// </summary>
        /// <param name="option">The option for which to retrieve the value.</param>
        /// <returns>The current value of the specified option.</returns>
        public double GetOption(Option option)
        {
            IntPtr error;
            var value = NativeMethods.rs_get_device_option(handle, option, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return value;
        }

        /// <summary>
        /// Efficiently retrieves the value of an arbitrary number of options, using minimal hardware IO.
        /// </summary>
        /// <param name="options">The array of options to be queried.</param>
        /// <returns>The set of values for the queried options.</returns>
        public double[] GetOption(params Option[] options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            IntPtr error;
            var values = new double[options.Length];
            NativeMethods.rs_get_device_options(handle, options, (uint)options.Length, values, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return values;
        }

        /// <summary>
        /// Sets the current value of a single option.
        /// </summary>
        /// <param name="option">The option whose value should be set.</param>
        /// <param name="value">The value of the option.</param>
        public void SetOption(Option option, double value)
        {
            IntPtr error;
            NativeMethods.rs_set_device_option(handle, option, value, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Efficiently sets the value of an arbitrary number of options, using minimal hardware IO.
        /// </summary>
        /// <param name="options">The array of options that should be set.</param>
        /// <param name="values">The array of values to which the options should be set.</param>
        public void SetOption(Option[] options, double[] values)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (options.Length < values.Length)
            {
                throw new ArgumentException("The length of the array of options must match at least the number of specified values to set.", "options");
            }

            IntPtr error;
            NativeMethods.rs_set_device_options(handle, options, (uint)values.Length, values, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Efficiently resets the value of an arbitrary number of options.
        /// </summary>
        /// <param name="options">The array of options that should be set to their default values.</param>
        public void ResetOption(params Option[] options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            IntPtr error;
            NativeMethods.rs_reset_device_options_to_default(handle, options, options.Length, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Gets a static description of what a particular option does on the current device.
        /// </summary>
        /// <param name="option">The option for which to retrieve the description.</param>
        /// <returns>The description of what the option does on the current device.</returns>
        public string GetOptionDescription(Option option)
        {
            IntPtr error;
            var description = NativeMethods.rs_get_device_option_description(handle, option, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return Marshal.PtrToStringAnsi(description);
        }

        /// <summary>
        /// Blocks until new frames are available.
        /// </summary>
        public void WaitForFrames()
        {
            IntPtr error;
            NativeMethods.rs_wait_for_frames(handle, out error);
            NativeHelper.ThrowExceptionForRsError(error);
        }

        /// <summary>
        /// Checks whether new frames are available, without blocking.
        /// </summary>
        /// <returns>
        /// <b>true</b> if new frames are available; otherwise, <b>false</b>.
        /// </returns>
        public bool PollForFrames()
        {
            IntPtr error;
            var result = NativeMethods.rs_poll_for_frames(handle, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Gets a value indicating whether the device supports the specified capability.
        /// </summary>
        /// <param name="capability">The capability to test.</param>
        /// <returns>
        /// <b>true</b> if the device supports the specified capability; otherwise, <b>false</b>.
        /// </returns>
        public bool Supports(Capabilities capability)
        {
            IntPtr error;
            var result = NativeMethods.rs_supports(handle, capability, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Gets a value indicating whether a given camera information parameter is supported by the device.
        /// </summary>
        /// <param name="info">The information parameter to test.</param>
        /// <returns>
        /// <b>true</b> if the parameter both exists and is well-defined for the specific device;
        /// otherwise, <b>false</b>.
        /// </returns>
        public bool SupportsCameraInfo(CameraInfo info)
        {
            IntPtr error;
            var result = NativeMethods.rs_supports_camera_info(handle, info, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return result != 0;
        }

        /// <summary>
        /// Gets the time at which the latest frame on the specified stream was captured.
        /// </summary>
        /// <param name="stream">The stream for which to retrieve the latest frame timestamp.</param>
        /// <returns>The timestamp of the latest frame, in milliseconds since the device was started.</returns>
        public double GetFrameTimestamp(Stream stream)
        {
            IntPtr error;
            var timestamp = NativeMethods.rs_get_frame_timestamp(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return timestamp;
        }

        /// <summary>
        /// Gets the number of the latest frame to be captured on the specified stream.
        /// </summary>
        /// <param name="stream">The stream for which to retrieve the latest frame number.</param>
        /// <returns>The number of the latest frame captured on the specified stream.</returns>
        public ulong GetFrameNumber(Stream stream)
        {
            IntPtr error;
            var frameNumber = NativeMethods.rs_get_frame_number(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return frameNumber;
        }

        /// <summary>
        /// Gets a pointer to the contents of the latest frame to be captured on the specified stream.
        /// </summary>
        /// <param name="stream">The stream for which to retrieve the latest frame contents.</param>
        /// <returns>A pointer to the contents of the latest frame captured on the specified stream.</returns>
        public IntPtr GetFrameData(Stream stream)
        {
            IntPtr error;
            var frameData = NativeMethods.rs_get_frame_data(handle, stream, out error);
            NativeHelper.ThrowExceptionForRsError(error);
            return frameData;
        }
    }
}
