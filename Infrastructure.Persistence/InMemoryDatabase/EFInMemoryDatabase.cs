﻿using System;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.InMemoryDatabase
{
    public class EFInMemoryDatabase : IDisposable
    {
        private readonly SqliteConnection _connection;

        public EFInMemoryDatabase()
        {
            _connection = new SqliteConnection("filename=:memory:");
            _connection.Open();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        private ConstructorInfo? FindSuitableConstructor<TDbContext>()
            where TDbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            var flags = BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.InvokeMethod;

            var constructor =
                typeof(TDbContext).GetConstructor(
                    flags,
                    null,
                    new[] {typeof(DbContextOptions<TDbContext>)},
                    null);

            if (constructor == null)
                constructor = typeof(TDbContext).GetConstructor(
                    flags,
                    null,
                    new[] {typeof(DbContextOptions)},
                    null);

            return constructor;
        }

        private Func<TDbContext> ResolveFactory<TDbContext>()
            where TDbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            var dbContextOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlite(_connection).Options;

            var constructor = FindSuitableConstructor<TDbContext>();

            if (constructor == null)
                throw new Exception(
                    $"no constructor found on '{typeof(TDbContext).Name}' " +
                    "with one parameter of type " +
                    $"DbContextOptions<{typeof(TDbContext).Name}>/DbContextOptions");

            return () =>
                constructor.Invoke(new object[] {dbContextOptions}) as
                    TDbContext;
        }

        public TDbContext CreateDataContext<TDbContext>(
            params object[] entities)
            where TDbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            var dbContext = ResolveFactory<TDbContext>().Invoke();
            dbContext.Database.EnsureCreated();

            if (entities?.Length > 0)
            {
                dbContext.AddRange(entities);
                dbContext.SaveChanges();
            }

            return dbContext;
        }
    }

    public static class DbContextHelper
    {
        public static void Manipulate<TDbContext>(this TDbContext dbContext,
            Action<TDbContext> manipulate)
            where TDbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            manipulate(dbContext);
            dbContext.SaveChanges();
        }
    }
}