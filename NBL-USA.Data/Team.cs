using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string TeamOwner { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string TeamLocation { get; set; }

        [Required]
        public string TeamArena { get; set; }


        public string TeamPlayers { get; set; }


    }
    
}
