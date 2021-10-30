using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public interface ICommanderRepository
    {

        //get complete list
        IEnumerable<Command> GetAllCommands ();

        //get single item based on id
        Command GetCommandById(int id );
    }
}
