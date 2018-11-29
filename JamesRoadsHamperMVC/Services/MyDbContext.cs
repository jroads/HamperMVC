using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//..
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JamesRoadsHamperMVC.Models;

namespace JamesRoadsHamperMVC.Services
{
    public class MyDbContext : IdentityDbContext
    {
        public DbSet<Hamper> TblHamper { get; set; }
        public DbSet <UserAccount> TblUserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server= (localdb)\MSSQLLocalDB ; Database= HamperMVCDB ; Trusted_Connection=True");
        }
    }
}