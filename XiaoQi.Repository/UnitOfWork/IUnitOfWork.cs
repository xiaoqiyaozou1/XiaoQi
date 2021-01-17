using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoQi.Repository.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        DbContext GetContext();
        void BeginTran();

        void CommitTran();
        void RollbackTran();
    }
}
