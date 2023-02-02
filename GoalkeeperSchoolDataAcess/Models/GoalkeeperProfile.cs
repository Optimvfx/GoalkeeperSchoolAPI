using GoalkeeperSchoolDataAcess.Models.DB;

namespace GoalkeeperSchoolDataAcess.Models;

public class GoalkeeperProfile : Core.IConvertible<DBGoalkeeperProfile>
{
    public FullName FullName { get;}

    public GoalkeeperProfile(FullName fullName)
    {
        if (fullName == null)
            throw new NullReferenceException();
        
        FullName = fullName;
    }

    public DBGoalkeeperProfile Convert()
    {
        return new DBGoalkeeperProfile(FullName.Convert());
    }

    protected bool Equals(GoalkeeperProfile other)
    {
        return FullName.Equals(other.FullName);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GoalkeeperProfile)obj);
    }

    public override int GetHashCode()
    {
        return FullName.GetHashCode();
    }
}
