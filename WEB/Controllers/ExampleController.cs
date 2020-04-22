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
    public class ExampleController : ApiController
    {
        StudioService studioService;
        public ExampleController()
        {
            studioService = new StudioService();
        }

        public IEnumerable<ExampleViewModel> GetAllExamples()
        {
            IEnumerable<ExampleDTO> temp = studioService.GetAllExamples();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExampleDTO, ExampleViewModel>()).CreateMapper();
            var example = mapper.Map<IEnumerable<ExampleDTO>, List<ExampleViewModel>>(temp);
            return example;
        }

        public ExampleDTO GetExample(int id)
        {
            var example = studioService.GetExample(id);
            return example;
        }

        [HttpPost]
        public void Create([FromBody]ExampleViewModel example)
        {
            var serv = new ExampleDTO { Id = example.Id, Name = example.Name, Desc = example.Desc, Img = example.Img };
            studioService.CreateExample(serv);
            studioService.Save();
        }

        [HttpPut]
        public void Edit(int id, [FromBody]ExampleViewModel example)
        {
            var serv = new ExampleDTO { Id = example.Id, Name = example.Name, Desc = example.Desc, Img = example.Img};
            studioService.EditExample(serv);
            studioService.Save();
        }

        public void Delete(int id)
        {
            studioService.DeleteExample(id);
            studioService.Save();
        }
    }
}
