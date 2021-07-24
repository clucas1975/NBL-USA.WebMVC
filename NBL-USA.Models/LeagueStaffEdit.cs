using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
  public class LeagueStaffEdit
  {
        public int LeagueStaffId { get; set; }
        public string LeagueStaffName { get; set; }
        public string LeagueStaffPosition { get; set; }
        public bool LeagueStaffStillWorking { get; set; }
    }
}
