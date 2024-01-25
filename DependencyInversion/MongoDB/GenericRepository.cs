using DependencyInversion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.MongoDB
{
    public class GenericRepository : IGenericRepository
    {
        public Task Update()
        {
            Console.WriteLine("Update task with MongoDB");
            return Task.CompletedTask;
        }
    }
}
