using System;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Type = DataAccessLayer.Models.Type;

namespace DataAccessLayer.Data
{
    // Sources :
    // https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
    // https://www.youtube.com/watch?v=Yhmg5VJlSwY
    /// <summary>
    /// Define a context class and entity classes that make up the model
    /// </summary>
    public class MovieContext : DbContext
    {
        #region MEMBERS_VARIABLES
        public DbSet<Actor> DbActors { get; set; }
        public DbSet<Comment> DbComments { get; set; }
        public DbSet<Movie> DbMovies { get; set; }
        public DbSet<Role> DbRoles { get; set; }
        public DbSet<Type> DbTypes { get; set; }
        public string DbPath { get; private set; }
        #endregion

        #region BUILDERS
        /// <summary>
        /// This method will help us to specify the path of the database
        /// </summary>
        public MovieContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder, Environment.SpecialFolderOption.None);
            if(path != null)
                DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}movie.db";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options">the options to be used by a DbContext</param>
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {
            Database.EnsureCreated();
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie_Actor>().HasKey(l => new { l.Id });
        }*/

        /// <summary>
        /// The following configures EF to create a Sqlite database file in the
        /// special "local" folder for your platform
        /// </summary>
        /// <param name="options">a builder used to create or modify options for this context</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            SqliteConnectionStringBuilder co = new SqliteConnectionStringBuilder();
            co.DataSource = DbPath;
            options.UseSqlite(co.ToString());
            options.EnableSensitiveDataLogging(true); // Includes application data in exceptions and logging
            options.EnableDetailedErrors(true); // More detailed query errors (at the expense of performance)
        }
        #endregion
    }
}
