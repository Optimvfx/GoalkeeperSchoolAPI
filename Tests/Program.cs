using System;
using System.Linq;
using GoalkeeperSchoolDataAcess.DataAcess;
using GoalkeeperSchoolDataAcess.DataAcess.Controlers;
using GoalkeeperSchoolDataAcess.Models;
using GoalkeeperSchoolDataAcess.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var goalkeeperDb = new GoalkeeperSchoolDB();

            Console.WriteLine(goalkeeperDb.GetAllAccounts().Count());
            
            goalkeeperDb.Clear("y23ucgxz42_yxfct261_fdxcfdx26");
            
            Console.WriteLine(goalkeeperDb.GetAllAccounts().Count());

            Console.ReadKey();
        }
    }
}