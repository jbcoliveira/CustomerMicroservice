using API.Configurations;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Tests
{
    public class TestBase
    {
        protected ApplicationDbContext _dbContext;

        //It is called every run on derived classes
        [SetUp]
        public void Setup()
        {
            DatabaseInitializing();
        }

        private void DatabaseInitializing()
        {
            //Creating a in-memory database for each test (databaseName: Guid.NewGuid().ToString())
            //If you would like to use the same instance of database, set de databasename parameter (ex.: databaseName: Mentoria)

            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Mentoria", databaseRoot: new InMemoryDatabaseRoot())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging();

            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            //Ensure that database was created
            _dbContext.Database.EnsureCreated();

            //Seed
            DbInitializer.Initialize(_dbContext);
        }

        //It is called every run on derived classes
        [TearDown]
        public void TearDown()
        {

        }
    }
}
