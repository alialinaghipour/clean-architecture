namespace Test.Infrastructure.DatabaseConfig.Integration
{
    [Collection(nameof(DatabaseIntegrationFixture))]
    public class DatabaseIntegrationFixture
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _readContext;
        private readonly ApplicationDbContext _setupContext;

        protected DatabaseIntegrationFixture()
        {
            _context = ApplicationDbContextFactory.CreateContext();
            _setupContext = ApplicationDbContextFactory.CreateContext();
            _readContext = ApplicationDbContextFactory.CreateContext();
        }

        protected ApplicationDbContext WriteDataContext()
        {
            return _context;
        }

        protected ApplicationDbContext ReadDataContext()
        {
            return _readContext;
        }

        protected ApplicationDbContext SetupDataContext()
        {
            return _setupContext;
        }

        protected void Run(Action specTest)
        {
            try
            {
                specTest();
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        public void Dispose()
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' ");
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_MSForEachTable 'DELETE FROM ?' ");
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL' ");
            _context.SaveChanges();
        }
    }
}
