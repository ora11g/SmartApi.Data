using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SmartBed.Contract.Message;
using Xx.His.Contract.Service;
using System.ServiceModel.Activation;
using System.ComponentModel;
using Xx.His.Contract.Message;

namespace SmartBed.Contract.Service
{
    [ServiceContract]
    public interface ICloudService : IServiceBase
    {
        #region 根据标识号获取患者信息
        [OperationContract, Description("根据标识号获取患者信息")]
        [WebGet(UriTemplate = "/GetPatientByID", ResponseFormat = WebMessageFormat.Json)]
        Response<CPatientDTO> GetPatientByID(string patientID);
        #endregion

        #region 新增患者信息
        [OperationContract, Description("新增患者信息")]        
        [WebInvoke(Method = "POST", UriTemplate = "/AddNewPatient", ResponseFormat = WebMessageFormat.Json)]
        Response<CPatientDTO> AddNewPatient(CPatientDTO patientDTO);
        #endregion

        #region 更新患者信息
        [OperationContract, Description("更新患者信息")]        
        [WebInvoke(Method = "POST", UriTemplate = "/UpdatePatient", ResponseFormat = WebMessageFormat.Json)]
        Response<CPatientDTO> UpdatePatient(CPatientDTO patientDTO);
        #endregion
    }    
}