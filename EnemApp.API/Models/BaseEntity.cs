using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnemApp.API.Models
{
    public class BaseEntity<T> where T : class
    {
        public int Id { get; set; }
    }
}
