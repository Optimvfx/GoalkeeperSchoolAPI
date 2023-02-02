using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalkeeperSchoolDataAcess.Models.Core;

namespace GoalkeeperSchoolDataAcess.Models.DB
{
    public class DBAccount : BaseModel
    {
        [Required]
        public DBFullName ParentFullName { get; set; }

        [Required]
        public DBAddress AddressResidence { get; set; }
        
        public ICollection<DBPhoneNumber> ParentPhoneNumbers { get; set; }
        public ICollection<DBGoalkeeperProfile> GoalkeeperProfiles { get; set; }

        public DBAccount(DBFullName dbFullName, IEnumerable<DBGoalkeeperProfile>? goalkeeperProfiles = null,
            IEnumerable<DBPhoneNumber>? parentPhoneNumbers = null)
        {
            ParentFullName = dbFullName;

            ParentPhoneNumbers = parentPhoneNumbers.ToList();
            GoalkeeperProfiles = goalkeeperProfiles.ToList();
            
            if (goalkeeperProfiles == null)
                GoalkeeperProfiles = goalkeeperProfiles.ToList();
            
            if (parentPhoneNumbers == null)
                ParentPhoneNumbers = parentPhoneNumbers.ToList();
        }

        public DBAccount()
        {
            GoalkeeperProfiles = new List<DBGoalkeeperProfile>();
            ParentPhoneNumbers = new List<DBPhoneNumber>();
        }
    }
}