using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    interface ICommanderRepository
    {

        //get complete list
        IEnumerable<Command> GetAppCommands();

        //get single item based on id
        Command GetCommandById(int id );
    }
}
