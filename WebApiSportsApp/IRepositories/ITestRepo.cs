using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSportsApp.Models;

namespace WebApiSportsApp.IRepositories
{
   public interface ITestRepo
    {
        Task<IEnumerable<Test>> GetAllTests();
        Task<Test> GetTestByID(int? id);
        Task InsertTest(Test test);
        void UpdateTest(Test test);
        void DeleteTest(int id);
        Task Save();
    }
}
