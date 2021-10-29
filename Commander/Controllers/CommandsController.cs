﻿using Commander.Data;
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

        //pulling seeded data
        private readonly MockCommanderRepository _mockCommanderRepository = new MockCommanderRepository();


        /**********Requests*********/

        //GET api/commands/
        [HttpGet]
        public ActionResult<List<Command>> getAllCommands() {

            var items = _mockCommanderRepository.GetAppCommands();

            return Ok(items);
        }


        //GET api/commands/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Command> getById(int id)
        {

            var specificItem = _mockCommanderRepository.GetCommandById(id);

            return Ok(specificItem);
        }
    }
}