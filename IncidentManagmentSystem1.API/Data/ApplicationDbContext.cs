using IncidentManagmentSystem1.API.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagmentSystem1.API.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    //Application DbSets : 




    public DbSet<Department> Departments { get; set; }




    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
