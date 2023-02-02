using System.Data;
using System.Data.Common;
using System.Diagnostics;
using GoalkeeperSchoolDataAcess.DataAcess.Controlers;
using GoalkeeperSchoolDataAcess.DataAcess.Core;
using GoalkeeperSchoolDataAcess.Models;
using GoalkeeperSchoolDataAcess.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace GoalkeeperSchoolDataAcess.DataAcess
{
    public class GoalkeeperSchoolDB : IGoalkeeperSchoolDB
    {
        private readonly GoalkeeperSchoolDBControler _dbControler;

        #region ctor

        public GoalkeeperSchoolDB(DbContextOptions<GoalkeeperSchoolDBControler> options)
        {
            _dbControler = new GoalkeeperSchoolDBControler(options);
        }

        public GoalkeeperSchoolDB()
        {
            _dbControler = new GoalkeeperSchoolDBControler();
        }

        #endregion

        #region Account

        public IEnumerable<DBAccount> GetAllAccounts()
        {
            try
            {
                return _dbControler.Accounts;
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public bool TryGetAccount(Guid id, out DBAccount account)
        {
            try
            {
                account = default;
            
                if (ContainsAccount(id) == false)
                    return false;

                account = GetAccount(id);

                return true;
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public bool ContainsAccount(Guid id)
        {
            try
            {
                return _dbControler.Accounts.Any(account => account.ID == id);
            }
            catch
            {
                throw new DataException();
            }
        }

        public DBAccount GetAccount(Guid id)
        {
            return _dbControler.Accounts.First(account => account.ID == id);
        }

        public Guid AddAccount()
        {
            try
            {
                var newAccount = new DBAccount();

                _dbControler.Accounts.Add(newAccount);

                SaveActions();

                return newAccount.ID;
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public bool TryRemoveAccount(Guid id)
        {
            try
            {
                if (ContainsAccount(id) == false)
                    return false;
                
                RemoveAccount(id);

                return true;
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public void RemoveAccount(Guid id)
        {
            try
            {
                _dbControler.Accounts.Remove(_dbControler.Accounts.First(account => account.ID == id));
                
                SaveActions();
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        #endregion

        #region GoalkeeperProfiles

        public IEnumerable<DBGoalkeeperProfile> GetAllGoalkeeperProfiles(Guid accountID)
        {
            if (TryGetAccount(accountID, out DBAccount account) == false)
                throw new NullReferenceException("Account not founded.");

            return account.GoalkeeperProfiles;
        }

        public bool TryGetGoalkeeperProfile(Guid accountID, Guid profileID, out DBGoalkeeperProfile profile)
        {
            profile = default;
            
            try
            {
                if (ContainsGoalkeeperProfile(accountID, profileID) == false)
                    return false;
                
                profile = GetGoalkeeperProfile(accountID, profileID);

                return true;
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public bool ContainsGoalkeeperProfile(Guid accountID, Guid profileID)
        {
            try
            {
                if (TryGetAccount(accountID, out DBAccount account) == false)
                    return false;

                return account.GoalkeeperProfiles.Any(profile => profile.ID == profileID);
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public DBGoalkeeperProfile GetGoalkeeperProfile(Guid accountID, Guid profileID)
        {
            if (TryGetAccount(accountID, out DBAccount account) == false)
                throw new NullReferenceException("Account not founded.");

            try
            {
                return account.GoalkeeperProfiles.First(profile => profile.ID == profileID);
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public bool TryAddGoalkeeperProfile(Guid accountID, GoalkeeperProfile profile, out Guid newProfileId)
        {
            try
            {
                newProfileId = default;

                if (TryGetAccount(accountID, out DBAccount account) == false)
                    return false;

                newProfileId = AddGoalkeeperProfile(accountID, profile);

                return true;
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public Guid AddGoalkeeperProfile(Guid accountID, GoalkeeperProfile profile)
        {
            if (TryGetAccount(accountID, out DBAccount account) == false)
                throw new NullReferenceException("Account not founded.");
            
            try
            {
                var newProfile = profile.Convert();

                account.GoalkeeperProfiles.Add(newProfile);

                _dbControler.Accounts.Update(account);

                SaveActions();
                
                return newProfile.ID;
            }
            catch (Exception e)
            {
                throw new DataException(e.Message);
            }
        }

        public bool TryRemoveGoalkeeperProfile(Guid accountID, Guid profileID)
        {
            try
            {
                if (ContainsGoalkeeperProfile(accountID, profileID) == false)
                    return false;
            
                RemoveGoalkeeperProfile(accountID, profileID);

                return true;
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }

        public void RemoveGoalkeeperProfile(Guid accountID, Guid profileID)
        {
            if (TryGetAccount(accountID, out DBAccount account) == false)
                throw new NullReferenceException("Account not founded.");

            try
            {
                account.GoalkeeperProfiles.Remove(account.GoalkeeperProfiles.First(profile => profile.ID == profileID));
                
                SaveActions();
            }
            catch (Exception e)
            {
                throw new DataException();
            }
        }
        #endregion

        public void Clear(string secretKey)
        {
            const string clearSecretKey = "y23ucgxz42_yxfct261_fdxcfdx26";

            if (secretKey != clearSecretKey)
                throw new ArgumentException();
            
            _dbControler.Accounts.RemoveRange(_dbControler.Accounts);
            _dbControler.GoalkeeperProfiles.RemoveRange(_dbControler.GoalkeeperProfiles);
            _dbControler.FullNames.RemoveRange(_dbControler.FullNames);
            
            SaveActions();
        }

        private void SaveActions()
        {
            _dbControler.SaveChanges();
        }
    }
}