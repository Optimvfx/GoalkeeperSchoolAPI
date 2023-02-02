using System.ComponentModel.DataAnnotations;
using GoalkeeperSchoolDataAcess.Models.Core;

namespace GoalkeeperSchoolDataAcess.Models.DB
{
    public class DBGoalkeeperProfile : BaseModel
    {
        [Required]
        public DBFullName DbFullName { get; set; }

        public ICollection<DBPhoneNumber> PhoneNumbers { get; set; }
        
        public DBGoalkeeperProfile(DBFullName dbFullName, ICollection<DBPhoneNumber>? phoneNumbers)
        {
            DbFullName = dbFullName;

            PhoneNumbers = phoneNumbers;
            
            if (phoneNumbers == null)
                phoneNumbers = new List<DBPhoneNumber>();
        }

        public DBGoalkeeperProfile()
        {
            
        }
    }
}