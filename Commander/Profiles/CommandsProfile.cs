using AutoMapper;
using Commander.DTOs;
using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile // profile is from automapper
    {

        public CommandsProfile()
        {
            //createmap method maps command model to readdto model
            CreateMap<Command, ReadDTO>();
            //createmap method maps command model to createDTO model

            CreateMap<Command, CreateDTO>();

        }

    }
}
