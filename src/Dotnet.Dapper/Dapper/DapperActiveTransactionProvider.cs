﻿using Dotnet.Data.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Dotnet.Dapper
{
    public class DapperActiveTransactionProvider: IActiveTransactionProvider
    {
        private readonly IDbContext _dbContext;
        private DbProviderFactory DbFactory {
            get { return _dbContext.GetDbFactory(); }
        }

        public DapperActiveTransactionProvider(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbTransaction GetActiveTransaction(ActiveTransactionProviderArgs args)
        {
            //return GetActiveConnection(args).BeginTransaction();
            return null;
        }

        public IDbConnection GetActiveConnection(ActiveTransactionProviderArgs args)
        {
           var connection = DbFactory.CreateConnection();
            connection.ConnectionString = _dbContext.ConnectionString;
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}