﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PatientDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ThirdName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}