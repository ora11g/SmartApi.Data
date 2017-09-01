using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xx.His.Contract.Message;
using System.ServiceModel;

namespace SmartBed.Contract.Message
{    
    [Serializable]
    [DataContract]
    public partial class SysStaffDTO : DtoBase
    {
        [DataMember(Order = 1)]
        [MessageBodyMember(Order = 1)]
        public string StaffNo { get; set; }

        [DataMember(Order = 2)]
        [MessageBodyMember(Order = 2)]
        public string DeptID { get; set; }

        [DataMember(Order = 3)]
        [MessageBodyMember(Order = 3)]
        public string StaffName { get; set; }

        [DataMember(Order = 4)]
        [MessageBodyMember(Order = 4)]
        public string Sex { get; set; }

        [DataMember(Order = 5)]
        [MessageBodyMember(Order = 5)]
        public string Profession { get; set; }

        [DataMember(Order = 6)]
        [MessageBodyMember(Order = 6)]
        public string RoleID { get; set; }

        [DataMember(Order = 7)]
        [MessageBodyMember(Order = 7)]
        public string UserName { get; set; }

        [DataMember(Order = 8)]
        [MessageBodyMember(Order = 8)]
        public string Password { get; set; }

        [DataMember(Order = 9)]
        [MessageBodyMember(Order = 9)]
        public string Station { get; set; }

        [DataMember(Order = 10)]
        [MessageBodyMember(Order = 10)]
        public int? Stature { get; set; }

        [DataMember(Order = 11)]
        [MessageBodyMember(Order = 11)]
        public int? NursingHeight { get; set; }

        [DataMember(Order = 12)]
        [MessageBodyMember(Order = 12)]
        public bool IsDelete { get; set; }

        [DataMember(Order = 13)]
        [MessageBodyMember(Order = 13)]
        public DateTime LastlyUpdateTime { get; set; }
    }
}
