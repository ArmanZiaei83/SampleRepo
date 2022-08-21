using System.Collections.Generic;

namespace Sample.Domain.Entities
{
    public class Teacher : Person
    {
        public Teacher()
        {
            Courses = new HashSet<TeacherCourse>();
        }

        public HashSet<TeacherCourse> Courses { get; set; }
    }
}