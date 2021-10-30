using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{

    [Route("api/commands")]
    [ApiController]//this gives our controller deafult behaviours out of the box but it is not manditory to do this.
    public class CommandsController : ControllerBase     //we are extending to controllerbase instead of controller becuase we have no views.
    {


        private readonly ICommanderRepository _repository;
        private readonly IMapper _mapper;

        //pulling seeded data
        //private readonly MockCommanderRepository _mockCommanderRepository = new MockCommanderRepository();

        /*
         * This constructor has be be created in order for the 
          services.AddScoped<ICommanderRepository, MockCommanderRepository>();
        to be injected */

        public CommandsController(ICommanderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
    }
}
