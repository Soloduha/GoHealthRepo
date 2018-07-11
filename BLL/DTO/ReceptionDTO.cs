using BLL.BllMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReceptionDTO : BaseDTO.BaseModelDTO
    {
        #region Entity-DTO Properties
        public DateTime DateOfRegistration { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int NoteId { get; set; }
        public int NurseId { get; set; }
        #endregion
        #region Other Prop
        public GHRepository<Reception> repository { get; set; }
        public Reception Reception { get; set; }
        #endregion
        #region ctor
        public ReceptionDTO()
        {
            repository = new GHRepository<Reception>();
            GetCurrentReception();
        }
        #endregion
        #region Methods
        private void GetCurrentReception()
        {
            Reception = repository.FindById(Id);
        }

        public DoctorDTO GetDoctor()
        {
            GHRepository<Doctor> doctor = new GHRepository<Doctor>();
            return DTOConverter.Convert<Doctor, DoctorDTO>(doctor.FindById(DoctorId));
        }

        public PatientDTO GetPatient()
        {
            GHRepository<Patient> patient = new GHRepository<Patient>();
            return DTOConverter.Convert<Patient, PatientDTO>(patient.FindById(PatientId));
        }

        public NoteDTO GetNote()
        {
            GHRepository<Note> note = new GHRepository<Note>();
            return DTOConverter.Convert<Note, NoteDTO>(note.FindById(NoteId));
        }

        public NurseDTO GetNurse()
        {
            GHRepository<Nurse> nurse = new GHRepository<Nurse>();
            return DTOConverter.Convert<Nurse, NurseDTO>(nurse.FindById(NurseId));
        }
        #endregion
    }
}
