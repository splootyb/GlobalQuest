using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Early2019
{
    public class CachedLogin
    {
        public Profile Player { get; set; } = new Profile();
        public DateTime LastLoginTime { get; set; } = DateTime.MinValue;
        public bool RequirePassword { get; set; }
    }
}
