using InspectionAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DataContext _context;
        public DbInitializer(DataContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            // Update database with migrations if they are not applied
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}