using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Late2018
{
    public class CommunityBoard
    {
        public FeaturedPlayer FeaturedPlayer { get; set; } = new FeaturedPlayer();
        public FeaturedRoomGroup FeaturedRoomGroup { get; set; } = new FeaturedRoomGroup();
        public BoardAnnouncement CurrentAnnouncement { get; set; } = new BoardAnnouncement();
        public List<BoardImage> InstagramImages { get; set; } = new List<BoardImage>();
        public List<BoardVideo> Videos { get; set; } = new List<BoardVideo>();
    }

    public class BoardVideo
    {
        public string BlobName { get; set; } = "";
        public string Video { get; set; } = "";
        public string Description { get; set; } = "";
        public string ThumbnailBlobName { get; set; } = "";
        public string SourceUrl { get; set; } = "";
    }

    public class BoardImage
    {
        public string ImageName { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }

    public class BoardAnnouncement
    {
        public string Message { get; set; } = "Hello EpicQuesters?!";
        public string MoreInfoUrl { get; set; } = "http://discord.gg/EpicQuest";
    }

    public class FeaturedPlayer
    {
        public int Id { get; set; } = 1;
        public string TitleOverride { get; set; } = "";
        public string UrlOverride { get; set; } = "";
    }
}
