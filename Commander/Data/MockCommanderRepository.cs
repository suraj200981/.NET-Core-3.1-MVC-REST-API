using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> {
                new Command
                 {
                     Id = 1,
                     HowTo = "Dance",
                     Line = "Lets Dance",
                     Platform = "youtube"
                 },
                 new Command
                 {
                     Id = 2,
                     HowTo = "Cook",
                     Line = "Lets Cook",
                     Platform = "youtube"
                 },
                  new Command
                 {
                     Id = 3,
                     HowTo = "Eat",
                     Line = "Lets Eat",
                     Platform = "vimeo"
                 }
        };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { 
                Id = 1, 
                HowTo = "Dance", 
                Line = "Lets dance", 
                Platform = "youtube" 
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
