using DependencyInversion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.MySQL
{
    public class GenericRepository : IGenericRepository
    {
        public Task Update()
        {
            Console.WriteLine("Update task with MySQL");
            return Task.CompletedTask;
        }
    }
}
