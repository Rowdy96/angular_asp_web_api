using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSportsApp.IRepositories
{
    public interface IUnitOfWork
    {
        ITestRepo TestRepo { get;  }
        ITestDetailsRepo testDetailsRepo { get; }
        Task Save();
    }
}
