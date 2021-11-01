using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    [Route("api/commands")]
    [ApiController]//this gives our controller deafult behaviours out of the box but it is not manditory to do this.
    public class CommandsController : ControllerBase     //we are extending to controllerbase instead of controller becuase we have no views.
    {

        private readonly DBContext _context;
        private readonly ICommanderRepository _repository;
        private readonly IMapper _mapper;

        //pulling seeded data
        //private readonly MockCommanderRepository _mockCommanderRepository = new MockCommanderRepository();

        /*
         * This constructor has be be created in order for the 
          services.AddScoped<ICommanderRepository, MockCommanderRepository>();
        to be injected */

        public CommandsController(ICommanderRepository repository, IMapper mapper, DBContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        /**********Requests*********/

        //GET api/commands/
        [HttpGet]
        public ActionResult<List<ReadDTO>> getAllCommands() {

            var items = _repository.GetAllCommands();

            //this will return list of mapped DTO objects
            return Ok(_mapper.Map<List<ReadDTO>>(items));
        }


        //GET api/commands/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadDTO> getById(int id)
        {

            var specificItem = _repository.GetCommandById(id);

            if (specificItem == null) {
                return NotFound(); //404 instead of 204 no content error
            }

            //this will return mapped DTO object
            return Ok(_mapper.Map<ReadDTO>(specificItem));
        }


        //POST api/commands/create
        [HttpPost]
        [Route("create")]
        public ActionResult<CreateDTO>  Create(Command command) {

           _repository.CreateCommand(command);
            _context.SaveChanges();

            return Ok();

        }

        //PUT api/commands/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateDTO commandUpdateDTO)
        {

            var commandFromDB = _repository.GetCommandById(id);


            commandFromDB.HowTo = commandUpdateDTO.HowTo;
            commandFromDB.Line = commandUpdateDTO.Line;
            commandFromDB.Platform = commandUpdateDTO.Platform;

            _context.SaveChanges();

            return Ok();

        }

        //DELETE api/commands/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {

            var commandToDelete = _repository.GetCommandById(id);
            _repository.DeleteCommand(commandToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
