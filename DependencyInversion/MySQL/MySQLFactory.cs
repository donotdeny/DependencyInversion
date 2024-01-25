using DependencyInversion.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.MySQL
{
    public class MySQLFactory : IFactory
    {
        public void InjectSQL(IServiceCollection services)
        {
            services.AddSingleton<IGenericRepository, DependencyInversion.MySQL.GenericRepository>();
        }
    }
}
