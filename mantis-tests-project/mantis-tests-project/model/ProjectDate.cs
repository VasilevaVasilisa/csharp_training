using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_project 
{
    public class ProjectDate : IEquatable<ProjectDate>, IComparable<ProjectDate>
    
    {
        public ProjectDate (string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public object Id { get; internal set; }

        public int CompareTo(ProjectDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public bool Equals(ProjectDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
