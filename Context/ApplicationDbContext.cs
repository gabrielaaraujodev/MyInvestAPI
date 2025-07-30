using Microsoft.EntityFrameworkCore;

namespace MyInvest.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
}
