using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Xx.His.Domain;
using Xx.His.Core;
using Xx.His.Utils;
using log4net;
using System.Reflection;
using SmartBed.Domain;
using SmartBed.Contract.Service;
using SmartBed.Service;

namespace UnitTestProject
{
    public class BootStrapper
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Build unity container
        /// </summary>
        /// <param name="connectionString">The name of connectionstring in configuration</param>
        /// <returns></returns>
        public static IUnityContainer BuildContainer(string connectionString)
        {
            var mappedToTypeAssembly = typeof(SmartBedService).Assembly;

            // Automapper configurations
            MapperConfiguration.Configure(mappedToTypeAssembly);
            
            // Unity container configurations
            return ContainerBuilder.Build<SmartBedDbContext>(connectionString)
                .RegisterTypes(typeof(ISmartBedService).Assembly, mappedToTypeAssembly)
                .RegisterType<ISmartBedService, SmartBedService>()
                .RegisterType<ICloudService, CloudService>()
                ;
                ;
        }
    }
}
