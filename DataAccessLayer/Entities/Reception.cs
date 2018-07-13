using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Reception : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int NoteId { get; set; }
        public int NurseId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Note Note { get; set; }
        public virtual Nurse Nurse { get; set; }
      
    }
}
