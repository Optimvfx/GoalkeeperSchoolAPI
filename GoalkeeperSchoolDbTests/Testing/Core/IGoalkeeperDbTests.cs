using System;
using System.Linq;
using GoalkeeperSchoolDataAcess.DataAcess.Core;
using GoalkeeperSchoolDataAcess.Models;
using GoalkeeperSchoolDataAcess.Models.DB;
using NUnit.Framework;

namespace GoalkeeperSchoolDbTests.Testing
{
    public abstract class IGoalkeeperDbTests
    {
        private IGoalkeeperSchoolDB _db;
        
        [SetUp]
        public void Setup()
        {
            _db = GetDb();
            
            ClearDb(_db);
        }

         #region GoalkeeperProfile
        [Test]
        public void GetedGoalkeeperProfileIsEquelsAddedGoalkeeperProfile()
        {
            var newAccountId = _db.AddAccount();
            
            var newGoalkeeperProfile = new GoalkeeperProfile(new FullName("Name", "Surname", "Paternity"));

            _db.AddGoalkeeperProfile(newAccountId, newGoalkeeperProfile);
            
            Assert.True(_db.GetAccount(newAccountId).GoalkeeperProfiles.First().Equals(newGoalkeeperProfile.Convert()));
        }

        [Test]
        public void GoalkeeperProfileTryGetWorksOnlyWhenDbContainsGoalkeeperProfile()
        {
            var newAccountId = _db.AddAccount();
            
            var newGoalkeeperProfile = new GoalkeeperProfile(new FullName("Name", "Surname", "Paternity"));

            var newGoalkeeperProfileId = _db.AddGoalkeeperProfile(newAccountId, newGoalkeeperProfile);

            DBGoalkeeperProfile goalkeeperProfile;
            
            Assert.True(_db.TryGetGoalkeeperProfile(newAccountId, newGoalkeeperProfileId, out goalkeeperProfile)); 
            
            _db.RemoveGoalkeeperProfile(newAccountId, newGoalkeeperProfileId);

            Assert.False(_db.TryGetGoalkeeperProfile(newAccountId, newGoalkeeperProfileId, out goalkeeperProfile));
        }
        
        [Test]
        public void GoalkeeperProfileTryRemovingWorksOnlyWhenDbContainsGoalkeeperProfile()
        {
            var newAccountId = _db.AddAccount();
            
            var newGoalkeeperProfile = new GoalkeeperProfile(new FullName("Name", "Surname", "Paternity"));

            var newGoalkeeperProfileId = _db.AddGoalkeeperProfile(newAccountId, newGoalkeeperProfile);

            Assert.True(_db.TryRemoveGoalkeeperProfile(newAccountId, newGoalkeeperProfileId)); 
            
            Assert.False(_db.TryRemoveGoalkeeperProfile(newAccountId, newGoalkeeperProfileId)); 
        }
        
        [Test]
        public void GoalkeeperProfileRemovingWorks()
        {
            var newAccountId = _db.AddAccount();
            
            var newGoalkeeperProfile = new GoalkeeperProfile(new FullName("Name", "Surname", "Paternity"));

            var newGoalkeeperProfileId = _db.AddGoalkeeperProfile(newAccountId, newGoalkeeperProfile);

            Assert.True(_db.ContainsGoalkeeperProfile(newAccountId, newGoalkeeperProfileId)); 
            
            _db.RemoveGoalkeeperProfile(newAccountId, newGoalkeeperProfileId);
            
            Assert.False(_db.ContainsGoalkeeperProfile(newAccountId, newGoalkeeperProfileId)); 
        }

        [Test]
        public void GetAllGoalkeeperProfileReturnAllAddedGoalkeeperProfile()
        {
            var newAccountId = _db.AddAccount();
            
            var newGoalkeeperProfils = new[]{
                new GoalkeeperProfile(new FullName("Name1", "Surname1", "Paternity1")),
                new GoalkeeperProfile(new FullName("Name2", "Surname2", "Paternity2")),
                new GoalkeeperProfile(new FullName("Name3", "Surname3", "Paternity3"))  };

            foreach (var profile in newGoalkeeperProfils)
            {
                _db.AddGoalkeeperProfile(newAccountId, profile);
            }

            var convertedProfiles = newGoalkeeperProfils.Select(profile => profile.Convert());
            
            var notAddedGoalkeeperProfile = new GoalkeeperProfile(new FullName("NotAddedName", "NotAddedSurname", "NotAddedPaternity")).Convert();

            Assert.That(_db.GetAllGoalkeeperProfiles(newAccountId).Count() == convertedProfiles.Count(),
                $"Db added GoalkeeperProfiles count({_db.GetAllGoalkeeperProfiles(newAccountId).Count()}) == added GoalkeeperProfiles count({convertedProfiles.Count()}).");
            Assert.That(_db.GetAllGoalkeeperProfiles(newAccountId).All(profile => convertedProfiles.Contains(profile)), "Db Contains All added GoalkeeperProfiles.");
            Assert.That(_db.GetAllGoalkeeperProfiles(newAccountId).Contains(notAddedGoalkeeperProfile) == false, "Db dont Contains not added GoalkeeperProfiles.");
        }

