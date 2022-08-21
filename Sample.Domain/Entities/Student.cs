using System.Collections.Generic;

namespace Sample.Domain.Entities
{
    public class Student : Person
    {
        public HashSet<StudentCourse> Courses { get; set; }
    }
}