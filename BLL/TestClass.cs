using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;

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
        static public ICollection<DoctorDTO>GetSomeDoctors()
        {
            GHRepository<Doctor> repo = new GHRepository<Doctor>();
            ObservableCollection<DoctorDTO> doctors = new ObservableCollection<DoctorDTO>();
            List<Doctor> doctors_old = new List<Doctor>(repo.GetEntities(x => x.Id > 0).ToList().OrderBy(x=>x.Surname));
            
            foreach (var a in doctors_old)
            {
                doctors.Add(new DoctorDTO {Name=a.Name,Surname=a.Surname,ThirdName=a.ThirdName});
            }
            return doctors;
        }
    }
}
