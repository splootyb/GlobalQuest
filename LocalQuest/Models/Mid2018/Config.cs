using LocalQuest.Models.Early2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Config
    {
        public Config() {
            string Port = LocalQuest.Config.GetString("ServerPort");
            if(string.IsNullOrEmpty(Port))
            {
                Port = "16512";
            }
            CdnBaseUri = "http://localhost:" + Port;
        }
        public string MessageOfTheDay { get; set; } = "Where could SillyQuester be?";
        public string CdnBaseUri { get; set; } = "http://localhost:" + LocalQuest.Config.GetString("ServerPort");
        public MatchParams MatchmakingParams { get; set; } = new MatchParams();
        public List<LevelProgression> LevelProgressionMaps { get; set; } = new List<LevelProgression>();
        public List<List<Objective>> DailyObjectives { get; set; } = new List<List<Objective>>()
        {
            new List<Objective>()
            {
                new Objective()
                {
                    type = ObjectiveType.CheerAPlayer,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.GoToRecCenter,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.ScoreBasketInRecCenter,
                    score = 1
                }
            },
            new List<Objective>()
            {
                new Objective()
                {
                    type = ObjectiveType.CheerAPlayer,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.GoToRecCenter,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.ScoreBasketInRecCenter,
                    score = 1
                }
            },
            new List<Objective>()
            {
                new Objective()
                {
                    type = ObjectiveType.CheerAPlayer,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.GoToRecCenter,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.ScoreBasketInRecCenter,
                    score = 1
                }
            },
            new List<Objective>()
            {
                new Objective()
                {
                    type = ObjectiveType.CheerAPlayer,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.GoToRecCenter,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.ScoreBasketInRecCenter,
                    score = 1
                }
            },
            new List<Objective>()
            {
                new Objective()
                {
                    type = ObjectiveType.CheerAPlayer,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.GoToRecCenter,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.ScoreBasketInRecCenter,
                    score = 1
                }
            },
            new List<Objective>()
            {
                new Objective()
                {
                    type = ObjectiveType.CheerAPlayer,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.GoToRecCenter,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.ScoreBasketInRecCenter,
                    score = 1
                }
            },
            new List<Objective>()
            {
                new Objective()
                {
                    type = ObjectiveType.CheerAPlayer,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.GoToRecCenter,
                    score = 1
                },
                new Objective()
                {
                    type = ObjectiveType.ScoreBasketInRecCenter,
                    score = 1
                }
            },
        };
        public List<ConfigTable> ConfigTable { get; set; } = new List<ConfigTable>();
        public PhotonConfig PhotonConfig { get; set; } = new PhotonConfig();
        public AutoMicMutingConfig AutoMicMutingConfig { get; set; } = new AutoMicMutingConfig()
        {
            MicSpamVolumeThreshold = 1.125f,
            MicVolumeSampleInterval = 0.25f,
            MicVolumeSampleRollingWindowLength = 7,
            MicSpamSamplePercentageForWarning = 0.8f,
            MicSpamSamplePercentageForWarningToEnd = 0.2f,
            MicSpamSamplePercentageForForceMute = 0.8f,
            MicSpamSamplePercentageForForceMuteToEnd = 0.2f,
            MicSpamWarningStateVolumeMultiplier = 0.25f
        };
        public ServerMaintenance ServerMaintenance { get; set; } = new ServerMaintenance();
    }
}
