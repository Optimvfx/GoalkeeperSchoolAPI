using GoalkeeperSchoolDataAcess.Models;
using GoalkeeperSchoolDataAcess.Models.DB;

namespace GoalkeeperSchoolDataAcess.DataAcess.Core
{
    public interface IGoalkeeperSchoolDB
    {
        #region Accounts
        IEnumerable<DBAccount> GetAllAccounts();

        bool TryGetAccount(Guid id, out DBAccount account);
        
        bool ContainsAccount(Guid id);

        DBAccount GetAccount(Guid id);

        Guid AddAccount();

        bool TryRemoveAccount(Guid id);
        
        void RemoveAccount(Guid id);
        #endregion

        #region GoalkeeperProfile
        IEnumerable<DBGoalkeeperProfile> GetAllGoalkeeperProfiles(Guid accountID);

        bool TryGetGoalkeeperProfile(Guid accountID, Guid profileID, out DBGoalkeeperProfile profile);

        bool ContainsGoalkeeperProfile(Guid accountID, Guid profileID);

        DBGoalkeeperProfile GetGoalkeeperProfile(Guid accountID, Guid profileID);

        bool TryAddGoalkeeperProfile(Guid accountID, GoalkeeperProfile profile, out Guid newProfileId);
        
        Guid AddGoalkeeperProfile(Guid accountID, GoalkeeperProfile profile);
        
        bool TryRemoveGoalkeeperProfile(Guid accountID, Guid profileID);
        
        void RemoveGoalkeeperProfile(Guid accountID, Guid profileID);
        #endregion

        void Clear(string secretKey);
    }
}