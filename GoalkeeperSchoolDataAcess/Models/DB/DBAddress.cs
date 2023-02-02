using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalkeeperSchoolDataAcess.Models.Core;

namespace GoalkeeperSchoolDataAcess.Models.DB
{
    public class DBAddress : BaseModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        [Column(TypeName = "varchar(10)")]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        [Column(TypeName = "varchar(10)")]
        public string District { get; set; }
        
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        [Column(TypeName = "varchar(10)")]
        public string City { get; set; }

        public DBAddress(string street, string district, string city)
        {
            Street = street;
            District = district;
            City = city;
        }

        protected bool Equals(DBAddress other)
        {
            return Street == other.Street && District == other.District && City == other.City;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DBAddress)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, District, City);
        }
    }
}