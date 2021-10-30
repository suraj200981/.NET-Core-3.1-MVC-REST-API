using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SQLCommanderRepo : ICommanderRepository
    {
        private readonly DBContext _context;


        /* We have to pass through the database connection from services through the
         ctor*/
        public SQLCommanderRepo(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.commands.ToList();

        }

        public Command GetCommandById(int id)
        {
            //return first element where Id is == to parameter id
            return _context.commands.FirstOrDefault(p => p.Id == id);
        }
    }
}
