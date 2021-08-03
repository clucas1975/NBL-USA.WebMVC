using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class RosterListItem
    {
        [Key]
        public int RosterId { get; set; }

        [Required]
        public string CoachName { get; set; }

        [Required]
        public string AssistantCoachName { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}
