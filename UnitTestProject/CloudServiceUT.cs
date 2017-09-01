using System;
using Microsoft.Practices.Unity;
using SmartBed.Contract.Message;
using SmartBed.Contract.Service;
using SmartBed.Service;
using Xx.His.Contract.Service;
using Xunit;
using Xx.His.Contract.Message;
using System.Data.Entity.Validation;

namespace UnitTestProject
{
    public class CloudServiceUT : TestBase
    {
        public static ICloudService cloudService = container.Resolve<ICloudService>();
        private const int patientID = 1156;

        #region 获取长者信息       
        [Fact]
        [Trait("CloudServiceUT", "根据标识号获取患者信息")]
        public void GetPatientByID_OK()
        {
            GetPatientByID(patientID);
        }
        #endregion

        #region 新增长者信息
        [Fact]
        [Trait("CloudServiceUT", "新增长者信息")]
        public void AddNewPatient_OK()
        {
            var patientDTO = GetPatientByID(patientID);
            patientDTO.Name = "XYHIS";
            patientDTO.ID = 0;
            
            try
            {
                var response = cloudService.AddNewPatient(patientDTO);
                Assert.True(response.Header.Status == ResponseStatus.OK);
                Assert.NotNull(response.Body.Result);
                Assert.NotEqual(0, response.Body.Result.ID);
            }
            catch (Exception ex)
            {
                DbEntityValidationException error = ex as DbEntityValidationException;
            }            
        }
        #endregion   

        private CPatientDTO GetPatientByID(int patientID)
        {           
            var response = cloudService.GetPatientByID(patientID.ToString());

            Assert.True(response.Header.Status == ResponseStatus.OK);
            Assert.NotNull(response.Body.Result);

            return response.Body.Result;
        }
    }
}
