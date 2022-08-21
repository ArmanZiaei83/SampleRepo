﻿using System;
using System.Collections.Generic;

namespace Sample.Domain.Entities
{
    public class Course
    {
        public Course()
        {
            Students = new List<StudentCourse>();
            Teachers = new List<TeacherCourse>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime StartDateTime { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public List<StudentCourse> Students { get; set; }

        public List<TeacherCourse> Teachers { get; set; }
    }
}