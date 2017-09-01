using System;
using Microsoft.Practices.Unity;
using SmartBed.Contract.Message;
using SmartBed.Contract.Service;
using SmartBed.Service;
using Xx.His.Contract.Service;
using Xunit;
using Xx.His.Contract.Message;

namespace UnitTestProject
{
    public class SmartBedServiceUT : TestBase
    {
        public static ISmartBedService smartbedService = container.Resolve<ISmartBedService>();
        public const string Valid_PatientNo = "2012.0434";
        public const string Invalid_PatientNo = "xxxx.yyyy";
        public const string Valid_DepartmentId = "1522";
        public const string Invalid_DepartmentId = "8888";
        public const string Valid_StaffId = "6775";
        public const string Invalid_StaffId = "8888";
        public string lastlyUpdateTime = DateTime.Now.AddMonths(-5).ToString("yyyy-MM-dd HH:mm:ss");

        #region 获取长者临嘱信息
        [Fact]
        [Trait("SmartBedServiceUT", "获取长者临嘱信息")]
        public void GetTempAdviceByPatientNo_Null_Error()
        {
            Assert.Throws<ArgumentException>(() => smartbedService.GetSosByPatientNo(lastlyUpdateTime, null));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者临嘱信息")]
        public void GetTempAdviceByPatientNo_Empty_Error()
        {
            Assert.Throws<ArgumentException>(() => smartbedService.GetSosByPatientNo(lastlyUpdateTime, string.Empty));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者临嘱信息")]
        public void GetSosByPatientNo_OK()
        {
            var response = smartbedService.GetSosByPatientNo(lastlyUpdateTime, Valid_PatientNo);
            
            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.NotNull(response.Body.Result);
            Assert.NotEmpty(response.Body.Result);
        }
        
        [Fact]
        [Trait("SmartBedServiceUT", "获取长者临嘱信息")]
        public void GetSosByPatientNo_OK_Empty()
        {
            var response = smartbedService.GetSosByPatientNo(lastlyUpdateTime, Invalid_PatientNo);

            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.NotNull(response.Body.Result);
            Assert.Empty(response.Body.Result);
        }
        #endregion

        #region 获取长者长嘱信息
        [Fact]
        [Trait("SmartBedServiceUT", "获取长者长嘱信息")]
        public void GetLongAdviceByPatientNo_Null_Error()
        {
            Assert.Throws<ArgumentException>(() => smartbedService.GetPrnByPatientNo(lastlyUpdateTime, null));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者长嘱信息")]
        public void GetLongAdviceByPatientNo_Empty_Error()
        {
            Assert.Throws<ArgumentException>(() => smartbedService.GetPrnByPatientNo(lastlyUpdateTime, string.Empty));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者长嘱信息")]
        public void GetLongAdviceByPatientNo_OK()
        {
            var response = smartbedService.GetPrnByPatientNo(lastlyUpdateTime, Valid_PatientNo);
            
            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.NotNull(response.Body.Result);            
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者长嘱信息")]
        public void GetPrnByPatientNo_OK_Empty()
        {
            var response = smartbedService.GetPrnByPatientNo(lastlyUpdateTime, Invalid_PatientNo);

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.Empty(response.Body.Result);
        }
        #endregion

        #region 获取养老院部门信息
        [Fact]
        [Trait("SmartBedServiceUT", "获取养老院部门信息")]
        public void GetDepartmentByID_Error()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => smartbedService.GetDepartmentByID(lastlyUpdateTime, "-1000"));
        }   

        [Fact]
        [Trait("SmartBedServiceUT", "获取养老院部门信息")]
        public void GetAllDepartments_OK()
        {
            var response = smartbedService.GetAllDepartments(lastlyUpdateTime);
            
            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.NotEmpty(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取养老院部门信息")]
        public void GetDepartmentByID_OK()
        {
            var response = smartbedService.GetDepartmentByID(lastlyUpdateTime, Valid_DepartmentId);

            Assert.True(response.Header.Status == ResponseStatus.OK);
            
            Assert.NotNull(response.Body.Result);
            Assert.True(response.Body.Result.ID.ToString() == Valid_DepartmentId);
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取养老院部门信息")]
        public void GetDepartmentByID_OK_Null()
        {
            var response = smartbedService.GetDepartmentByID(lastlyUpdateTime, Invalid_DepartmentId);

            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.Null(response.Body.Result);
        }
        #endregion

        #region 获取养老院员工信息
        [Fact]
        [Trait("SmartBedServiceUT", "获取养老院员工信息")]
        public void GetStaffByID_Error()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => smartbedService.GetStaffByID(lastlyUpdateTime, "-1000"));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取养老院员工信息")]
        public void GetAllStaff_OK()
        {
            var response = smartbedService.GetAllStaff(lastlyUpdateTime);
            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.NotEmpty(response.Body.Result);
        }        

        [Fact]
        [Trait("SmartBedServiceUT", "获取养老院员工信息")]
        public void GetStaffByID_OK()
        {
            var response = smartbedService.GetStaffByID(lastlyUpdateTime, Valid_StaffId);

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.Equal(Valid_StaffId, response.Body.Result.ID.ToString());
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取养老院员工信息")]
        public void GetStaffByID_OK_Null()
        {
            var response = smartbedService.GetStaffByID(lastlyUpdateTime, Invalid_StaffId);
            
            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.Null(response.Body.Result);            
        }
        #endregion

        #region 获取长者体征三测单信息
        [Fact]
        [Trait("SmartBedServiceUT", "获取长者体征三测单信息")]
        public void GetSignDataByPatientNo_Null_Error()
        {            
            Assert.Throws<ArgumentException>(() => smartbedService.GetVitalSignsByPatientNo(lastlyUpdateTime, null));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者体征三测单信息")]
        public void GetSignDataByPatientNo_Empty_Error()
        {
            Assert.Throws<ArgumentException>(() => smartbedService.GetVitalSignsByPatientNo(lastlyUpdateTime, string.Empty));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者体征三测单信息")]
        public void GetSignDataByPatientNo_OK()
        {
            string patientNo = "2012.0031";
            var response = smartbedService.GetVitalSignsByPatientNo(lastlyUpdateTime, patientNo);
            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.NotNull(response.Body.Result);            
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者体征三测单信息")]
        public void GetSignDataByPatientNo_OK_Empty()
        {
            var response = smartbedService.GetVitalSignsByPatientNo(lastlyUpdateTime, Invalid_PatientNo);

            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.NotNull(response.Body.Result);
            Assert.Empty(response.Body.Result);
        }
        #endregion

        #region 获取长者信息
        [Fact]
        [Trait("SmartBedServiceUT", "获取长者信息")]
        public void GetAllPatientInfos_OK()
        {
            var response = smartbedService.GetAllPatientInfos(lastlyUpdateTime);

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);            
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者信息")]
        public void GetPatientByNo_Null_Error()
        {
            Assert.Throws<ArgumentException>(() => smartbedService.GetPatientInfoByPatientNo(lastlyUpdateTime, null));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者信息")]
        public void GetPatientByNo_Empty_Error()
        {
            Assert.Throws<ArgumentException>(() => smartbedService.GetPatientInfoByPatientNo(lastlyUpdateTime, string.Empty));
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者信息")]
        public void GetPatientByNo_OK()
        {
            var response = smartbedService.GetPatientInfoByPatientNo(lastlyUpdateTime, Valid_PatientNo);

            Assert.NotNull(response.Body.Result);

            Assert.Equal(Valid_PatientNo, response.Body.Result.PatientNo);
        }

        [Fact]
        [Trait("SmartBedServiceUT", "获取长者信息")]
        public void GetPatientInfoByNo_OK_Null()
        {
            var response = smartbedService.GetPatientInfoByPatientNo(lastlyUpdateTime, Invalid_PatientNo);
            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.Null(response.Body.Result);
        }
        #endregion

    }
}
