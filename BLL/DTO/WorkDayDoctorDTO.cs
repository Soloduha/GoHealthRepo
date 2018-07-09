using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class WorkDayDoctorDTO : BaseDTO.BaseModelDTO
    {
        public int DoctorId { get; set; }
        public int WorkDayId { get; set; }

        public GHRepository<WorkDayDoctor> repository { get; set; }
        public WorkDayDoctor WorkDayDoctor { get; set; }
        
        public void GetCurrentWorkDayDoctor()
        {
            WorkDayDoctor = repository.FindById(Id);
        }

        //public 
    }
}
