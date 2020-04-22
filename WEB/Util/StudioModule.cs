using Ninject.Modules;
using NLayerDesignStudio_BLL.Interfaces;
using NLayerDesignStudio_BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Util
{
    public class StudioModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudioService>().To<StudioService>();
        }
    }
}