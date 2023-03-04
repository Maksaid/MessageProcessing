using MessageProcessingService.DAL.Abstractions;
using MessageProcessingService.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingService.DAL;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Message> Messages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(
            builder =>
            {
                builder.HasMany(x => x.DepartmentEmployees).WithOne(x => x.Department);
                builder.HasMany(x => x.Messages).WithOne(x => x.Department);
                builder.HasKey(x => x.Id);
            });
        modelBuilder.Entity<Employee>(
            builder =>
            {
                builder.HasOne(x => x.Department).WithMany(x => x.DepartmentEmployees);
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name);
                builder.HasOne(x => x.Account).WithOne().IsRequired();
            });
        modelBuilder.Entity<Message>(
            builder =>
            {
                builder.HasDiscriminator<string>("message_type").HasValue<EmailTextMessage>("email_text_message");
                builder.HasKey(x => x.Id);
                builder.HasOne(x => x.Department).WithMany(x => x.Messages);
            }

        );
        modelBuilder.Entity<Account>(
            builder =>
            {
                builder.Property(x => x.Login).IsRequired();
                builder.Property(x => x.Password).IsRequired();
                builder.HasKey(x => x.Id);
            }
        );
    }
}