using HashimAuth.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HashimAuth.Server.Data
{
    public class HashimContext : IdentityDbContext<HashimUser>
    {
        public HashimContext(DbContextOptions<HashimContext> options) : base(options)
        {

        }
    }
}
