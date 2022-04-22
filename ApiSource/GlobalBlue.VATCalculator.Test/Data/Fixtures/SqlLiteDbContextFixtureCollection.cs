using Xunit;

namespace GlobalBlue.VATCalculator.Test.Data.Fixtures;

[CollectionDefinition("SqlLiteDbContext collection")]
public class SqlLiteDbContextFixtureCollection : ICollectionFixture<SqlLiteDbContextFixture>
{

}