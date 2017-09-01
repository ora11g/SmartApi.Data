using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartBed.Contract.Message
{
    [Serializable]
    [DataContract]
    public enum MaritalStatus
    {
        [EnumMember] 儿童 = 1,
        [EnumMember] 未婚 = 2,
        [EnumMember] 初婚 = 3,
        [EnumMember] 再婚 = 4,
        [EnumMember] 离异 = 5,        
        [EnumMember] 丧偶 = 6,
        [EnumMember] 其他 = 7,
    }
}
