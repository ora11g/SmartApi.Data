using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xx.His.Contract.Message;

namespace SmartBed.Contract.Message
{    
    [Serializable]
    [DataContract]
    public partial class BusSignDataDTO : DtoBase
    {
        [DataMember]
        public string PatientNo { get; set; }

        [DataMember]
        public DateTime OperTime { get; set; }
        
        [DataMember]
        public string SDate { get; set; }

        [DataMember]
        public string STime { get; set; }

        [DataMember]
        public string OperationExplain { get; set; }

        [DataMember]
        public string HospitalizedTimeAxis { get; set; }
        
        [DataMember]
        public string Temperature { get; set; }
        
        [DataMember]
        public string TemperatureKind { get; set; }

        [DataMember]
        public string Pulse { get; set; }

        [DataMember]
        public string HeartRate { get; set; }
        
        [DataMember]
        public string TemperatureAfterHandle { get; set; }
        
        [DataMember]
        public string Breathe { get; set; }
        
        [DataMember]
        public string ShitTime { get; set; }
        
        [DataMember]
        public string PeeTime { get; set; }
        
        [DataMember]
        public string BloodPressureDown { get; set; }
       
        [DataMember]
        public string BloodPressureUp { get; set; }
        
        [DataMember]
        public string Weight { get; set; }
        
        [DataMember]
        public string OtherOutput { get; set; }
        
        [DataMember]
        public bool DrugTest { get; set; }
        
        [DataMember]
        public string InducedFlow { get; set; }
        
        [DataMember]
        public string TotalInput { get; set; }

        [DataMember]
        public string TotalOutput { get; set; }
       
        [DataMember]
        public string CircumferenceOfAbdomen { get; set; }
      
        [DataMember]
        public string UPD { get; set; }
      
        [DataMember]
        public string Remark { get; set; }
        
        [DataMember]
        public string Remark2 { get; set; }

        [DataMember]
        public string Other1 { get; set; }

        [DataMember]
        public string Other2 { get; set; }
        
        [DataMember]
        public string Other3 { get; set; }
        
        [DataMember]
        public DateTime CreateTime { get; set; }
        
        [DataMember]
        public string CreateUserID { get; set; }
        
        [DataMember]
        public DateTime LastlyUpdateTime { get; set; }                   
    }
}
