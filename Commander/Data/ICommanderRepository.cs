﻿using Commander.Models;
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

        //create new command
        void CreateCommand(Command command);

        //update a current command
        void UpdateCommand(Command command);

        //delete command by id
        void DeleteCommand(Command command);

    }
}
