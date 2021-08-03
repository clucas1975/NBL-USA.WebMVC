using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class PlayersDetail
    {
        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        public int PlayerNumber { get; set; }

        public string PlayerPosition { get; set; }

        public decimal PlayerHeight { get; set; }

        public decimal PlayerWeight { get; set; }
    }
}
