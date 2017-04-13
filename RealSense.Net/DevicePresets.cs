using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSense.Net
{
    public partial class Device
    {
        static readonly Option[] DepthControlOptions = new[]
        {
            Option.R200DepthControlEstimateMedianDecrement,
            Option.R200DepthControlEstimateMedianIncrement,
            Option.R200DepthControlMedianThreshold,
            Option.R200DepthControlScoreMinimumThreshold,
            Option.R200DepthControlScoreMaximumThreshold,
            Option.R200DepthControlTextureCountThreshold,
            Option.R200DepthControlTextureDifferenceThreshold,
            Option.R200DepthControlSecondPeakThreshold,
            Option.R200DepthControlNeighborThreshold,
            Option.R200DepthControlLRThreshold
        };

        static readonly double[][] DepthControlPresetValues = new[]
        {
            new double[] {5, 5, 192,  1,  512, 6, 24, 27,  7,   24},
            new double[] {5, 5,   0,  0, 1023, 0,  0,  0,  0, 2047},
            new double[] {5, 5, 115,  1,  512, 6, 18, 25,  3,   24},
            new double[] {5, 5, 185,  5,  505, 6, 35, 45, 45,   14},
            new double[] {5, 5, 175, 24,  430, 6, 48, 47, 24,   12},
            new double[] {5, 5, 235, 27,  420, 8, 80, 70, 90,   12}
        };

        /// <summary>
        /// Applies recommended settings for depth control parameters in R200 devices.
        /// </summary>
        /// <param name="preset">The set of depth control option presets to apply.</param>
        public void ApplyDepthControlPreset(DepthControlPreset preset)
        {
            SetOption(DepthControlOptions, DepthControlPresetValues[(int)preset]);
        }

        static readonly Option[] IVCamOptions = new[]
        {
            Option.Sr300AutoRangeEnableMotionVersusRange,
            Option.Sr300AutoRangeEnableLaser,
            Option.Sr300AutoRangeMinMotionVersusRange,
            Option.Sr300AutoRangeMaxMotionVersusRange,
            Option.Sr300AutoRangeStartMotionVersusRange,
            Option.Sr300AutoRangeMinLaser,
            Option.Sr300AutoRangeMaxLaser,
            Option.Sr300AutoRangeStartLaser,
            Option.Sr300AutoRangeUpperThreshold,
            Option.Sr300AutoRangeLowerThreshold,
            Option.F200LaserPower,
            Option.F200Accuracy,
            Option.F200FilterOption,
            Option.F200ConfidenceThreshold,
            Option.F200MotionRange
        };

        static readonly double[][] IVCamPresetValues = new[]
        {
            new double[] {1,     1, 180,  303,  180,   2,  16,  -1, 1000, 450,  1,  1,  5,  1},
            new double[] {1,     0, 303,  605,  303,  -1,  -1,  -1, 1250, 975,  1,  1,  7,  0},
            new double[] {0,     0,  -1,   -1,   -1,  -1,  -1,  -1,   -1,  -1, 16,  1,  6,  2, 22},
            new double[] {1,     1, 100,  179,  100,   2,  16,  -1, 1000, 450,  1,  1,  6,  3},
            new double[] {0,     1,  -1,   -1,   -1,   2,  16,  16, 1000, 450,  1,  1,  3,  1,  9},
            new double[] {0,     0,  -1,   -1,   -1,  -1,  -1,  -1,   -1,  -1, 16,  1,  5,  1, 22},
            new double[] {2,     0,  40, 1600,  800,  -1,  -1,  -1,   -1,  -1,  1},
            new double[] {1,     1, 100,  179,  179,   2,  16,  -1, 1000, 450,  1,  1,  6,  1},
            new double[] {0,     0,  -1,   -1,   -1,  -1,  -1,  -1,   -1,  -1, 16,  1,  5,  3,  9},
            new double[] {1,     1, 180,  605,  303,   2,  16,  -1, 1250, 650,  1,  1,  5,  1},
            new double[] {2,     0,  40, 1600,  800,  -1,  -1,  -1,   -1,  -1,  1}
        };

        /// <summary>
        /// Applies recommended option presets for different types of usage.
        /// </summary>
        /// <param name="preset">The intended usage of the device.</param>
        public void ApplyIVCamPreset(IVCamPreset preset)
        {
            SetOption(IVCamOptions, IVCamPresetValues[(int)preset]);
        }
    }
}