        [Test]
        public void NotContainsNotAddedGoalkeeperProfile()
        {
            var newAccountId = _db.AddAccount();
            
            var newGoalkeeperProfile = new GoalkeeperProfile(new FullName("Name", "Surname", "Paternity"));
            
            var newGoalkeeperProfileId = _db.AddGoalkeeperProfile(newAccountId, newGoalkeeperProfile);
            
            var notAddedGoalkeeperProfile = new GoalkeeperProfile(new FullName("NotAddedName", "NotAddedSurname", "NotAddedPaternity")).Convert();

            Assert.True(_db.ContainsGoalkeeperProfile(newAccountId, newGoalkeeperProfileId));
            
            Assert.False(_db.ContainsGoalkeeperProfile(newAccountId, notAddedGoalkeeperProfile.ID));
        }

        [Test]
        public void ContainsAddedGoalkeeperProfile()
        {
            var newAccountId = _db.AddAccount();
            
            var newGoalkeeperProfile = new GoalkeeperProfile(new FullName("Name", "Surname", "Paternity"));
            
            var newGoalkeeperProfileId = _db.AddGoalkeeperProfile(newAccountId, newGoalkeeperProfile);
            
            Assert.True(_db.ContainsGoalkeeperProfile(newAccountId, newGoalkeeperProfileId));
        }
        #endregion
        
        
        #region Account
        [Test]
        public void GetedAccountIsEquelsAddedAccount()
        {
            var newAccountId = _db.AddAccount();
            
            var newGoalkeeperProfile = new GoalkeeperProfile(new FullName("Name", "Surname", "Paternity"));

            _db.AddGoalkeeperProfile(newAccountId, newGoalkeeperProfile);
            
            Assert.True(_db.GetAccount(newAccountId).GoalkeeperProfiles.First().Equals(newGoalkeeperProfile.Convert()));
        }

        [Test]
        public void AccountTryGetWorksOnlyWhenDbContainsAccount()
        {
            var newAccountId = _db.AddAccount();

            DBAccount account;
            
            Assert.True(_db.TryGetAccount(newAccountId, out account)); 
            
            _db.RemoveAccount(newAccountId);

            Assert.False(_db.TryGetAccount(newAccountId, out account));
        }
        
        [Test]
        public void AccountTryRemovingWorksOnlyWhenDbContainsAccount()
        {
            var newAccountId = _db.AddAccount();
            
            Assert.True(_db.ContainsAccount(newAccountId)); 
            
            Assert.True(_db.TryRemoveAccount(newAccountId));

            Assert.False(_db.ContainsAccount(newAccountId));
            
            Assert.False(_db.TryRemoveAccount(newAccountId));
        }
        
        [Test]
        public void AccountRemovingWorks()
        {
            var newAccountId = _db.AddAccount();
            
            Assert.True(_db.ContainsAccount(newAccountId)); 
            
            _db.RemoveAccount(newAccountId);
            
            Assert.False(_db.ContainsAccount(newAccountId));
        }

        [Test]
        public void GetAllAccountReturnAllAddedAccounts()
        {
            var newAccountIds = new[]{
                _db.AddAccount(),
                _db.AddAccount(),
                _db.AddAccount()  };

            var notAddedAccount = new DBAccount();
            
            Assert.That(_db.GetAllAccounts().Count() == newAccountIds.Count(), "Db added account count == added account count.");
            Assert.That(_db.GetAllAccounts().Select(account => account.ID).All(id => newAccountIds.Contains(id)), "Db Contains All added accounts.");
            Assert.That(_db.GetAllAccounts().Select(account => account.ID).Contains(notAddedAccount.ID) == false, "Db dont Contains not added accounts.");
        }

        [Test]
        public void NotContainsNotAddedAccount()
        {
            var newAccountId = _db.AddAccount();

            var notAddedAccountId = new DBAccount().ID;
            
            Assert.False(_db.ContainsAccount(notAddedAccountId));
        }

        [Test]
        public void ContainsAddedAccount()
        {
            var newAccountId = _db.AddAccount();
            
            Assert.True(_db.ContainsAccount(newAccountId));
        }
        #endregion
        
        protected abstract IGoalkeeperSchoolDB GetDb();

        protected abstract void ClearDb(IGoalkeeperSchoolDB db);
    }
}