using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSportsApp.Models;

namespace WebApiSportsApp.IRepositories
{
    public interface ITestDetailsRepo
    {
        Task<IEnumerable<TestDetail>> GetAllTestDetails(int? id);
        Task<TestDetail> GetTestDetails(int? id);
        Task InsertTest(TestDetail testDetail);
        void UpdateTest(TestDetail testDetail);
        Task DeleteTest(int id);
        string checkFitness(decimal Distance);
    }
}
