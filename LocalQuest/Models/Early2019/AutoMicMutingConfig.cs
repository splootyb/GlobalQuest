using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Early2019
{
    public class AutoMicMutingConfig
    {
        public float MicSpamVolumeThreshold { get; set; }
        public float MicVolumeSampleInterval { get; set; }
        public float MicVolumeSampleRollingWindowLength { get; set; }
        public float MicSpamSamplePercentageForWarning { get; set; }
        public float MicSpamSamplePercentageForWarningToEnd { get; set; }
        public float MicSpamSamplePercentageForForceMute { get; set; }
        public float MicSpamSamplePercentageForForceMuteToEnd { get; set; }
        public float MicSpamWarningStateVolumeMultiplier { get; set; }
    }
}
