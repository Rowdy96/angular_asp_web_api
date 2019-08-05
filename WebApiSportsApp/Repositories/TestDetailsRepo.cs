using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSportsApp.IRepositories;
using WebApiSportsApp.Models;

namespace WebApiSportsApp.Repositories
{
    public class TestDetailsRepo : ITestDetailsRepo
    {
        private WebApiSportsAppContext _context;

        public TestDetailsRepo(WebApiSportsAppContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TestDetail>> GetAllTestDetails(int? id)
        {
            var result = from t in _context.Test
                         join tr in _context.TestDetail
                         on t.TestId equals tr.TestId
                         where tr.TestId.Equals(id)
                         orderby tr.Distance descending
                         select new TestDetail
                         {
                             AthleteId = tr.AthleteId,
                             AthleteName = tr.AthleteName,
                             Distance = tr.Distance,
                             MyProperty = tr.MyProperty,
                             TestId = tr.TestId,

                         };


            var tmp = result.AsEnumerable<TestDetail>();
            return tmp;
        }

        public async  Task<TestDetail> GetTestDetails(int? id)
        {
            var testDetails = await _context.TestDetail.FindAsync(id);
            return testDetails;
        }

        public async Task InsertTest(TestDetail testDetail)
        {
            testDetail.MyProperty = checkFitness(testDetail.Distance);
            await _context.AddAsync(testDetail);
        }

        public void UpdateTest(TestDetail testDetail)
        {
            testDetail.MyProperty = checkFitness(testDetail.Distance);
            _context.Update(testDetail);
        }

        public async Task DeleteTest(int id)
        {
            TestDetail testDetails = await _context.TestDetail.FindAsync(id);
            _context.TestDetail.Remove(testDetails);
        }

        public string checkFitness(decimal Distance)
        {
            string Fitness;

            if (Distance <= 1000)
            {
                Fitness = "Bellow Average";
            }
            else if (Distance > 1000 && Distance <= 2000)
            {
                Fitness = "Average";
            }
            else if (Distance > 2000 && Distance <= 3500)
            {
                Fitness = "Good";
            }
            else
            {
                Fitness = "Very Good";
            }
            return Fitness;
        }
    }
}
