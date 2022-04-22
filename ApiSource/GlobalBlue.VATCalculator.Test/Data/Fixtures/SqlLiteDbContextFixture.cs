using System;
using System.Diagnostics.CodeAnalysis;
using GlobalBlue.VATCalculator.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalBlue.VATCalculator.Test.Data.Fixtures;

public class SqlLiteDbContextFixture : IDisposable
{
    private static AppDbContext? _databaseContext;

    public SqlLiteDbContextFixture()
    {
        const string connectionString = $"Data Source = TestAppDb.db";
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connectionString)
            .Options;

        _databaseContext = new AppDbContext(options);

        _databaseContext.Database.EnsureDeleted();
        _databaseContext.Database.EnsureCreated();

        Context = _databaseContext;
    }

    public void Dispose()
    {
        Context?.Database.EnsureDeleted();
        this.Context?.Dispose();
        GC.SuppressFinalize(this);
    }

    [DisallowNull]
    public AppDbContext? Context
    {
        get => _databaseContext;
        private init
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
        }
    }
}