using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.Interfaces
{
    public interface IGenericRepository
    {
        Task Update();
    }
}
