using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using BLL.BllMapper;

namespace BLL
{
    public static class TestClass
    {
        static public ICollection<PatientDTO>GetSomePatients()
        {
            GHRepository<Patient> repo = new GHRepository<Patient>();
            List<Patient> patients_old = new List<Patient>(repo.GetEntities(x => x.Id > 0).ToList().OrderBy(x=>x.Surname));
            
            ObservableCollection<PatientDTO> patients = new ObservableCollection<PatientDTO>();
            PatientDTO patient;

            foreach (var a in patients_old)
            {
                patient=DTOConverter.Convert<Patient,PatientDTO>(a);
                patients.Add(patient);
            }
            return patients;
        }

        static public ICollection<DoctorDTO> GetSomeDoctors()
        {
            GHRepository<Doctor> repo = new GHRepository<Doctor>();
            List<Doctor> doctors_old = new List<Doctor>(repo.GetEntities(x => x.Id > 0).ToList().OrderBy(x => x.Surname));

            ObservableCollection<DoctorDTO> doctors = new ObservableCollection<DoctorDTO>();
            DoctorDTO doctor;

            foreach (var a in doctors_old)
            {
                doctor = DTOConverter.Convert<Doctor,DoctorDTO>(a);
                doctors.Add(doctor);
            }
            return doctors;
        }
    }
}
