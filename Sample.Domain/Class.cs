using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Sample.Domain
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public HashSet<ClassCourse> Courses { get; set; }
    }
}