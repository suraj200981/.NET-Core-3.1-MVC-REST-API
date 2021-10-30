using Commander.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class DBContext : DbContext //Extends DbContext which is from Entity framework
    {

        public DBContext(DbContextOptions<DBContext> opt):base (opt)
        {

        }
        /*This is saying that we want to represent our command objects 
         down to our database as a DbSet*/
        public DbSet<Command> commands { get; set; }
    }
}
