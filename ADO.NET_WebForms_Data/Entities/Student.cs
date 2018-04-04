﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Practice.Data.Entities
{
    /// <summary>
    /// Student class that maps the student.
    /// </summary>
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int VolunteerSchoolID { get; set; }
        public int VolunteerAvailabilityID { get; set; }
    }
}
