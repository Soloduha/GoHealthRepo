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
    public class DoctorDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ThirdName { get; set; }
    }

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
                DTOConverter.Convert(a,out patient);
                patients.Add(patient);
            }
            return patients;
        }
    }
}
