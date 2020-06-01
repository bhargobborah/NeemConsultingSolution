using NeemDataModel.Models;
using System.Data.Entity;

namespace NeemDataAccess
{
    /// <summary>
    /// DataContext class
    /// </summary>
    public class NeemDBContext : DbContext
    {
        public NeemDBContext() : base("NeemDBContext")
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
