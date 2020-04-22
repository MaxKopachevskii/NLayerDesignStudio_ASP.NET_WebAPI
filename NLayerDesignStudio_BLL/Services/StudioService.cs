using AutoMapper;
using NLayerDesignStudio_BLL.DTO;
using NLayerDesignStudio_BLL.Interfaces;
using NLayerDesignStudio_DAL.Entities;
using NLayerDesignStudio_DAL.Interfaces;
using NLayerDesignStudio_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDesignStudio_BLL.Services
{
    public class StudioService : IStudioService
    {
        UnitOfWork Database { get; set; }

        public StudioService()
        {
            Database = new UnitOfWork("DefaultConnection");
        }

        public ExampleDTO GetExample(int? id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id телефона", "");
            var example = Database.Examples.Get(id.Value);
            //if (example == null)
            //    throw new ValidationException("Пример для портфолио не найден", "");

            return new ExampleDTO { Id = example.Id, Name = example.Name, Desc = example.Desc, Img = example.Img };
        }
        public void Create(ServiceDTO service)
        {
            Service serv = new Service
            {
                Id = service.Id,
                Description = service.Description,
                Name = service.Name,
                Price = service.Price,
                Img = service.Img,
                MasterId = service.MasterId
            };
            Database.Services.Create(serv);
        }

        public void CreateMaster(MasterDTO master)
        {
            Master serv = new Master
            {
                Id = master.Id,
                Name = master.Name,
                Age = master.Age,
                YearsOfWork = master.YearsOfWork
            };
            Database.Masters.Create(serv);
        }

        public void CreateExample(ExampleDTO example)
        {
            Example serv = new Example
            {
                Id = example.Id,
                Name = example.Name,
                Desc = example.Desc,
                Img = example.Img
            };
            Database.Examples.Create(serv);
        }

        public void Edit(ServiceDTO service)
        {
            Service serv = new Service
            {
                Id = service.Id,
                Description = service.Description,
                Name = service.Name,
                Price = service.Price,
                Img = service.Img,
                MasterId = service.MasterId
            };
            Database.Services.Update(serv);
        }

        public void EditMaster(MasterDTO master)
        {
            Master serv = new Master
            {
                Id = master.Id,
                Name = master.Name,
                Age = master.Age,
                YearsOfWork = master.YearsOfWork
            };
            Database.Masters.Update(serv);
        }

        public void EditExample(ExampleDTO example)
        {
            Example serv = new Example
            {
                Id = example.Id,
                Name = example.Name,
                Desc = example.Desc,
                Img = example.Img
            };
            Database.Examples.Update(serv);
        }

        public void Delete(int id)
        {
            Database.Services.Delete(id);
        }

        public void DeleteMaster(int id)
        {
            Database.Masters.Delete(id);
        }

        public void DeleteExample(int id)
        {
            Database.Examples.Delete(id);
        }

        public MasterDTO GetMaster(int? id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id телефона", "");
            var master = Database.Masters.Get(id.Value);
            //if (master == null)
            //    throw new ValidationException("Мастер не найден", "");

            return new MasterDTO { Id = master.Id, Name = master.Name, Age = master.Age, YearsOfWork = master.YearsOfWork };
        }

        public ServiceDTO GetService(int? id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id телефона", "");
            var service = Database.Services.Get(id.Value);
            //if (service == null)
            //    throw new ValidationException("Сервис не найден", "");

            return new ServiceDTO { Id = service.Id, Name = service.Name, Img = service.Img, Description = service.Description, MasterId = service.MasterId, Price = service.Price };
        }



        public IEnumerable<ExampleDTO> GetAllExamples()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Example, ExampleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Example>, List<ExampleDTO>>(Database.Examples.GetAll());
        }

        public IEnumerable<MasterDTO> GetAllMasters()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Master, MasterDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Master>, List<MasterDTO>>(Database.Masters.GetAll());
        }

        public IEnumerable<ServiceDTO> GetAllServices()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Service>, List<ServiceDTO>>(Database.Services.GetAll());
        }

        public void Save()
        {
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
