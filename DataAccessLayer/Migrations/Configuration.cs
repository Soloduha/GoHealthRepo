namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.Context;
    using DataAccessLayer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Context.MyContext>
    {
        private MyContext context;
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DataAccessLayer.Context.MyContext";
        }

        protected override void Seed(DataAccessLayer.Context.MyContext _context)
        {
            context = _context;
            
            FillAllTables();
            context.SaveChanges();
        }

        public void FillAllTables()
        {
            FillDisStatuses();
            FillDiseases();
            FillDepartment();
            FillDoctors();
            FillWorkDays();

            FillPatients();
            //FillDisHistories();
            FillNotes();
            FillWorkDaysDoctors();
            FillNurses();
        }

        public void FillDisStatuses()
        {
            context.DiseaseStatuses.AddRange(new List<DiseaseStatus> {
            new DiseaseStatus() { Code = "��������" },
            new DiseaseStatus() { Code = "³�������" },
            new DiseaseStatus() { Code = "�������" }
        });
            context.SaveChanges();
        }

        public void FillDiseases()
        {
            context.Diseases.AddRange(new List<Disease> {
                new Disease() {Name="������", DiseaseStatusId=1},
                new Disease() {Name="����", DiseaseStatusId=2},
                new Disease() {Name="��²", DiseaseStatusId=3},
                new Disease() {Name="���", DiseaseStatusId=1},
                new Disease() {Name="��������", DiseaseStatusId=2},
                new Disease() {Name="���", DiseaseStatusId=3},
                new Disease() {Name="���", DiseaseStatusId=1}
            });
            context.SaveChanges();
        }
        public void FillDepartment()
        {
            context.Departments.Add(new Department() { Name = "����� ���������� ���� �2", Address = "������������ 2", Director = "����������� �.�." });

            context.SaveChanges();
        }
        public void FillDoctors()
        {
            context.Doctors.AddRange(new List<Doctor> {
                new Doctor() {Name = "Vlad",
                Surname = "Soloduha",
                ThirdName = "Valentinovich",
                DepartmentId = 1,
                Password = "1234",
                DoctorPhoneNumber = "0934329285"},

                new Doctor() {Name="�����",Surname="�����������",
                ThirdName = "���������",
                DepartmentId = 1,
                Password = "qwer123",
                DoctorPhoneNumber = "0956478922"},

                new Doctor() {Name="�����",Surname="�����������",
                ThirdName = "��������",
                DepartmentId = 1,
                Password = "1234ter",
                DoctorPhoneNumber = "0934352285"},

                new Doctor() {Name="����",Surname="�����",
                ThirdName = "��������",
                DepartmentId = 1,
                Password = "1234kode",
                DoctorPhoneNumber = "0984329285"},

                new Doctor() {Name="����",Surname="����������",
                ThirdName = "Kazemirovich",
                DepartmentId = 1,
                Password = "1234qwert",
                DoctorPhoneNumber = "0994329285"},

                new Doctor() {Name="������",Surname="�����",
                ThirdName = "�������",
                DepartmentId = 1,
                Password = "122345",
                DoctorPhoneNumber = "0924329285"}
            });
            context.SaveChanges();
        }

        //public void FillDisHistories()
        //{
        //    context.DiseaseHistories.AddRange(new List<DiseaseHistory> {
        //        new DiseaseHistory{Name="������ ������ �1"},
        //        new DiseaseHistory{Name="������ ������ �2"},
        //        new DiseaseHistory{Name="������ ������ �3"},
        //        new DiseaseHistory{Name="������ ������ �4"},
        //        new DiseaseHistory{Name="������ ������ �5"},
        //        new DiseaseHistory{Name="������ ������ �6"},
        //        new DiseaseHistory{Name="������ ������ �7"}
        //    });

        //    context.SaveChanges();
        //}

        public void FillNotes()
        {
            context.Notes.AddRange(new List<Note> {
                new Note() {Medicine="Some medicines", DiseaseId=1,DiseaseHistoryId=1},
                new Note() {Medicine="Some medicines", DiseaseId=3,DiseaseHistoryId=2},
                new Note() {Medicine="Some medicines", DiseaseId=4,DiseaseHistoryId=3},
                new Note() {Medicine="Some medicines", DiseaseId=7,DiseaseHistoryId=4},
                new Note() {Medicine="Some medicines", DiseaseId=6,DiseaseHistoryId=5},
                new Note() {Medicine="Some medicines", DiseaseId=5,DiseaseHistoryId=6},
                new Note() {Medicine="Some medicines", DiseaseId=2,DiseaseHistoryId=7}
            });

            context.SaveChanges();
        }
        public void FillWorkDays()
        {
            context.WorkDays.AddRange(new List<WorkDay> {
                new WorkDay(){StartDate = new DateTime(2018,7,10,10,0,0), EndDate = new DateTime(2018,7,10,18,0,0)},
                new WorkDay(){StartDate = new DateTime(2018,7,10,12,0,0), EndDate = new DateTime(2018,7,10,20,0,0)},
                new WorkDay(){StartDate = new DateTime(2018,7,11,10,0,0), EndDate = new DateTime(2018,7,11,18,0,0)},
                new WorkDay(){StartDate = new DateTime(2018,7,11,12,0,0), EndDate = new DateTime(2018,7,10,20,0,0)}
            });

            context.SaveChanges();
        }
        public void FillWorkDaysDoctors()
        {
            context.WorkDayDoctors.AddRange(new List<WorkDayDoctor> {
                new WorkDayDoctor(){DoctorId=1, WorkDayId=1},
                new WorkDayDoctor(){DoctorId=2, WorkDayId=2},
                new WorkDayDoctor(){DoctorId=3, WorkDayId=3},
                new WorkDayDoctor(){DoctorId=4, WorkDayId=4},
                new WorkDayDoctor(){DoctorId=5, WorkDayId=2},
                new WorkDayDoctor(){DoctorId=6, WorkDayId=3}
            });

            context.SaveChanges();
        }
        public void FillNurses()
        {
            context.Nurses.AddRange(new List<Nurse> {
                new Nurse() {Name="������",SecondName="������", ThirdName="�������",
                Password="12345Dobriak", PhoneNumber="0935672865"},
                new Nurse() {Name="����", SecondName="�����",  ThirdName="������������",
                Password="12345Boyko", PhoneNumber="0678934678"},
                new Nurse() {Name="�����", SecondName="�����",  ThirdName="���������",
                Password="12345Tsurko", PhoneNumber="0508345782"}
            });

            context.SaveChanges();
        }
        public void FillPatients()
        {
            context.Patients.AddRange(new List<Patient> {
                new Patient(){Name="����",Surname="³����",ThirdName="³��������",
                    DateOfBirth =new DateTime(1988,10,10),
                    DiseaseHistory = new DiseaseHistory{Name="������ ������ �1", PatientId=1}},
                new Patient(){Name="���������",Surname="����������",ThirdName="������������",
                    DateOfBirth =new DateTime(1975,8,3),
                    DiseaseHistory =new DiseaseHistory{Name="������ ������ �2", PatientId=2} },
                new Patient(){Name="������",Surname="������",ThirdName="��������",
                    DateOfBirth =new DateTime(1985,11,28),
                    DiseaseHistory = new DiseaseHistory{Name="������ ������ �3", PatientId=3} },
                new Patient(){Name="³����",Surname="��������",ThirdName="�������",
                    DateOfBirth =new DateTime(1996,2,15),
                    DiseaseHistory =new DiseaseHistory{Name="������ ������ �4", PatientId=4} },
                new Patient(){Name="�����",Surname="���������",ThirdName="����������",
                    DateOfBirth =new DateTime(2001,3,22),
                    DiseaseHistory = new DiseaseHistory{Name="������ ������ �5", PatientId=5}},
                new Patient(){Name="������",Surname="����������",ThirdName="������������",
                    DateOfBirth =new DateTime(1993,10,12),
                    DiseaseHistory =new DiseaseHistory{Name="������ ������ �6", PatientId=6}},
                new Patient(){Name="�����",Surname="�����",ThirdName="����������",
                    DateOfBirth =new DateTime(1982,7,11),
                    DiseaseHistory =new DiseaseHistory{Name="������ ������ �7", PatientId=7}}
            });

            context.SaveChanges();
        }
    }
}
