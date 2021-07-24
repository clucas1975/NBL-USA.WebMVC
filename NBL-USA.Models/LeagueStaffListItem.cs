using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
   public class LeagueStaffListItem
    {
        [Key]
        public int LeagueStaffId { get; set; }

        [Required]
        public string LeagueStaffName { get; set; }

        [Required]
        public string LeagueStaffPosition { get; set; }

        [Required]
        public bool LeagueStaffStillWorking { get; set; }
    }
}
