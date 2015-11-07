using System;
namespace SortedDictionary
{
    class Student : IComparable
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(object obj)
        {
            var otherStudent = obj as Student;

            if (otherStudent == null)
            {
                throw new ArgumentException("Invalid student format!");
            }

            if (this.LastName != otherStudent.LastName)
            {
                return this.LastName.CompareTo(otherStudent.LastName);
            }
            else
            {
                return this.FirstName.CompareTo(otherStudent.FirstName);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
