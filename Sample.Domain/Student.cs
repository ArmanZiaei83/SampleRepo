using System.Collections.Generic;

namespace Sample.Domain
{
    public class Student : Person
    {
        public HashSet<StudentCourse> Courses { get; set; }
    }
}