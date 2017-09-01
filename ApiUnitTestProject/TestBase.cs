using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using Xunit;
using Serialize.Linq.Extensions;
using Xx.His.Client;
using Xx.His.Contract.Message;

namespace ApiUnitTestProject
{
    public class TestBase : IDisposable
    {
        protected const string OrdererAssemblyName = "Xx.His.Service.UnitTests";
        protected const string OrdererTypeName = "PriorityOrderer";
        //private const string ServiceHost = "120.24.214.43";
        private const string ServiceHost = "localhost";

        private const int Port = 8089;       

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected bool disposed = false;

        public TestBase()
        {
            ProxyManager.ServiceHost = ServiceHost;
            ProxyManager.Port = Port;        
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
            }

            this.disposed = true;
        }
    }
}
