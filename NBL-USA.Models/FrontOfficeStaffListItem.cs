using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class FrontOfficeStaffListItem
    {
        [Key]
        public int FrontOfficeStaffId { get; set; }

       

        [Required]
        public string TeamGeneralManagerName { get; set; }

        [Required]
        public string AcademicAdvisorName { get; set; }

        [Required]
        public string DirectorOfBasketballOperationsName { get; set; }

        public int TeamId { get; set; }




    }
}
