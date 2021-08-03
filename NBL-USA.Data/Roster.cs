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
        public int RosterId { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }



        [Required]
        public string CoachName { get; set; }

        [Required]
        public string AssistantCoachName { get; set; }

        [Required]
        public bool StillActive { get; set; }

        [Required]
        public virtual ICollection<Team> ListOfPlayers { get; set; }

       public Roster()
        {
            ListOfPlayers = new HashSet<Team>();
        }

    }
    
}
