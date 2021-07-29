using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class FrontOfficeStaffCreate
    {

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string TeamGeneralManagerName { get; set; }
        public string AcademicAdvisorName { get; set; }
        public string DirectorOfBasketballOperationsName { get; set; }
    }
}
