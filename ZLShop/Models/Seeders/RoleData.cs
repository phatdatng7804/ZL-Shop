using Microsoft.EntityFrameworkCore;
using ZLShop.Models.Entities;
namespace ZLShop.Models.Seeders;

public class RoleData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "admin" },
            new Role { Id = 2, Name = "staff" },
            new Role { Id = 3, Name = "user" }
        );
    }
}