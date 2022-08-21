using System.Collections.Generic;

namespace Sample.Domain.Entities
{
    public class Student : Person
    {
        public Student()
        {
            Courses = new HashSet<StudentCourse>();
        }

        public HashSet<StudentCourse> Courses { get; set; }
    }
}