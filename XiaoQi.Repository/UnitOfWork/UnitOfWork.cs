using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoQi.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public void BeginTran()
        {
            throw new NotImplementedException();
        }

        public void CommitTran()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DbContext GetContext()
        {
            throw new NotImplementedException();
        }

        public void RollbackTran()
        {
            throw new NotImplementedException();
        }
    }
}
