using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedDictionary
{
    class Courses
    {
        private SortedDictionary<string, SortedSet<Student>> courses;

        public Courses()
        {
            this.courses = new SortedDictionary<string, SortedSet<Student>>();
        }

        public SortedDictionary<string, SortedSet<Student>> Get
        {
            get { return this.courses; }
        }

        public void AddStudent(string course, Student student)
        {
            if (this.courses.ContainsKey(course))
            {
                this.courses[course].Add(student);
            }
            else
            {
                this.courses[course] = new SortedSet<Student>();
                this.courses[course].Add(student);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var course in this.courses)
            {
                builder.Append(course.Key);
                builder.Append(": ");

                builder.Append(string.Join(", ", course.Value));
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
