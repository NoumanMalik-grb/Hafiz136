using Hafiz136.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafiz136.Database
{
    public class DataBaseconnection:DbContext
    {
        public DataBaseconnection(DbContextOptions<DataBaseconnection> options):base(options)
        {

        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
    }
}
