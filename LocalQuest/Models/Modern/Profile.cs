using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Modern
{
    public class Profile
    {
        public long accountId { get; set; }
        public string username { get; set; } = "Username";
        public string displayName { get; set; } = "DisplayName";
        public string? profileImage { get; set; }
        public string? bannerImage { get; set; }
        public bool isJunior { get; set; }
        public DateTime createdAt { get; set; }
        // add platform mask 
        public int platforms { get; set; }
        // more
    }
}
