using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DiseaseStatusDTO : BaseDTO.BaseModelDTO
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
