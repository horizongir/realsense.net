using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    /// <summary>
    /// Specifies the kind of connected devices that should be returned by a call to <see cref="Context.QueryDevices(ProductLines)"/>
    /// </summary>
    [Flags]
    public enum ProductLines
    {
        /// <summary>
        /// Specifies that all connected devices should be returned.
        /// </summary>
        Any = 0xFF,

        /// <summary>
        /// Specifies that all connected Intel devices should be returned.
        /// </summary>
        AnyIntel = 0xFE,

        /// <summary>
        /// Specifies that all connected non-Intel devices should be returned.
        /// </summary>
        NonIntel = 0x01,

        /// <summary>
        /// Specifies that all connected devices of the D400 series should be returned.
        /// </summary>
        D400 = 0x02,

        /// <summary>
        /// Specifies that all connected devices of the SR300 series should be returned.
        /// </summary>
        SR300 = 0x04,

        /// <summary>
        /// Specifies that all connected devices of the L500 series should be returned.
        /// </summary>
        L500 = 0x08,

        /// <summary>
        /// Specifies that all connected devices of the T200 series should be returned.
        /// </summary>
        T200 = 0x10,

        /// <summary>
        /// Specifies that all connected depth cameras should be returned.
        /// </summary>
        Depth = L500 | SR300 | D400,

        /// <summary>
        /// Specifies that all connected tracking cameras should be returned.
        /// </summary>
        Tracking = T200
    }

    /// <summary>
    /// Specifies the different types of data provided by RealSense devices.
    /// </summary>
    public enum Stream
    {
        /// <summary>
        /// Specifies any type of native stream.
        /// </summary>
        Any,

        /// <summary>
        /// Native stream of depth data produced by RealSense device.
        /// </summary>
        Depth,

        /// <summary>
        /// Native stream of color data captured by RealSense device.
        /// </summary>
        Color,

        /// <summary>
        /// Native stream of infrared data captured by RealSense device.
        /// </summary>
        Infrared,

        /// <summary>
        /// Native stream of fish-eye (wide) data captured from the dedicated motion camera.
        /// </summary>
        Fisheye,

        /// <summary>
        /// Native stream of gyroscope motion data produced by RealSense device.
        /// </summary>
        Gyroscope,

        /// <summary>
        /// Native stream of accelerometer motion data produced by RealSense device.
        /// </summary>
        Accelerometer,

        /// <summary>
        /// Signals from external device connected through GPIO.
        /// </summary>
        Gpio,

        /// <summary>
        /// 6 Degrees of Freedom pose data, calculated by RealSense device.
        /// </summary>
        Pose,

        /// <summary>
        /// 4 bit per-pixel depth confidence level.
        /// </summary>
        Confidence
    }

    /// <summary>
    /// Specifies how a frame is represented in memory.
    /// </summary>
    public enum PixelFormat
    {
        /// <summary>
        /// When passed to enable stream, librealsense will try to provide best suited format.
        /// </summary>
        Any,

        /// <summary>
        /// 16-bit linear depth values. The depth is meters is equal to depth scale * pixel value.
        /// </summary>
        Z16,

        /// <summary>
        /// 16-bit linear disparity values. The depth in meters is equal to depth scale / pixel value.
        /// </summary>
        Disparity16,

        /// <summary>
        /// 32-bit floating point 3D coordinates.
        /// </summary>
        Xyz32f,

        /// <summary>
        /// Standard YUV pixel format as described in https://en.wikipedia.org/wiki/YUV.
        /// </summary>
        Yuyv,

        /// <summary>
        /// 8-bit red, green and blue channels.
        /// </summary>
        Rgb8,

        /// <summary>
        /// 8-bit blue, green, and red channels -- suitable for OpenCV.
        /// </summary>
        Bgr8,

        /// <summary>
        /// 8-bit red, green and blue channels + constant alpha channel equal to FF.
        /// </summary>
        Rgba8,

        /// <summary>
        /// 8-bit blue, green, and red channels + constant alpha channel equal to FF.
        /// </summary>
        Bgra8,

        /// <summary>
        /// 8-bit per-pixel grayscale image.
        /// </summary>
        Y8,

        /// <summary>
        /// 16-bit per-pixel grayscale image.
        /// </summary>
        Y16,

        /// <summary>
        /// Four 10-bit luminance values encoded into a 5-byte macropixel.
        /// </summary>
        Raw10,

        /// <summary>
        /// 16-bit raw image.
        /// </summary>
        Raw16,

        /// <summary>
        /// 8-bit raw image.
        /// </summary>
        Raw8,

        /// <summary>
        /// Similar to the standard YUYV pixel format, but packed in a different order.
        /// </summary>
        Uyvy,

        /// <summary>
        /// Raw data from the motion sensor.
        /// </summary>
        MotionRaw,

        /// <summary>
        /// Motion data packed as 3 32-bit float values, for X, Y, and Z axis.
        /// </summary>
        MotionXyz32f,

        /// <summary>
        /// Raw data from the external sensors hooked to one of the GPIO's.
        /// </summary>
        GpioRaw,

        /// <summary>
        /// Pose data packed as floats array, containing translation vector, rotation quaternion and prediction velocities and accelerations vectors.
        /// </summary>
        Pose6Dof,

        /// <summary>
        /// 32-bit float-point disparity values. Depth->Disparity conversion : Disparity = Baseline*FocalLength/Depth
        /// </summary>
        Disparity32,

        /// <summary>
        /// 16-bit per-pixel grayscale image unpacked from 10 bits per pixel packed ([8:8:8:8:2222]) grey-scale image.
        /// The data is unpacked to LSB and padded with 6 zero bits.
        /// </summary>
        Y10BPack,

        /// <summary>
        /// 32-bit float-point depth distance value.
        /// </summary>
        Distance
    }

    /// <summary>
    /// Specifies the distortion model defining how pixel coordinates should be mapped to sensor coordinates.
    /// </summary>
    public enum Distortion
    {
        /// <summary>
        /// Rectilinear images. No distortion compensation required.
        /// </summary>
        None,

        /// <summary>
        /// Equivalent to Brown-Conrady distortion, except that tangential distortion is applied to radially distorted points.
        /// </summary>
        ModifiedBrownConrady,

        /// <summary>
        /// Equivalent to Brown-Conrady distortion, except undistorts image instead of distorting it.
        /// </summary>
        InverseBrownConrady,

        /// <summary>
        /// Distortion model of the fish-eye camera.
        /// </summary>
        FTheta
    }

    /// <summary>
    /// Specifies optimized settings for different types of usage in SR300 devices.
    /// </summary>
    public enum SR300VisualPreset
    {
        /// <summary>
        /// Preset for short range.
        /// </summary>
        ShortRange,

        /// <summary>
        /// Preset for long range.
        /// </summary>
        LongRange,

        /// <summary>
        /// Preset for background segmentation.
        /// </summary>
        BackgroundSegmentation,

        /// <summary>
        /// Preset for gesture recognition.
        /// </summary>
        GestureRecognition,

        /// <summary>
        /// Preset for object scanning.
        /// </summary>
        ObjectScanning,

        /// <summary>
        /// Preset for face analytics.
        /// </summary>
        FaceAnalytics,

        /// <summary>
        /// Preset for face login.
        /// </summary>
        FaceLogin,

        /// <summary>
        /// Preset for GR cursor.
        /// </summary>
        GrCursor,

        /// <summary>
        /// Preset for default.
        /// </summary>
        Default,

        /// <summary>
        /// Preset for mid-range.
        /// </summary>
        MidRange,

        /// <summary>
        /// Preset for IR only.
        /// </summary>
        IrOnly
    }

    /// <summary>
    /// Specifies optimized settings for different types of usage in D400 devices.
    /// </summary>
    public enum D400VisualPreset
    {
        /// <summary>
        /// Specifies a custom settings preset.
        /// </summary>
        Custom,

        /// <summary>
        /// Best Visual appeal, Clean edges, Reduced PointCloud Spraying.
        /// </summary>
        Default,

        /// <summary>
        /// Good for Hand Tracking, Gesture recognition, good edges.
        /// </summary>
        Hand,

        /// <summary>
        /// High confidence threshold value of depth, lower fill factor (e.g. Object Scanning, Collision Avoidance, Robots).
        /// </summary>
        HighAccuracy,

        /// <summary>
        /// Higher Fill factor, sees more objects (e.g. BGS and 3D Enhanced Photography, Object recognition).
        /// </summary>
        HighDensity,

        /// <summary>
        /// Balance between Fill factor and accuracy.
        /// </summary>
        MediumDensity,

        /// <summary>
        /// Removes the Projector-generated IR pattern from left imager when streaming synthetic RGB.
        /// Applies to D415 and D410 Devices.
        /// </summary>
        RemoveIrPattern
    }

    /// <summary>
    /// Specifies optimized settings for different types of usage in L500 devices.
    /// </summary>
    public enum L500VisualPreset
    {
        /// <summary>
        /// Specifies a custom settings preset.
        /// </summary>
        Custom,

        /// <summary>
        /// The default preset.
        /// </summary>
        Default,

        /// <summary>
        /// Preset for no ambient light.
        /// </summary>
        NoAmbient,

        /// <summary>
        /// Preset for low ambient light.
        /// </summary>
        LowAmbient,

        /// <summary>
        /// Preset for max range.
        /// </summary>
        MaxRange,

        /// <summary>
        /// Preset for short range.
        /// </summary>
        ShortRange
    }

    /// <summary>
    /// Specifies general device configuration controls.
    /// </summary>
    /// <remarks>
    /// These can generally be mapped to camera UVC controls, and unless stated otherwise,
    /// can be set or queried at any time.
    /// </remarks>
    public enum Option
    {
        /// <summary>
        /// Enable/disable color backlight compensation.
        /// </summary>
        BacklightCompensation,

        /// <summary>
        /// Color image brightness.
        /// </summary>
        Brightness,

        /// <summary>
        /// Color image contrast.
        /// </summary>
        Contrast,

        /// <summary>
        /// Controls exposure time of color camera. Setting any value will disable auto exposure.
        /// </summary>
        Exposure,

        /// <summary>
        /// Color image gain.
        /// </summary>
        Gain,

        /// <summary>
        /// Color image gamma setting.
        /// </summary>
        Gamma,

        /// <summary>
        /// Color image hue.
        /// </summary>
        Hue,

        /// <summary>
        /// Color image saturation setting.
        /// </summary>
        Saturation,

        /// <summary>
        /// Color image sharpness setting.
        /// </summary>
        Sharpness,

        /// <summary>
        /// Controls white balance of color image. Setting any value will disable auto white balance.
        /// </summary>
        WhiteBalance,

        /// <summary>
        /// Enable/disable color image auto-exposure.
        /// </summary>
        EnableAutoExposure,

        /// <summary>
        /// Enable/disable color image auto-white-balance.
        /// </summary>
        EnableAutoWhiteBalance,

        /// <summary>
        /// Provide access to several recommend sets of option presets for the depth camera.
        /// </summary>
        VisualPreset,

        /// <summary>
        /// Power of the F200/SR300 projector, with 0 meaning projector off.
        /// </summary>
        LaserPower,

        /// <summary>
        /// Set the number of patterns projected per frame. The higher the accuracy value, the more patterns projected. Increasing the number of patterns helps to achieve better accuracy. Note that this control affects the depth FPS.
        /// </summary>
        Accuracy,

        /// <summary>
        /// Motion vs. range trade-off, with lower values allowing for better motion sensitivity and higher values allowing for better depth range.
        /// </summary>
        MotionRange,

        /// <summary>
        /// Set the filter to apply to each depth frame. Each one of the filters is optimized per the application requirements.
        /// </summary>
        FilterOption,

        /// <summary>
        /// Confidence level threshold used by the depth algorithm pipe to set whether a pixel will get a valid range or will be marked with invalid range.
        /// </summary>
        ConfidenceThreshold,

        /// <summary>
        /// Laser Emitter enabled.
        /// </summary>
        EmitterEnabled,

        /// <summary>
        /// Number of frames the user is allowed to keep per stream. Trying to hold on to more frames will cause frame-drops.
        /// </summary>
        FramesQueueSize,

        /// <summary>
        /// Total number of detected frame drops from all streams.
        /// </summary>
        TotalFrameDrops,

        /// <summary>
        /// 0 - static auto-exposure, 1 - anti-flicker auto-exposure, 2 - hybrid.
        /// </summary>
        AutoExposureMode,

        /// <summary>
        /// Power Line Frequency control for anti-flickering Off/50Hz/60Hz/Auto.
        /// </summary>
        PowerLineFrequency,

        /// <summary>
        /// Current Asic Temperature.
        /// </summary>
        AsicTemperature,

        /// <summary>
        /// Disable error handling.
        /// </summary>
        ErrorPollingEnabled,

        /// <summary>
        /// Current Projector Temperature.
        /// </summary>
        ProjectorTemperature,

        /// <summary>
        /// Enable / disable trigger to be outputed from the camera to any external device on every depth frame.
        /// </summary>
        OutputTriggerEnabled,

        /// <summary>
        /// Current Motion-Module Temperature.
        /// </summary>
        MotionModuleTemperature,

        /// <summary>
        /// Number of meters represented by a single depth unit.
        /// </summary>
        DepthUnits,

        /// <summary>
        /// Enable/Disable automatic correction of the motion data.
        /// </summary>
        EnableMotionCorrection,

        /// <summary>
        /// Allows sensor to dynamically ajust the frame rate depending on lighting conditions.
        /// </summary>
        AutoExposurePriority,

        /// <summary>
        /// Color scheme for data visualization.
        /// </summary>
        ColorScheme,

        /// <summary>
        /// Perform histogram equalization post-processing on the depth data.
        /// </summary>
        HistogramEqualizationEnabled,

        /// <summary>
        /// Minimal distance to the target.
        /// </summary>
        MinDistance,

        /// <summary>
        /// Maximum distance to the target.
        /// </summary>
        MaxDistance,

        /// <summary>
        /// Texture mapping stream unique ID.
        /// </summary>
        TextureSource,

        /// <summary>
        /// The 2D-filter effect. The specific interpretation is given within the context of the filter.
        /// </summary>
        FilterMagnitude,

        /// <summary>
        /// 2D-filter parameter controls the weight/radius for smoothing.
        /// </summary>
        FilterSmoothAlpha,

        /// <summary>
        /// 2D-filter range/validity threshold.
        /// </summary>
        FilterSmoothDelta,

        /// <summary>
        /// Enhance depth data post-processing with holes filling where appropriate.
        /// </summary>
        HolesFill,

        /// <summary>
        /// The distance in mm between the first and the second imagers in stereo-based depth cameras.
        /// </summary>
        StereoBaseline,

        /// <summary>
        /// Allows dynamically ajust the converge step value of the target exposure in Auto-Exposure algorithm.
        /// </summary>
        AutoExposureConvergeStep,

        /// <summary>
        /// Impose Inter-camera HW synchronization mode. Applicable for D400/Rolling Shutter SKUs.
        /// </summary>
        InterCamSyncMode,

        /// <summary>
        /// Select a stream to process.
        /// </summary>
        StreamFilter,

        /// <summary>
        /// Select a stream format to process.
        /// </summary>
        StreamFormatFilter,

        /// <summary>
        /// Select a stream index to process.
        /// </summary>
        StreamIndexFilter,

        /// <summary>
        /// When supported, this option make the camera to switch the emitter state every frame. 0 for disabled, 1 for enabled.
        /// </summary>
        EmitterOnOff,

        /// <summary>
        /// Zero order point x.
        /// </summary>
        ZeroOrderPointX,

        /// <summary>
        /// Zero order point y.
        /// </summary>
        ZeroOrderPointY,

        /// <summary>
        /// LLD temperature.
        /// </summary>
        LldTemperature,

        /// <summary>
        /// MC temperature.
        /// </summary>
        McTemperature,

        /// <summary>
        /// MA temperature.
        /// </summary>
        MaTemperature,

        /// <summary>
        /// Hardware stream configuration.
        /// </summary>
        HardwarePreset,

        /// <summary>
        /// disable global time .
        /// </summary>
        GlobalTimeEnabled,

        /// <summary>
        /// APD temperature.
        /// </summary>
        ApdTemperature,

        /// <summary>
        /// Enable an internal map.
        /// </summary>
        EnableMapping,

        /// <summary>
        /// Enable appearance based relocalization.
        /// </summary>
        EnableRelocalization,

        /// <summary>
        /// Enable position jumping.
        /// </summary>
        EnablePoseJumping,

        /// <summary>
        /// Enable dynamic calibration.
        /// </summary>
        EnableDynamicCalibration,

        /// <summary>
        /// Offset from sensor to depth origin in millimetrers.
        /// </summary>
        DepthOffset,

        /// <summary>
        /// Power of the LED (light emitting diode), with 0 meaning LED off.
        /// </summary>
        LedPower,

        /// <summary>
        /// Toggle Zero-Order mode.
        /// </summary>
        ZeroOrderEnabled,

        /// <summary>
        /// Preserve previous map when starting.
        /// </summary>
        EnableMapPreservation,

        /// <summary>
        /// Enable/disable sensor shutdown when a free-fall is detected (on by default).
        /// </summary>
        FreefallDetectionEnabled,

        /// <summary>
        /// Changes the exposure time of Avalanche Photo Diode in the receiver.
        /// </summary>
        AvalanchePhotoDiode,

        /// <summary>
        /// Changes the amount of sharpening in the post-processed image.
        /// </summary>
        PostProcessingSharpening,

        /// <summary>
        /// Changes the amount of sharpening in the pre-processed image.
        /// </summary>
        PreProcessingSharpening,

        /// <summary>
        /// Control edges and background noise.
        /// </summary>
        NoiseFiltering,

        /// <summary>
        /// Enable\disable pixel invalidation.
        /// </summary>
        InvalidationBypass,

        /// <summary>
        /// Change the depth ambient light: see AmbientLight method documentation for values.
        /// </summary>
        AmbientLight,

        /// <summary>
        /// The resolution mode: see SensorMode method documentation for values.
        /// </summary>
        SensorMode
    }

    /// <summary>
    /// Specifies the types of value provided from the device with each frame.
    /// </summary>
    public enum FrameMetadata
    {
        /// <summary>
        /// A sequential index managed per-stream. Integer value.
        /// </summary>
        FrameCounter,

        /// <summary>
        /// Timestamp set by device clock when data readout and transmit commence. usec.
        /// </summary>
        FrameTimestamp,

        /// <summary>
        /// Timestamp of the middle of sensor's exposure calculated by device. usec.
        /// </summary>
        SensorTimestamp,

        /// <summary>
        /// Sensor's exposure width. When Auto Exposure (AE) is on the value is controlled by firmware. usec.
        /// </summary>
        ActualExposure,

        /// <summary>
        /// A relative value increasing which will increase the Sensor's gain factor. When AE is set On, the value is controlled by firmware. Integer value.
        /// </summary>
        GainLevel,

        /// <summary>
        /// Auto Exposure Mode indicator. Zero corresponds to AE switched off..
        /// </summary>
        AutoExposure,

        /// <summary>
        /// White Balance setting as a color temperature. Kelvin degrees.
        /// </summary>
        WhiteBalance,

        /// <summary>
        /// Time of arrival in system clock.
        /// </summary>
        TimeOfArrival,

        /// <summary>
        /// Temperature of the device, measured at the time of the frame capture. Celsius degrees.
        /// </summary>
        Temperature,

        /// <summary>
        /// Timestamp get from uvc driver. usec.
        /// </summary>
        BackendTimestamp,

        /// <summary>
        /// Actual fps.
        /// </summary>
        ActualFps,

        /// <summary>
        /// Laser power value 0-360..
        /// </summary>
        FrameLaserPower,

        /// <summary>
        /// Laser power mode. Zero corresponds to Laser power switched off and one for switched on..
        /// </summary>
        FrameLaserPowerMode,

        /// <summary>
        /// Exposure priority..
        /// </summary>
        ExposurePriority,

        /// <summary>
        /// Left region of interest for the auto exposure Algorithm..
        /// </summary>
        ExposureRoiLeft,

        /// <summary>
        /// Right region of interest for the auto exposure Algorithm..
        /// </summary>
        ExposureRoiRight,

        /// <summary>
        /// Top region of interest for the auto exposure Algorithm..
        /// </summary>
        ExposureRoiTop,

        /// <summary>
        /// Bottom region of interest for the auto exposure Algorithm..
        /// </summary>
        ExposureRoiBottom,

        /// <summary>
        /// Color image brightness..
        /// </summary>
        Brightness,

        /// <summary>
        /// Color image contrast..
        /// </summary>
        Contrast,

        /// <summary>
        /// Color image saturation..
        /// </summary>
        Saturation,

        /// <summary>
        /// Color image sharpness..
        /// </summary>
        Sharpness,

        /// <summary>
        /// Auto white balance temperature Mode indicator. Zero corresponds to automatic mode switched off..
        /// </summary>
        AutoWhiteBalanceTemperature,

        /// <summary>
        /// Color backlight compensation. Zero corresponds to switched off..
        /// </summary>
        BacklightCompensation,

        /// <summary>
        /// Color image hue..
        /// </summary>
        Hue,

        /// <summary>
        /// Color image gamma..
        /// </summary>
        Gamma,

        /// <summary>
        /// Color image white balance..
        /// </summary>
        ManualWhiteBalance,

        /// <summary>
        /// Power Line Frequency for anti-flickering Off/50Hz/60Hz/Auto..
        /// </summary>
        PowerLineFrequency,

        /// <summary>
        /// Color lowlight compensation. Zero corresponds to switched off..
        /// </summary>
        LowLightCompensation
    }

    /// <summary>
    /// Specifies several read-only strings that can be queried from the device.
    /// </summary>
    /// <remarks>
    /// Not all information fields are available on all camera types. This information is
    /// mainly available for camera debug and troubleshooting and should not be used in applications.
    /// </remarks>
    public enum CameraInfo
    {
        /// <summary>
        /// Device friendly name.
        /// </summary>
        Name,

        /// <summary>
        /// Device serial number.
        /// </summary>
        SerialNumber,

        /// <summary>
        /// Primary firmware version.
        /// </summary>
        FirmwareVersion,

        /// <summary>
        /// Recommended firmware version.
        /// </summary>
        RecommendedFirmwareVersion,

        /// <summary>
        /// Unique identifier of the port the device is connected to (platform specific).
        /// </summary>
        PhysicalPort,

        /// <summary>
        /// If device supports firmware logging, this is the command to send to get logs from firmware.
        /// </summary>
        DebugOpCode,

        /// <summary>
        /// True iff the device is in advanced mode.
        /// </summary>
        AdvancedMode,

        /// <summary>
        /// Product ID as reported in the USB descriptor.
        /// </summary>
        ProductId,

        /// <summary>
        /// True iff EEPROM is locked.
        /// </summary>
        CameraLocked,

        /// <summary>
        /// Designated USB specification: USB2/USB3.
        /// </summary>
        UsbTypeDescriptor,

        /// <summary>
        /// Device product line D400/SR300/L500/T200.
        /// </summary>
        ProductLine,

        /// <summary>
        /// ASIC serial number.
        /// </summary>
        AsicSerialNumber,

        /// <summary>
        /// Firmware update ID.
        /// </summary>
        FirmwareUpdateId
    }

    /// <summary>
    /// Specifies the severity of the API logger.
    /// </summary>
    public enum LogSeverity
    {
        /// <summary>
        /// Detailed information about ordinary operations.
        /// </summary>
        Debug,

        /// <summary>
        /// Terse information about ordinary operations.
        /// </summary>
        Info,

        /// <summary>
        /// Indication of possible failure.
        /// </summary>
        Warn,

        /// <summary>
        /// Indication of definite failure.
        /// </summary>
        Error,

        /// <summary>
        /// Indication of unrecoverable failure.
        /// </summary>
        Fatal,

        /// <summary>
        /// No logging will occur.
        /// </summary>
        None
    }

    /// <summary>
    /// Specifies the clock in relation to which the frame timestamp was measured.
    /// </summary>
    public enum TimestampDomain
    {
        /// <summary>
        /// Frame timestamp was measured in relation to the camera clock.
        /// </summary>
        HardwareClock,

        /// <summary>
        /// Frame timestamp was measured in relation to the OS system clock.
        /// </summary>
        SystemTime,

        /// <summary>
        /// Frame timestamp was measured in relation to the camera clock and
        /// converted to the OS system clock by constantly measuring the difference.
        /// </summary>
        GlobalTime
    }

    /// <summary>
    /// Specifies advanced interfaces or capabilities that API objects may implement.
    /// </summary>
    public enum Extension
    {
        /// <summary>
        /// Specifies an Unknown extension.
        /// </summary>
        Unknown,

        /// <summary>
        /// Specifies a Debug extension.
        /// </summary>
        Debug,

        /// <summary>
        /// Specifies an Info extension.
        /// </summary>
        Info,

        /// <summary>
        /// Specifies a Motion extension.
        /// </summary>
        Motion,

        /// <summary>
        /// Specifies an Options extension.
        /// </summary>
        Options,

        /// <summary>
        /// Specifies a Video extension.
        /// </summary>
        Video,

        /// <summary>
        /// Specifies a Roi extension.
        /// </summary>
        Roi,

        /// <summary>
        /// Specifies a DepthSensor extension.
        /// </summary>
        DepthSensor,

        /// <summary>
        /// Specifies a VideoFrame extension.
        /// </summary>
        VideoFrame,

        /// <summary>
        /// Specifies a MotionFrame extension.
        /// </summary>
        MotionFrame,

        /// <summary>
        /// Specifies a CompositeFrame extension.
        /// </summary>
        CompositeFrame,

        /// <summary>
        /// Specifies a Points extension.
        /// </summary>
        Points,

        /// <summary>
        /// Specifies a DepthFrame extension.
        /// </summary>
        DepthFrame,

        /// <summary>
        /// Specifies an AdvancedMode extension.
        /// </summary>
        AdvancedMode,

        /// <summary>
        /// Specifies a Record extension.
        /// </summary>
        Record,

        /// <summary>
        /// Specifies a VideoProfile extension.
        /// </summary>
        VideoProfile,

        /// <summary>
        /// Specifies a Playback extension.
        /// </summary>
        Playback,

        /// <summary>
        /// Specifies a DepthStereoSensor extension.
        /// </summary>
        DepthStereoSensor,

        /// <summary>
        /// Specifies a DisparityFrame extension.
        /// </summary>
        DisparityFrame,

        /// <summary>
        /// Specifies a MotionProfile extension.
        /// </summary>
        MotionProfile,

        /// <summary>
        /// Specifies a PoseFrame extension.
        /// </summary>
        PoseFrame,

        /// <summary>
        /// Specifies a PoseProfile extension.
        /// </summary>
        PoseProfile,

        /// <summary>
        /// Specifies a Tm2 extension.
        /// </summary>
        Tm2,

        /// <summary>
        /// Specifies a SoftwareDevice extension.
        /// </summary>
        SoftwareDevice,

        /// <summary>
        /// Specifies a SoftwareSensor extension.
        /// </summary>
        SoftwareSensor,

        /// <summary>
        /// Specifies a DecimationFilter extension.
        /// </summary>
        DecimationFilter,

        /// <summary>
        /// Specifies a ThresholdFilter extension.
        /// </summary>
        ThresholdFilter,

        /// <summary>
        /// Specifies a DisparityFilter extension.
        /// </summary>
        DisparityFilter,

        /// <summary>
        /// Specifies a SpatialFilter extension.
        /// </summary>
        SpatialFilter,

        /// <summary>
        /// Specifies a TemporalFilter extension.
        /// </summary>
        TemporalFilter,

        /// <summary>
        /// Specifies a HoleFillingFilter extension.
        /// </summary>
        HoleFillingFilter,

        /// <summary>
        /// Specifies a ZeroOrderFilter extension.
        /// </summary>
        ZeroOrderFilter,

        /// <summary>
        /// Specifies a RecommendedFilters extension.
        /// </summary>
        RecommendedFilters,

        /// <summary>
        /// Specifies a Pose extension.
        /// </summary>
        Pose,

        /// <summary>
        /// Specifies a PoseSensor extension.
        /// </summary>
        PoseSensor,

        /// <summary>
        /// Specifies a WheelOdometer extension.
        /// </summary>
        WheelOdometer,

        /// <summary>
        /// Specifies a GlobalTimer extension.
        /// </summary>
        GlobalTimer,

        /// <summary>
        /// Specifies an Updatable extension.
        /// </summary>
        Updatable,

        /// <summary>
        /// Specifies an UpdateDevice extension.
        /// </summary>
        UpdateDevice
    }

    /// <summary>
    /// Represents the method that will be invoked whenever a new frame arrives.
    /// </summary>
    /// <param name="frame">The frame data object.</param>
    public delegate void FrameCallback(Frame frame);

    /// <summary>
    /// Represents the method that will be invoked whenever a new message needs to be logged.
    /// </summary>
    /// <param name="severity">The severity of the logged message.</param>
    /// <param name="message">The message to be logged.</param>
    public delegate void LogCallback(LogSeverity severity, string message);

    /// <summary>
    /// Represents the method that will be invoked whenever a new RealSense device is connected
    /// or an existing device is disconnected.
    /// </summary>
    /// <param name="removed">The collection of removed devices.</param>
    /// <param name="added">The collection of added devices.</param>
    public delegate void DevicesChangedCallback(DeviceCollection removed, DeviceCollection added);
}
