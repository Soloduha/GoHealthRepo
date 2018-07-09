using BLL.BllMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DoctorDTO : BaseDTO.BaseModelDTO
    {
        #region Entity-DTO Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ThirdName { get; set; }
        public string Password { get; set; }
        public string DoctorPhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        #endregion
        #region Other Properties
        public GHRepository<Doctor> repository { get; set; }
        public Doctor Doctor { get; set; }

        public DoctorDTO()
        {
            repository = new GHRepository<Doctor>();
            GetCurrentDoctor();
        }
  
        #endregion
        #region Methods
        public void GetCurrentDoctor()
        {
            Doctor = repository.FindById(Id);
        }

        public DepartmentDTO GetDepartment()
        {
            GHRepository<Department> repoDepart = new GHRepository<Department>();
            return DTOConverter.Convert<Department, DepartmentDTO>(repoDepart.FindById(DepartmentId));
        }

        //return WorkDayDoctorDTO collection for current doctor
        public ICollection<WorkDayDoctorDTO> GetWorkDaysDoctorsDTO()
        {
            ICollection<WorkDayDoctorDTO> WorkDayDoctorDTOs = new List<WorkDayDoctorDTO>();

            //Шукаємо доктора з нашим id і витягуємо його workDayDoctors
            GetCurrentDoctor();
            ICollection<WorkDayDoctor> WorkDayDoctors = new ObservableCollection<WorkDayDoctor>(Doctor.WorkDayDoctor);

            //конвертуємо workDayDoctor в workDayDoctorDTO
            foreach (var workDayDoctor in Doctor.WorkDayDoctor)
            {
                WorkDayDoctorDTOs.Add(DTOConverter.Convert<WorkDayDoctor, WorkDayDoctorDTO>(workDayDoctor));
            }

            return WorkDayDoctorDTOs;
        }

        //return ReceptionDTO collection for current doctor
        private ICollection<ReceptionDTO> GetReceptionsDTO()
        {
            ICollection<ReceptionDTO> receptionDTOs = new ObservableCollection<ReceptionDTO>();

            //Шукаємо доктора з нашим id і витягуємо його workDayDoctors
            GetCurrentDoctor();
            ICollection<Reception> receptions = new ObservableCollection<Reception>(Doctor.Reception);

            //конвертуємо workDayDoctor в workDayDoctorDTO
            foreach (var reception in Doctor.Reception)
            {
                receptionDTOs.Add(DTOConverter.Convert<Reception, ReceptionDTO>(reception));
            }

            return receptionDTOs;
        }
        #endregion
    }
}
