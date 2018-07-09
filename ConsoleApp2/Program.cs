using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL;

namespace ConsoleApp2
{
    class Program
    {
        public static void DoctorsDepartments()
        {
            ObservableCollection<DoctorDTO> doctors = new ObservableCollection<DoctorDTO>(TestClass.GetSomeDoctors());
            DoctorDTO doctorDTO = doctors.FirstOrDefault(x => x.Id == 1);
            Console.WriteLine(doctorDTO.GetDepartment().Name);
        }

        public static void DoctorWorkDDoctor()
        {
            ObservableCollection<DoctorDTO> doctors = new ObservableCollection<DoctorDTO>(TestClass.GetSomeDoctors());
            DoctorDTO doctorDTO = doctors.FirstOrDefault(x => x.Id == 1);
            List<WorkDayDoctorDTO> workDayDoctorDTOs = new List<WorkDayDoctorDTO>(doctorDTO.GetWorkDaysDoctorsDTO());
            Console.WriteLine(workDayDoctorDTOs.ElementAt(0).WorkDayId);
        }

        static void Main(string[] args)
        {
            DoctorWorkDDoctor();
        }
    }
}
