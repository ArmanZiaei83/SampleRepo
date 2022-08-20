using System.Collections.Generic;

namespace Sample.Domain
{
    public class Teacher : Person
    {
        public HashSet<TeacherCourse> Courses { get; set; }
    }
}