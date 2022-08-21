using System.Collections.Generic;

namespace Sample.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HashSet<ClassCourse> Courses { get; set; }
    }
}