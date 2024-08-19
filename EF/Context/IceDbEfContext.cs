using EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EF.Context;

public class IceDbEfContext(DbContextOptions<IceDbEfContext> options) : DbContext(options)
{
    public DbSet<Userinfo> Userinfo { get; set; }
}