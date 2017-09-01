using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBed.Domain;

namespace SmartBed.Service.Message
{
    public class StaffMessage
    {
        public BsUser User { get; set; }

        public GblRole Role { get; set; }

        public BsLocation Department { get; set; }

        public BsDocLevel Profession { get; set; }

        public BsUserLevel Station { get; set; }
    }
}
