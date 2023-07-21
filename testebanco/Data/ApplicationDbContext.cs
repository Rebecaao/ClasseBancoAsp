using Microsoft.EntityFrameworkCore;
using testebanco.Models;

namespace testebanco.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        
    }
}