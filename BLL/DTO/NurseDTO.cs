using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class NurseDTO : BaseDTO.BaseModelDTO
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
