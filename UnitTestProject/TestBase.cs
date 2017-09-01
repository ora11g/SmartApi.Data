using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.Practices.Unity;
using Xx.His.Contract.Service;
using Xx.His.Utils;
using Xx.His.Service;
using Xx.His.Domain;

namespace UnitTestProject
{
    public class TestBase
    {
        private const string ConnectionString = "HIS";
        protected readonly static IUnityContainer container = BootStrapper.BuildContainer(ConnectionString);

        static TestBase()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}