using NLayerDesignStudio_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDesignStudio_BLL.Interfaces
{
    public interface IStudioService
    {
        ServiceDTO GetService(int? id);
        MasterDTO GetMaster(int? id);
        ExampleDTO GetExample(int? id);
        IEnumerable<ServiceDTO> GetAllServices();
        IEnumerable<MasterDTO> GetAllMasters();
        IEnumerable<ExampleDTO> GetAllExamples();
        void Edit(ServiceDTO service);
        void Create(ServiceDTO service);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}
