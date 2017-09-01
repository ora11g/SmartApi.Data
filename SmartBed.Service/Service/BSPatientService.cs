using System;
using SmartBed.Contract.Message;
using SmartBed.Domain;
using SmartBed.Contract.Service;
using Xx.His.Service;
using System.ServiceModel;

namespace SmartBed.Service
{
    [GlobalExceptionHandlerBehaviourAttribute(typeof(GlobalExceptionHandler))]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BSPatientService : AbstractService<BsPatient, CPatientDTO>, IBSPatientService
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<BsPatient, CPatientDTO>()
                .ReverseMap();
        }
    }
}
