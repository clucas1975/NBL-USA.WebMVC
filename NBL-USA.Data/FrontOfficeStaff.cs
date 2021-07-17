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
        public int FrontOfficeStaffID { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey(nameof(Roster))]
        public int RosterID { get; set; }
        public virtual Roster Roster { get; set; }

        [Required]
        public string TeamGeneralManagerName { get; set; }

        [Required]
        public string AcademicAdvisorName { get; set; }

        [Required]
        public string DirectorOfBasketballOperationsName { get; set; }

        [Required]
        public ICollection<FrontOfficeStaff> ListOfOwners { get; set; }

        public FrontOfficeStaff()
        {
            ListOfOwners = new HashSet<FrontOfficeStaff>();
        }
        
           
   }
    
}
