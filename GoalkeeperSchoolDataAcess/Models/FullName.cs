using GoalkeeperSchoolDataAcess.Models.DB;

namespace GoalkeeperSchoolDataAcess.Models
{
    public class FullName : Core.IConvertible<DBFullName>
    {
        public string Name { get;}
        public string Surname { get;}
        public string Paternity { get;}

        public FullName(string name, string surname, string paternity)
        {
            Name = name;
            Surname = surname;
            Paternity = paternity;
        }

        public DBFullName Convert()
        {
            return new DBFullName(Name, Surname, Paternity);
        }

        protected bool Equals(FullName other)
        {
            return Name == other.Name && Surname == other.Surname && Paternity == other.Paternity;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FullName)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Paternity);
        }
    }
}