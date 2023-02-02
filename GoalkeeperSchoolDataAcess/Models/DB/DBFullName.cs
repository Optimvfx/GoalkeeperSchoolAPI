using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalkeeperSchoolDataAcess.Models.Core;

namespace GoalkeeperSchoolDataAcess.Models.DB
{
    public class DBFullName : BaseModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [Column(TypeName = "varchar(10)")]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [Column(TypeName = "varchar(10)")]
        public string Surname { get; set; }
        
        [MaxLength(50)]
        [MinLength(2)]
        [Column(TypeName = "varchar(10)")]
        public string Paternity { get; set; }

        public DBFullName(string name, string surname, string paternity)
        {
            Name = name;
            Surname = surname;
            Paternity = paternity;
        }

        public DBFullName()
        {
            
        }

        protected bool Equals(DBFullName other)
        {
            return Name == other.Name && Surname == other.Surname && Paternity == other.Paternity;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DBFullName)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Paternity);
        }
    }
}