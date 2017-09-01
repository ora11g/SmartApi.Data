using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xx.His.Contract.Message;
using System.ServiceModel;

namespace SmartBed.Contract.Message
{    
    [Serializable]
    [DataContract]
    public partial class SysDepartmentDTO : DtoBase
    {
        [DataMember(Order = 1)]
        [MessageBodyMember(Order = 1)]
        public string DeptCode { get; set; }

        [DataMember(Order = 2)]
        [MessageBodyMember(Order = 2)]
        public string DeptName { get; set; }

        [DataMember(Order = 3)]
        [MessageBodyMember(Order = 3)]
        public bool IsDelete { get; set; }

        [DataMember(Order = 4)]
        [MessageBodyMember(Order = 4)]
        public DateTime LastlyUpdateTime { get; set; }
    }
}
