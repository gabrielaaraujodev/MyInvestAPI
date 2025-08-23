using Microsoft.EntityFrameworkCore;
using MyInvest.Entities;

namespace MyInvest.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionCategory> TransactionsCategory { get; set; }
    public DbSet<TransactionType> TransactionsType { get; set; }
    public DbSet<Scene> Scenes { get; set; }
}
