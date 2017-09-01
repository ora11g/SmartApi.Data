using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUnitTestProject
{

    public class GetStaffByIDResponse
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public Sysstaff SysStaff { get; set; }
    }

    public class Sysstaff
    {
        public int ID { get; set; }
        public string StaffNo { get; set; }
        public string DeptID { get; set; }
        public string StaffName { get; set; }
        public object Sex { get; set; }
        public string Profession { get; set; }
        public string RoleID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Station { get; set; }
        public object Stature { get; set; }
        public object NursingHeight { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastlyUpdateTime { get; set; }
    }

}
