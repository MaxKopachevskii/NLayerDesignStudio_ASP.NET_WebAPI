using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDesignStudio_DAL.Entities
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Price { get; set; }

        public string Img { get; set; }

        public int? MasterId { get; set; }

        public virtual Master Master { get; set; }
    }
}
