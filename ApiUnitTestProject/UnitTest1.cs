using System;
using Xunit;
using SmartBed.Contract.Message;
using Xx.His.Contract.Message;
using System.Collections;
using System.Collections.Generic;

namespace ApiUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {             
            string url = "http://localhost:8089/SmartBedService.svc/GetAllStaff/2014-01-01";
            var getAllStaffResponse = Client.DownloadData<Response<List<SysStaffDTO>>>(url);
            Assert.True(getAllStaffResponse.Header.Status == ResponseStatus.OK);

            url = "http://localhost:8089/SmartBedService.svc/GetStaffByID/2014-01-01/6775";
            var getStaffByIDResponse = Client.GetData<Response<SysStaffDTO>>(url);
            Assert.True(getStaffByIDResponse.Header.Status == ResponseStatus.OK);

            url = "http://localhost:8089/SmartBedService.svc/GetAllDepartments/2014-01-01A";
            var getAllDepartmentsResponse = Client.DownloadData<Response<SysDepartmentDTO>>(url);
            Assert.True(getAllDepartmentsResponse.Header.Status == ResponseStatus.OK);

            url = "http://localhost:8089/SmartBedService.svc/GetDepartmentByID/2014-01-01/1516";     
            var getDepartmentByIDResponse = Client.GetData<Response<SysDepartmentDTO>>(url);
            Assert.True(getDepartmentByIDResponse.Header.Status == ResponseStatus.OK);
           
        }
    }
}
