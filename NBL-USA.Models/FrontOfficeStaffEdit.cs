using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL_USA.Models
{
    public class FrontOfficeStaffEdit
    {
        public int FrontOfficeStaffId { get; set; }
        public string TeamGeneralManagerName { get; set; }
        public string AcademicAdvisorName { get; set; }
        public string DirectorOfBasketballOperationsName { get; set; }
        public int TeamId { get; set; }

    }
}
