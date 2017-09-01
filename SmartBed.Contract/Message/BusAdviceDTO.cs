using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Xx.His.Contract.Message;
using System.ServiceModel;

namespace SmartBed.Contract.Message
{
    [Serializable]
    [DataContract]
    public class BusAdviceDTO : DtoBase
    {
        [DataMember(Order = 1)]
        [MessageBodyMember(Order = 1)]
        public string PatientNo { get; set; }

        [DataMember(Order = 2)]
        [MessageBodyMember(Order = 2)]
        public DateTime BeginTime { get; set; }

        [DataMember(Order=3)]
        [MessageBodyMember(Order = 3)]
        public int BeginDoctorID { get; set; }

        [DataMember(Order=4)]
        [MessageBodyMember(Order = 4)]
        public string BeginDoctor { get; set; }

        [DataMember(Order=5)]
        [MessageBodyMember(Order = 5)]
        public DateTime? EndTime { get; set; }

        [DataMember(Order = 6)]
        [MessageBodyMember(Order = 6)]
        public int? EndDoctorID { get; set; }

        [DataMember(Order = 7)]
        [MessageBodyMember(Order = 7)]
        public string EndDoctor { get; set; }

        [DataMember(Order = 8)]
        [MessageBodyMember(Order =8)]
        public string AdviceContent { get; set; }

        [DataMember(Order = 9)]
        [MessageBodyMember(Order = 9)]
        public string Dosage { get; set; }

        [DataMember(Order = 10)]
        [MessageBodyMember(Order = 10)]
        public string Total { get; set; }

        [DataMember(Order = 11)]
        [MessageBodyMember(Order = 11)]
        public string Usage { get; set; }

        [DataMember(Order = 12)]
        [MessageBodyMember(Order = 12)]
        public string Frequency { get; set; }

        [DataMember(Order = 13)]
        [MessageBodyMember(Order = 13)]
        public bool? IsExecuted { get; set; }

        [DataMember(Order = 14)]
        [MessageBodyMember(Order = 14)]
        public int? SignNurseID { get; set; }

        [DataMember(Order = 15)]
        [MessageBodyMember(Order = 15)]
        public string SignNurse { get; set; }

        [DataMember(Order = 16)]
        [MessageBodyMember(Order = 16)]
        public bool IsExtended { get; set; }

        [DataMember(Order = 17)]
        [MessageBodyMember(Order = 17)]
        public DateTime LastlyUpdateTime { get; set; }
    }
}
