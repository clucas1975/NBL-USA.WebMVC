using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
   public class TeamListItem
    {
        [Key]
        public int TeamID { get; set; }

        [Required]
        public string TeamOwner { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string TeamLocation { get; set; }

        [Required]
        public string TeamArena { get; set; }
    }
}
