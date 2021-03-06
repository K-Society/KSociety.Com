﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Tcp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Tcp
{
    public class Connection : RepositoryBase<ComContext, Domain.Entity.Tcp.TcpConnection>, IConnection
    {
        public Connection(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory)
            : base(logFactory, databaseFactory)
        {
        }

        public IEnumerable<Domain.Entity.Tcp.TcpConnection> GetAllTcpConnection()
        {
            return FindAll().OrderBy(x => x.Name).ToList();
        }

        public async ValueTask<IEnumerable<Domain.Entity.Tcp.TcpConnection>> GetAllTcpConnectionAsync()
        {
            return await FindAll().OrderBy(x => x.Name).ToListAsync();
        }
    }
}
