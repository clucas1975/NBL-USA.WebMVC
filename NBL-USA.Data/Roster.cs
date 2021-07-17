using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Data
{
    public class Roster
    {
        [Key]
        public int RosterID { get; set; }


        [Required]
        public string CoachName { get; set; }

        [Required]
        public string AssistantCoachName { get; set; }

        [Required]
        public bool StillActive { get; set; }

        [Required]
        public ICollection<Roster> ListOfPlayers { get; set; }

        public Roster()
        {
            ListOfPlayers = new HashSet<Roster>();
        }
    }
    
}
