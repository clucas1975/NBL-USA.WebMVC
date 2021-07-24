using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class TeamDetail
    {
        public int TeamID { get; set; }
        public string TeamOwner { get; set; }
        public string TeamName { get; set; }
        public string TeamLocation { get; set; }
        public string TeamArena { get; set; }
    }
}
