using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUnitTestProject
{
    public class GetDepartmentByIDResponse
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
    }

    public class Header
    {
        public Xx.His.Contract.Message.ResponseStatus Status { get; set; }
        public object[] Errors { get; set; }
    }

    public class Body
    {
        public Result Result { get; set; }
    }

    public class Result
    {
        public int ID { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastlyUpdateTime { get; set; }
    }

}
