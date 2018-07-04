using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccessLayer.Context
{
    internal class CustomInitializer<T> : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            //FillAllTables(context);
            //context.Doctors.AddRange(new List<Doctor> {
            //    new Doctor() {Name="Чумак",Surname="Чумаченко"},
            //    new Doctor() {Name="Олеся",Surname="Біньковська"},
            //    new Doctor() {Name="Андрій",Surname="Шелевицький"},
            //    new Doctor() {Name="Олег",Surname="Титюк"},
            //    new Doctor() {Name="Ігор",Surname="Захарченко"},
            //    new Doctor() {Name="Наталія",Surname="Козак"}
            //});


            

//            insert into Departments(Name,Address)
//Values
//(
//'FirstDep','Address1'
//)


//insert into Doctors(Name,Surname,ThirdName,DepartmentId,Password,PhoneNumber)
//Values
//(
//'Soloduha','Vlad','Valentinovich',1,'1234','0934329285'
//)

//select * from Doctors
            context.SaveChanges();
        }

        public void FillAllTables(MyContext context)
        {
            //FillDisStatuses();
            //FillDiseases();
            //FillDepartment();
            FillDoctors(context);
            //FillNotes();
            //FillWorkDays();
            //FillWorkDaysDoctors();
            //FillNurses();
            //FillDisHistories();
            //FillPatients();
        }

        public void FillDisStatuses()
        {
            MyContext context = new MyContext();
            context.DiseaseStatuses.AddRange(new List<DiseaseStatus> {
            new DiseaseStatus() { Code = "Закритий" },
            new DiseaseStatus() { Code = "Відкритий" },
            new DiseaseStatus() { Code = "Змінений" }
        });
        }
        public void FillDiseases()
        {
            MyContext context = new MyContext();
            context.Diseases.AddRange(new List<Disease> {
                new Disease() {Name="Артрит", DiseaseStatusId=1},
                new Disease() {Name="Грип", DiseaseStatusId=2},
                new Disease() {Name="ГРВІ", DiseaseStatusId=3},
                new Disease() {Name="СПД", DiseaseStatusId=1},
                new Disease() {Name="Гайморит", DiseaseStatusId=2},
                new Disease() {Name="ВСД", DiseaseStatusId=3},
                new Disease() {Name="БЛО", DiseaseStatusId=1}
            });
        }
        public void FillDepartment()
        {
            MyContext context = new MyContext();
            context.Departments.Add(new Department() { Name = "Назва Амбулаторія ЗПСМ №2", Address = "Грушевського 2", Director = "Біньковська О.Я." });
        }
        public void FillDoctors(MyContext context)
        {
           // MyContext context = new MyContext();

            context.Doctors.AddRange(new List<Doctor> {
                new Doctor() {Name="Чумак",Surname="Чумаченко"},
                new Doctor() {Name="Олеся",Surname="Біньковська"},
                new Doctor() {Name="Андрій",Surname="Шелевицький"},
                new Doctor() {Name="Олег",Surname="Титюк"},
                new Doctor() {Name="Ігор",Surname="Захарченко"},
                new Doctor() {Name="Наталія",Surname="Козак"}
            });
            context.SaveChanges();
        }
        public void FillDisHistories()
        {
            MyContext context = new MyContext();
            context.DiseaseHistories.AddRange(new List<DiseaseHistory> {
                new DiseaseHistory{Name="Історія хвороб №1",PatientId=1},
                new DiseaseHistory{Name="Історія хвороб №2",PatientId=2},
                new DiseaseHistory{Name="Історія хвороб №3",PatientId=3},
                new DiseaseHistory{Name="Історія хвороб №4",PatientId=4},
                new DiseaseHistory{Name="Історія хвороб №5",PatientId=5},
                new DiseaseHistory{Name="Історія хвороб №6",PatientId=6},
                new DiseaseHistory{Name="Історія хвороб №7",PatientId=7}
            });
        }
        public void FillNotes()
        {
            MyContext context = new MyContext();

            context.Notes.AddRange(new List<Note> {
                new Note() {Medicine="Some medicines",ReceptionId=1, DiseaseId=1,DiseaseHistoryId=1},
                new Note() {Medicine="Some medicines",ReceptionId=1, DiseaseId=3,DiseaseHistoryId=2},
                new Note() {Medicine="Some medicines",ReceptionId=1, DiseaseId=4,DiseaseHistoryId=3},
                new Note() {Medicine="Some medicines",ReceptionId=1, DiseaseId=7,DiseaseHistoryId=4},
                new Note() {Medicine="Some medicines",ReceptionId=1, DiseaseId=6,DiseaseHistoryId=5},
                new Note() {Medicine="Some medicines",ReceptionId=1, DiseaseId=5,DiseaseHistoryId=6},
                new Note() {Medicine="Some medicines",ReceptionId=1, DiseaseId=2,DiseaseHistoryId=7}
            });
        }
        public void FillWorkDays()
        {
            MyContext context = new MyContext();

            context.WorkDays.AddRange(new List<WorkDay> {
                new WorkDay(){StartDate = new DateTime(2018,7,10,10,0,0), EndDate = new DateTime(2018,7,10,18,0,0)},
                new WorkDay(){StartDate = new DateTime(2018,7,10,12,0,0), EndDate = new DateTime(2018,7,10,20,0,0)},
                new WorkDay(){StartDate = new DateTime(2018,7,11,10,0,0), EndDate = new DateTime(2018,7,11,18,0,0)},
                new WorkDay(){StartDate = new DateTime(2018,7,11,12,0,0), EndDate = new DateTime(2018,7,10,20,0,0)}
            });
        }
        public void FillWorkDaysDoctors()
        {
            MyContext context = new MyContext();

            context.WorkDayDoctors.AddRange(new List<WorkDayDoctor> {
                new WorkDayDoctor(){DoctorId=1, WorkDayId=1},
                new WorkDayDoctor(){DoctorId=2, WorkDayId=2},
                new WorkDayDoctor(){DoctorId=3, WorkDayId=3},
                new WorkDayDoctor(){DoctorId=4, WorkDayId=4},
                new WorkDayDoctor(){DoctorId=5, WorkDayId=2},
                new WorkDayDoctor(){DoctorId=6, WorkDayId=3}
            });
        }
        public void FillNurses()
        {
            MyContext context = new MyContext();

            context.Nurses.AddRange(new List<Nurse> {
                new Nurse() {Name="Галина",SecondName="Добряк", ThirdName="Іванівна",
                Password="12345Dobriak", PhoneNumber="0935672865"},
                new Nurse() {Name="Надія", SecondName="Бойко",  ThirdName="Володимирівна",
                Password="12345Boyko", PhoneNumber="0678934678"},
                new Nurse() {Name="Ірина", SecondName="Цурко",  ThirdName="Степанівна",
                Password="12345Tsurko", PhoneNumber="0508345782"}
            });
        }
        public void FillPatients()
        {
            MyContext context = new MyContext();

            context.Patients.AddRange(new List<Patient> {
                new Patient(){Name="Влад",Surname="Віктюк",ThirdName="Вікторович",DateOfBirth=new DateTime(1988,10,10),DiseaseHistoryId=7},
                new Patient(){Name="Олександр",Surname="Петриченко",ThirdName="Валентинович",DateOfBirth=new DateTime(1975,8,3),DiseaseHistoryId=6},
                new Patient(){Name="Богдан",Surname="Гупало",ThirdName="Олегович",DateOfBirth=new DateTime(1985,11,28),DiseaseHistoryId=5},
                new Patient(){Name="Віктор",Surname="Степанюк",ThirdName="Іллевич",DateOfBirth=new DateTime(1996,2,15),DiseaseHistoryId=4},
                new Patient(){Name="Петро",Surname="Ломаченко",ThirdName="Валерійович",DateOfBirth=new DateTime(2001,3,22),DiseaseHistoryId=3},
                new Patient(){Name="Дарина",Surname="Петриченко",ThirdName="Костянтинівна",DateOfBirth=new DateTime(1993,10,12),DiseaseHistoryId=2},
                new Patient(){Name="Софія",Surname="Бабич",ThirdName="Альбертівна",DateOfBirth=new DateTime(1982,7,11),DiseaseHistoryId=1}
            });
        }
    }
}