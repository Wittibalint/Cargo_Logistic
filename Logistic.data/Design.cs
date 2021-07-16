using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistic.Data
{
    internal class LogisticDesignTimeDbContextFactoryDesign : IDesignTimeDbContextFactory<LogisticDbContext>
    {
        public LogisticDbContext CreateDbContext(string[] args) =>
            new LogisticDbContext(new Logger<LogisticDbContext>(new LoggerFactory()), new DbContextOptionsBuilder<LogisticDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Logistic").Options);
    }
}
