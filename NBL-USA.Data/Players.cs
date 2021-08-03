using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Data
{
    public class Players
    {
        [Key]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(Roster))]
        public int RosterId { get; set; }
        public virtual Roster Roster { get; set; }

        [Required]
        public string PlayerName { get; set; }

        [Required]
        public int PlayerNumber { get; set; }

        [Required]
        public string PlayerPosition { get; set; }

        
        public decimal PlayerHeight { get; set; }

        public decimal PlayerWeight { get; set; }

    }
}
