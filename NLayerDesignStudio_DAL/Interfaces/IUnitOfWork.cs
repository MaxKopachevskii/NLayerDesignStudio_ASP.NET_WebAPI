using NLayerDesignStudio_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDesignStudio_DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Service> Services { get; }
        IRepository<Master> Masters { get; }
        IRepository<Example> Examples { get; }
        void Save();
    }
}
