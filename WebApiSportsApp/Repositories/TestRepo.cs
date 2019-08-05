using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSportsApp.IRepositories;
using WebApiSportsApp.Models;

namespace WebApiSportsApp.Repositories
{
    public class TestRepo : ITestRepo
    {
        private WebApiSportsAppContext _context;

        public TestRepo(WebApiSportsAppContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Test>> GetAllTests()
        {
            foreach (var db in _context.Test)
            {
                db.NumOfParticipants = getNumOfParticipants(db.TestId);
            }

            var Tests = from t in _context.Test orderby t.Date descending select t;
            return Tests.AsEnumerable<Test>();
        }

        public async Task<Test> GetTestByID(int? id)
        {
            return await _context.Test.FindAsync(id);
        }

        public async Task InsertTest(Test test)
        {
            await _context.AddAsync(test);
        }

       
        public void UpdateTest(Test test)
        {
              _context.Update(test);
        }


        public void DeleteTest(int id)
        {
            Test test = _context.Test.FirstOrDefault(m => m.TestId == id);
            _context.Test.Remove(test);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }


        int getNumOfParticipants(int id)
        {
            int numOfParticipants = (from t in _context.Test
                                     join tr in _context.TestDetail
                                     on t.TestId equals tr.TestId
                                     where tr.TestId.Equals(id)
                                     select tr.AthleteName).Count();

            return numOfParticipants;
        }
    }
}
