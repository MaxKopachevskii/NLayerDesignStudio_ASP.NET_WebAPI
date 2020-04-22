using AutoMapper;
using NLayerDesignStudio_BLL.DTO;
using NLayerDesignStudio_BLL.Interfaces;
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
    public class ServiceController : ApiController
    {
        StudioService studioService;
        public ServiceController()
        {
            studioService = new StudioService();
        }

        public IEnumerable<ServiceViewModel> GetAllServices()
        {
            IEnumerable<ServiceDTO> phoneDtos = studioService.GetAllServices();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ServiceDTO, ServiceViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<ServiceDTO>, List<ServiceViewModel>>(phoneDtos);
            return services;
        }

        public ServiceDTO GetService(int id)
        {
            var servise = studioService.GetService(id);
            return servise;
        }

        [HttpPost]
        public void Create([FromBody]ServiceViewModel service)
        {
            var serv = new ServiceDTO { Id = service.Id, Description = service.Description, Img = service.Img, Name = service.Name, Price = service.Price };
            studioService.Create(serv);
            studioService.Save();
        }

        [HttpPut]
        public void Edit(int id,[FromBody]ServiceViewModel service)
        {
            var serv = new ServiceDTO { Id = service.Id, Description = service.Description, Img = service.Img, Name = service.Name, Price = service.Price };
            studioService.Edit(serv);
            studioService.Save();
        }

        public void Delete(int id)
        {
            studioService.Delete(id);
            studioService.Save();
        }
    }
}
