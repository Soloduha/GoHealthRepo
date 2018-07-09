using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class WorkDayDTO : BaseDTO.BaseModelDTO
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
