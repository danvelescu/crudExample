using AutoMapper;
using crudExample.Application.Tasks.Commands;
using crudExample.Application.Tasks.Dto;
using crudExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExample.Application.Profiles
{
    public class TaskProfile : Profile
    {

        public TaskProfile()
        {
            CreateMap<UserTask, TaskDto>();
            CreateMap<CreateTaskCommand, UserTask>();
        }

    }
}
