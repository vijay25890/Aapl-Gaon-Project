using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var PeopleRole = "2bc7d74c-f1f3-4d79-91ad-338f381a9bb9";
            var SarpanchRole = "4da6bcdb-80fe-4569-832f-7809e2cd9332";
            var AdminRole = "3124da6bdb-80fe-4569-832f-7809e2cd93";

            //roles
            var roles = new List<IdentityRole> {
                new IdentityRole()
                {
                Id = PeopleRole,
                Name = "People",
                NormalizedName = "People".ToUpper(),
                ConcurrencyStamp = PeopleRole
                },
                new IdentityRole()
                {
                Id = SarpanchRole,
                Name = "Sarpanch",
                NormalizedName = "Sarpanch".ToUpper(),
                ConcurrencyStamp = SarpanchRole
                },
                new IdentityRole()
                {
                Id = AdminRole,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                ConcurrencyStamp = AdminRole
                }
            };

            //seed the role
            builder.Entity<IdentityRole>().HasData(roles);

            //create admin user
            var adminId1 = "90b682fd-a6b1-48a3-8663-477ad65d7039";
            var adminId2 = "90b682fd-a6b1-48a3-8663-477ad65d7040";
            var admin = new List<IdentityUser>() {
            new(){
                Id = adminId1,
                UserName = "vijaymore25890@gmail.com",
                Email = "vijaymore25890@gmail.com",
                NormalizedEmail = "vijaymore25890@gmail.com".ToUpper(),
                NormalizedUserName = "vijaymore25890@gmail.com".ToUpper(),
                PhoneNumber = "7507002561"
            },
            new(){
                Id = adminId2,
                UserName = "shubhamkale@gmail.com",
                Email = "shubhamkale@gmail.com",
                NormalizedEmail = "shubhamkale@gmail.com".ToUpper(),
                NormalizedUserName = "shubhamkale@gmail.com".ToUpper(),
                PhoneNumber = "9145676968"
            }
        };
            
            admin[0].PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin[0], "Vijay@123");
            admin[1].PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin[0], "Shubham@123");
            builder.Entity<IdentityUser>().HasData(admin);

            //give roles to admin 
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminId1,
                    RoleId = PeopleRole
                },
                new()
                {
                    UserId = adminId1,
                    RoleId = SarpanchRole
                },
                new()
                {
                    UserId = adminId2,
                    RoleId = PeopleRole
                },
                new()
                {
                    UserId = adminId2,
                    RoleId = SarpanchRole
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}
