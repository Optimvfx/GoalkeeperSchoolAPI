using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalkeeperSchoolDataAcess.Models.Core;

namespace GoalkeeperSchoolDataAcess.Models.DB;

public class DBPhoneNumber : BaseModel
{
    [Required]
    [MaxLength(50)]
    [MinLength(2)]
    [Column(TypeName = "varchar(10)")]
    public string Value { get; set; }

    public DBPhoneNumber(string value)
    {
        Value = value;
    }

    public DBPhoneNumber()
    {
        
    }

    protected bool Equals(DBPhoneNumber other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DBPhoneNumber)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}