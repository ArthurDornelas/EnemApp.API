using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnemApp.API.Data.Repositories;
using EnemApp.API.Models;
using FluentValidation;

namespace EnemApp.API.Services
{
    public class BaseService<T> where T : BaseEntity
    {
        
    }
}
