using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class RosterEdit
    {
        public int RosterID { get; set; }
        public string CoachName { get; set; }
        public string AssistantCoachName { get; set; }
        public bool StillActive { get; set; }
    }
}
