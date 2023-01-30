using System;
using System.Collections.Generic;
using BoligmappaConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace BoligmappaConsole.Data
{
    public class BoligmappaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserTodo> UserTodos { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        public BoligmappaContext(DBContextOptions<BoligmappaContext> options) => base(options);

        // Table splitting so we can have multiple entities that are stored in same table.
        // Enables me to query on each entity individually or across grouping entity (UserDetails)
        // without needing to perform joins
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<UserDetail>()  
            .HasMany(p => p.Todos)  
            .WithOne(p => p.UserId)
            .HasForeignKey<UserTodo>(e => e.UserId);

            modelBuilder.Entity<UserDetail>()  
            .HasMany(p => p.Posts)  
            .WithOne(p => p.UserId)
            .HasForeignKey<Post>(e => e.UserId);

            modelBuilder.Entity<UserDetail>()  
            .HasOne(p => p.Id)  
            .WithOne(p => p.UserId)
            .HasForeignKey<User>(e => e.Id);

            modelBuilder.Entity<UserDetail>().ToTable("UserDetails");
            modelBuilder.Entity<UserTodo>().ToTable("UserDetails");
            modelBuilder.Entity<Post>().ToTable("UserDetails");
            modelBuilder.Entity<User>().ToTable("UserDetails");
        }  

    }
}