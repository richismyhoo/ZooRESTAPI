using Microsoft.EntityFrameworkCore;
using ZooAPI.Models;

namespace ZooAPI.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Animal> Animals { get; set; }
}