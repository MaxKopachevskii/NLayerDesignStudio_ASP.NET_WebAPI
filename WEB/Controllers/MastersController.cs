using AutoMapper;
using NLayerDesignStudio_BLL.DTO;
using NLayerDesignStudio_BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB.Models;

namespace WEB.Controllers
{
    public class MastersController : ApiController
    {
        StudioService studioService;
        public MastersController()
        {
            studioService = new StudioService();
        }

        public IEnumerable<MasterViewModel> GetAllMasters()
        {
            IEnumerable<MasterDTO> temp = studioService.GetAllMasters();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MasterDTO, MasterViewModel>()).CreateMapper();
            var masters = mapper.Map<IEnumerable<MasterDTO>, List<MasterViewModel>>(temp);
            return masters;
        }

        public MasterDTO GetMaster(int id)
        {
            var master = studioService.GetMaster(id);
            return master;
        }

        [HttpPost]
        public void Create([FromBody]MasterViewModel master)
        {
            var serv = new MasterDTO { Id = master.Id, Name = master.Name, Age = master.Age, YearsOfWork = master.YearsOfWork };
            studioService.CreateMaster(serv);
            studioService.Save();
        }

        [HttpPut]
        public void Edit(int id, [FromBody]MasterViewModel master)
        {
            var serv = new MasterDTO { Id = master.Id, Name = master.Name, Age = master.Age, YearsOfWork = master.YearsOfWork };
            studioService.EditMaster(serv);
            studioService.Save();
        }

        public void Delete(int id)
        {
            studioService.DeleteMaster(id);
            studioService.Save();
        }
    }
}
