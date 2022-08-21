using System.Collections.Generic;

namespace Sample.Domain.Entities
{
    public class Teacher : Person
    {
        public HashSet<TeacherCourse> Courses { get; set; }
    }
}