using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class RosterEdit
    {
        public int RosterId { get; set; }
        public string CoachName { get; set; }
        public string AssistantCoachName { get; set; }
        public bool StillActive { get; set; }
        public int TeamId { get; set; }
    }
}
