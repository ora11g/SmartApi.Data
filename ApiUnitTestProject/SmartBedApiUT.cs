using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Xx.His.Client;
using SmartBed.Contract.Service;
using Xx.His.Contract.Message;
using SmartBed.Contract.Message;

namespace ApiUnitTestProject
{
    public class SmartBedApiUT : TestBase
    {
        public const string Valid_PatientNo = "2012.0192";
        public const string Invalid_PatientNo = "xxxx.yyyy";
        public const string Valid_DepartmentId = "1522";
        public const string Invalid_DepartmentId = "8888";
        public const string Valid_StaffId = "6775";
        public const string Invalid_StaffId = "8888";
        public string lastlyUpdateTime = DateTime.Now.AddMonths(-5).ToString("yyyy-MM-dd HH:mm:ss");

        [Fact]
        [Trait("SmartBedApiUT", "获取长者医嘱信息")]
        public void GetAdviceByPatientNo_OK()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetSosByPatientNo(lastlyUpdateTime, Valid_PatientNo));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.NotEmpty(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取长者医嘱信息")]
        public void GetAdviceByPatientNo_OK_Empty()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetSosByPatientNo(lastlyUpdateTime, Invalid_PatientNo));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.Empty(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取养老院部门信息")]
        public void GetAllDepartments_OK()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetAllDepartments(lastlyUpdateTime));
            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.NotEmpty(response.Body.Result);
        }

        [Fact(Skip = "ApiHandler")]
        [Trait("SmartBedApiUT", "获取养老院部门信息")]
        public void SmartBedService_GetAllDepartments_OK()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetDepartmentByID(lastlyUpdateTime, Valid_DepartmentId));
            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body);
            Assert.True(response.Body.Result.ID.ToString() == Valid_DepartmentId);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取养老院部门信息")]
        public void GetDepartmentByID_OK()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetDepartmentByID(lastlyUpdateTime, Valid_DepartmentId));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.True(response.Body.Result.ID.ToString() == Valid_DepartmentId);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取养老院部门信息")]
        public void GetDepartmentByID_OK_Null()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetDepartmentByID(lastlyUpdateTime, Invalid_DepartmentId));
            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.Null(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取养老院员工信息")]
        public void GetAllStaff_OK()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetAllStaff(lastlyUpdateTime));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.NotEmpty(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取养老院员工信息")]
        public void GetStaffByID_OK()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetStaffByID(lastlyUpdateTime, Valid_StaffId));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.Equal(Valid_StaffId, response.Body.Result.ID.ToString());
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取养老院员工信息")]
        public void GetStaffByID_OK_Null()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetStaffByID(lastlyUpdateTime, Invalid_StaffId));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.Null(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取长者体征三测单信息")]
        public void GetSignDataByPatientNo_OK()
        {
            string patientNo = "2012.0031";
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetVitalSignsByPatientNo(lastlyUpdateTime, patientNo));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.NotEmpty(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取长者体征三测单信息")]
        public void GetSignDataByPatientNo_OK_Empty()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetVitalSignsByPatientNo(lastlyUpdateTime, Invalid_PatientNo));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.Empty(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取长者信息")]
        public void GetAllPatientInfos_OK()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetAllPatientInfos(lastlyUpdateTime));

            Assert.True(response.Header.Status == ResponseStatus.OK);
            
            Assert.NotNull(response.Body.Result);
            Assert.NotEmpty(response.Body.Result);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取长者信息")]
        public void GetPatientInfoByNo_OK()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetPatientInfoByPatientNo(lastlyUpdateTime, Valid_PatientNo));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.NotNull(response.Body.Result);
            Assert.Equal(Valid_PatientNo, response.Body.Result.PatientNo);
        }

        [Fact]
        [Trait("SmartBedApiUT", "获取长者信息")]
        public void GetPatientInfoByNo_OK_Null()
        {
            var response = ApiHandler.CallService((ISmartBedService x) => x.GetPatientInfoByPatientNo(lastlyUpdateTime, Invalid_PatientNo));

            Assert.True(response.Header.Status == ResponseStatus.OK);

            Assert.Null(response.Body.Result);
        }       
    }
}
