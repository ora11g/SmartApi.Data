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
    public interface ISmartBedService : IServiceBase
    {
        #region 根据入住号获取长者医嘱信息
        [OperationContract]
        [Description("根据入住号获取长者临嘱信息")]
        [WebGet(UriTemplate = "/GetSosByPatientNo/{lastlyUpdateTime}/{patientNo}", ResponseFormat = WebMessageFormat.Json)]
        Response<List<BusAdviceDTO>> GetSosByPatientNo(string lastlyUpdateTime, string patientNo);

        [OperationContract]
        [Description("根据入住号获取长者长嘱信息")]
        [WebGet(UriTemplate = "/GetPrnByPatientNo/{lastlyUpdateTime}/{patientNo}", ResponseFormat = WebMessageFormat.Json)]
        Response<List<BusAdviceDTO>> GetPrnByPatientNo(string lastlyUpdateTime, string patientNo);
        #endregion

        #region 获取养老院部门信息
        [OperationContract]
        [Description("获取养老院所有部门信息")]
        [WebGet(UriTemplate = "/GetAllDepartments/{lastlyUpdateTime}", ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(ServiceFault))]
        Response<List<SysDepartmentDTO>> GetAllDepartments(string lastlyUpdateTime);

        [OperationContract]
        [Description("根据部门标识获取部门信息")]
        [WebGet(UriTemplate = "/GetDepartmentByID/{lastlyUpdateTime}/{departmentID}", ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(ServiceFault))]
        Response<SysDepartmentDTO> GetDepartmentByID(string lastlyUpdateTime, string departmentID);
        #endregion

        #region 获取养老院员工信息
        [OperationContract]
        [WebGet(UriTemplate = "/GetAllStaff/{lastlyUpdateTime}", ResponseFormat = WebMessageFormat.Json)]
        [Description("获取养老院所有在职员工信息")]
        Response<List<SysStaffDTO>> GetAllStaff(string lastlyUpdateTime);

        [OperationContract]
        [Description("根据员工标识获取养老院在职员工信息")]
        [WebGet(UriTemplate = "/GetStaffByID/{lastlyUpdateTime}/{staffID}", ResponseFormat = WebMessageFormat.Json)]
        Response<SysStaffDTO> GetStaffByID(string lastlyUpdateTime, string staffID);
        #endregion

        #region 获取体征三测单信息
        [OperationContract]
        [Description("根据入住号获取长者体征三测单信息")]
        [WebGet(UriTemplate = "/GetVitalSignsByPatientNo/{lastlyUpdateTime}/{patientNo}", ResponseFormat = WebMessageFormat.Json)]
        Response<List<BusSignDataDTO>> GetVitalSignsByPatientNo(string lastlyUpdateTime, string patientNo);
        #endregion

        #region 获取养老院入住长者信息
        [OperationContract]
        [Description("获取养老院所有当前入住长者信息")]
        [WebGet(UriTemplate = "/GetAllPatientInfos/{lastlyUpdateTime}", ResponseFormat = WebMessageFormat.Json)]
        Response<List<BusPatientInfoDTO>> GetAllPatientInfos(string lastlyUpdateTime);

        [OperationContract]
        [Description("根据入住号获取养老院长者信息")]
        [WebGet(UriTemplate = "/GetPatientInfoByPatientNo/{lastlyUpdateTime}/{patientNo}", ResponseFormat = WebMessageFormat.Json)]
        Response<BusPatientInfoDTO> GetPatientInfoByPatientNo(string lastlyUpdateTime, string patientNo);
        #endregion
    }    
}