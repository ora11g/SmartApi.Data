using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using  Xx.His.Contract.Message;
using System.ServiceModel;

namespace SmartBed.Contract.Message
{
    [Serializable]
    [DataContract]
    public class BusPatientInfoDTO : DtoBase
    {
        [DataMember(Order = 1)]
        [MessageBodyMember(Order = 1)]
        public string PatientNo { get; set; }

        [DataMember(Order = 2)]
        [MessageBodyMember(Order = 2)]
        public string PatientName { get; set; }

        [DataMember(Order = 3)]
        [MessageBodyMember(Order = 3)]
        public string Sex { get; set; }

        [DataMember(Order = 4)]
        [MessageBodyMember(Order = 4)]
        public DateTime? Birthday { get; set; }

        [DataMember(Order = 5)]
        [MessageBodyMember(Order = 5)]
        public string DepartmentID { get; set; }

        [DataMember(Order = 6)]
        [MessageBodyMember(Order = 6)]
        public string Department { get; set; }

        [DataMember(Order = 7)]
        [MessageBodyMember(Order = 7)]
        public string BedNo { get; set; }

        [DataMember(Order = 8)]
        [MessageBodyMember(Order = 8)]
        public string OutPatientDocID { get; set; }

        [DataMember(Order = 9)]
        [MessageBodyMember(Order = 9)]
        public string OutPatientDoc { get; set; }

        [DataMember(Order = 10)]
        [MessageBodyMember(Order = 10)]
        public string DoctorID { get; set; }

        [DataMember(Order = 11)]
        [MessageBodyMember(Order = 11)]
        public string DoctorName { get; set; }

        [DataMember(Order = 12)]
        [MessageBodyMember(Order = 12)]
        public string PNurseID { get; set; }

        [DataMember(Order = 13)]
        [MessageBodyMember(Order = 13)]
        public string PNurseName { get; set; }

        [DataMember(Order = 14)]
        [MessageBodyMember(Order = 14)]
        public string NurseID { get; set; }

        [DataMember(Order = 15)]
        [MessageBodyMember(Order = 15)]
        public string NurseName { get; set; }

        [DataMember(Order = 16)]
        [MessageBodyMember(Order = 16)]
        public string CostType { get; set; }

        [DataMember(Order = 17)]
        [MessageBodyMember(Order = 17)]
        public string SecurityNo { get; set; }

        [DataMember(Order = 18)]
        [MessageBodyMember(Order = 18)]
        public string MedicalType { get; set; }

        [DataMember(Order = 19)]
        [MessageBodyMember(Order = 19)]
        public string CareLevel { get; set; }

        [DataMember(Order = 20)]
        [MessageBodyMember(Order = 20)]
        public string DietaryGrade { get; set; }

        [DataMember(Order = 21)]
        [MessageBodyMember(Order = 21)]
        public string InDiagnosis { get; set; }

        [DataMember(Order = 22)]
        [MessageBodyMember(Order = 22)]
        public string MaritalStatus { get; set; }

        [DataMember(Order = 23)]
        [MessageBodyMember(Order = 23)]
        public string Homeplace { get; set; }

        [DataMember(Order = 24)]
        [MessageBodyMember(Order = 24)]
        public string Volk { get; set; }

        [DataMember(Order = 25)]
        [MessageBodyMember(Order = 25)]
        public string Nationality { get; set; }

        [DataMember(Order = 26)]
        [MessageBodyMember(Order = 26)]
        public string PhoneNo { get; set; }

        [DataMember(Order = 27)]
        [MessageBodyMember(Order = 27)]
        public string Address { get; set; }

        [DataMember(Order = 28)]
        [MessageBodyMember(Order = 28)]
        public string DeptName { get; set; }

        [DataMember(Order = 29)]
        [MessageBodyMember(Order = 29)]
        public string Work { get; set; }

        [DataMember(Order = 30)]
        [MessageBodyMember(Order = 30)]
        public string FamilyName { get; set; }

        [DataMember(Order = 31)]
        [MessageBodyMember(Order = 31)]
        public string FamilyRelationship { get; set; }

        [DataMember(Order = 32)]
        [MessageBodyMember(Order = 32)]
        public string FamilyPhoneNo { get; set; }

        [DataMember(Order = 33)]
        [MessageBodyMember(Order = 33)]
        public string FamilyAddress { get; set; }

        [DataMember(Order = 34)]
        [MessageBodyMember(Order = 34)]
        public string FamilyDeptName { get; set; }

        [DataMember(Order = 35)]
        [MessageBodyMember(Order = 35)]
        public string FamilyWork { get; set; }

        [DataMember(Order = 36)]
        [MessageBodyMember(Order = 36)]
        public string Stature { get; set; }

        [DataMember(Order = 37)]
        [MessageBodyMember(Order = 37)]
        public string NurseOnDutyID { get; set; }

        [DataMember(Order = 38)]
        [MessageBodyMember(Order = 38)]
        public DateTime? EnterDate { get; set; }

        [DataMember(Order = 39)]
        [MessageBodyMember(Order = 39)]
        public DateTime? DischargeTime { get; set; }

        [DataMember(Order = 40)]
        [MessageBodyMember(Order = 40)]
        public DateTime LastlyUpdateTime { get; set; }
    }
}
