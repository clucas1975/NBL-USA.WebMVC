using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class PlayersCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string PlayerName { get; set; }

        public int PlayerNumber { get; set; }

        public string PlayerPosition { get; set; }

        public decimal PlayerHeight { get; set; }

        public decimal PlayerWeight { get; set; }

        public int RosterId { get; set; }
    }
}
