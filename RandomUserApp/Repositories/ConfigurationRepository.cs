using RandomUserApp.Data;
using RandomUserApp.Models;
using System.Configuration;

namespace RandomUserApp.Repositories
{
    public class APPConfigurationRepository
    {
        private readonly DataContext _context;

        public APPConfigurationRepository(DataContext context)
        {
            _context = context;
        }

        public APPConfiguration GetAppConfiguration()
        {
            return _context.APPConfiguration.SingleOrDefault();
        }
    }
}
