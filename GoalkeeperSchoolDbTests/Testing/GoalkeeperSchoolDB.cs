using GoalkeeperSchoolDataAcess.DataAcess;
using GoalkeeperSchoolDataAcess.DataAcess.Core;

namespace GoalkeeperSchoolDbTests.Testing
{
    public class GoalkeeperSchoolDBTests : IGoalkeeperDbTests
    {
        protected override IGoalkeeperSchoolDB GetDb()
        {
            return new GoalkeeperSchoolDB();
        }

        protected override void ClearDb(IGoalkeeperSchoolDB db)
        {
            db.Clear("y23ucgxz42_yxfct261_fdxcfdx26");
        }
    }
}