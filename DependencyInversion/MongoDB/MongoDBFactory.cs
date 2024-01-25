using DependencyInversion.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.MongoDB
{
    public class MongoDBFactory : IFactory
    {
        public void InjectSQL(IServiceCollection services)
        {
            services.AddSingleton<IGenericRepository, DependencyInversion.MongoDB.GenericRepository>();
        }
    }
}
