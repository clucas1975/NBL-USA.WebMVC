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
   public class FrontOfficeStaff
   {
        [Key]
        public int FrontOfficeStaffId { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey(nameof(Roster))]
        public int? RosterId { get; set; }
        public virtual Roster Roster { get; set; }

        [Required]
        public string TeamGeneralManagerName { get; set; }

        [Required]
        public string AcademicAdvisorName { get; set; }

        [Required]
        public string DirectorOfBasketballOperationsName { get; set; }

        [Required]
        public virtual ICollection<Team> ListOfTeamOwners { get; set; }

        public FrontOfficeStaff()
        {
            ListOfTeamOwners = new HashSet<Team>();
        }

       

     
        
           
   }
    
}
