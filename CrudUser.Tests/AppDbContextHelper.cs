using Microsoft.EntityFrameworkCore;

using System;

using CrudUser.Data;

namespace CrudUser.Tests
{
    public class AppDbContextHelper
    {
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var context = new AppDbContext(options);

            return context;
        }
    }
}
