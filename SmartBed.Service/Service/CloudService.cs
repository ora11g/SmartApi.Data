using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using SmartBed.Contract.Message;
using SmartBed.Contract.Service;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Xx.His.Core;
using Microsoft.Practices.Unity;
using SmartBed.Domain;
using Serialize.Linq.Nodes;
using System.ServiceModel;
using Xx.His.Service;
using System.ServiceModel.Activation;
using System.Data.Objects.SqlClient;
using SmartBed.Service.Message;
using Xx.His.Contract.Message;

namespace SmartBed.Service
{    
    [GlobalExceptionHandlerBehaviourAttribute(typeof(GlobalExceptionHandler))]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CloudService : Profile, ICloudService
    {
        private bool disposed = false;

        #region Properties
        public virtual ICommandWrapper CommandWrapper
        {
            get { return IoCContainer.Instance.Resolve<ICommandWrapper>(); }
        }

        [Dependency]
        public IBSPatientService patientService { get; set; }
        #endregion

        #region 新增患者信息
        public Response<CPatientDTO> GetPatientByID(string patientID)
        {
            var response = new Response<CPatientDTO>();
            
            response.Body.Result = patientService.Retrieve(int.Parse(patientID));

            return response;
        }

        public Response<CPatientDTO> AddNewPatient(CPatientDTO patientDTO)
        {
            var response = new Response<CPatientDTO>();

            patientService.Create(patientDTO);

            response.Body.Result = patientDTO;

            return response;
        }
        #endregion

        #region 更新患者信息
        public Response<CPatientDTO> UpdatePatient(CPatientDTO patientDTO)
        {
            var response = new Response<CPatientDTO>();

            patientService.Update(patientDTO);

            response.Body.Result = patientDTO;

            return response;
        }
        #endregion

        #region Dispose
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
                    if (CommandWrapper != null)
                    {
                        CommandWrapper.Dispose();
                    }
                }
            }

            this.disposed = true;
        }
        #endregion

    }
}