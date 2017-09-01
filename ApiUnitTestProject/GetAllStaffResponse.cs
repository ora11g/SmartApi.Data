using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ApiUnitTestProject
{
    public class GetAllStaffResponse
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public Sysstaff[] SysStaffs { get; set; }
    }



    public class GetDepartmentByIDResponse
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public Department Department { get; set; }
    }

    public class Department
    {
        public int ID { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastlyUpdateTime { get; set; }
    }
}
