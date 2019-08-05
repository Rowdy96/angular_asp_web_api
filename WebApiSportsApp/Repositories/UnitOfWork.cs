using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSportsApp.IRepositories;
using WebApiSportsApp.Models;

namespace WebApiSportsApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private WebApiSportsAppContext _context;
        private ITestRepo _testRepo;
        private ITestDetailsRepo _testDetailsRepo;

        public UnitOfWork(WebApiSportsAppContext context)
        {
            this._context = context;
        }
        public ITestRepo TestRepo {

            get
            {
                this._testRepo = new TestRepo(_context);
                return this._testRepo;
            }
        }

        public ITestDetailsRepo testDetailsRepo {
            get
            {
                this._testDetailsRepo = new TestDetailsRepo(_context);
                return this._testDetailsRepo;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
