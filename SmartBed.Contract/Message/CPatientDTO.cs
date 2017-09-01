using System;
using System.Collections.Generic;
using Xx.His.Domain;
using System.Runtime.Serialization;
using Xx.His.Contract.Message;

namespace SmartBed.Contract.Message
{
    [Serializable]
    [DataContract]
    public partial class CPatientDTO : DtoBase
    {
        [DataMember(Order = 2)]
        public string CardNo { get; set; }

        [DataMember(Order = 3)]
        public string Name { get; set; }

        [DataMember(Order = 4)]
        public string Sex { get; set; }

        [DataMember(Order = 5)]
        public System.DateTime? BirthDate { get; set; }

        [DataMember(Order = 6)]
        public short? LsMarriage { get; set; }

        [DataMember(Order = 7)]
        public int? NationId { get; set; }

        [DataMember(Order = 8)]
        public int? CountryId { get; set; }

        [DataMember(Order = 9)]
        public int? ProvinceId { get; set; }

        [DataMember(Order = 10)]
        public int? RegionId { get; set; }

        [DataMember(Order = 11)]
        public int? AreaId { get; set; }

        [DataMember(Order = 12)]
        public string Native { get; set; }

        [DataMember(Order = 13)]
        public string Residence { get; set; }

        [DataMember(Order = 14)]
        public string Company { get; set; }

        [DataMember(Order = 15)]
        public string Occupation { get; set; }

        [DataMember(Order = 16)]
        public string Mobile { get; set; }

        [DataMember(Order = 17)]
        public string Email { get; set; }

        [DataMember(Order = 18)]
        public string Phone { get; set; }

        [DataMember(Order = 19)]
        public int? WorktypeId { get; set; }

        [DataMember(Order = 20)]
        public int? PatTypeId { get; set; }

        [DataMember(Order = 21)]
        public int? CertificateId { get; set; }

        [DataMember(Order = 22)]
        public string Sensitive { get; set; }

        [DataMember(Order = 23)]
        public string IdCardNo { get; set; }

        [DataMember(Order = 24)]
        public bool? IsBaby { get; set; }

        [DataMember(Order = 25)]
        public int? MotherPatId { get; set; }

        [DataMember(Order = 26)]
        public string MedicareNo { get; set; }

        [DataMember(Order = 27)]
        public string AccountNo { get; set; }

        [DataMember(Order = 28)]
        public string PhoneWork { get; set; }

        [DataMember(Order = 29)]
        public string AddressWork { get; set; }

        [DataMember(Order = 30)]
        public string PostCodeWork { get; set; }

        [DataMember(Order = 31)]
        public string PhoneHome { get; set; }

        [DataMember(Order = 32)]
        public string AddressHome { get; set; }

        [DataMember(Order = 33)]
        public string LinkmanName { get; set; }

        [DataMember(Order = 34)]
        public int? RelationId { get; set; }

        [DataMember(Order = 35)]
        public string LinkmanAddress { get; set; }

        [DataMember(Order = 36)]
        public string LinkmanPhone { get; set; }

        [DataMember(Order = 37)]
        public int? FamilyId { get; set; }

        [DataMember(Order = 38)]
        public int? LevelId { get; set; }

        [DataMember(Order = 39)]
        public decimal? Height { get; set; }

        [DataMember(Order = 40)]
        public decimal? Weight { get; set; }

        [DataMember(Order = 41)]
        public short? LsBitHabit { get; set; }

        [DataMember(Order = 42)]
        public short? SleepHour { get; set; }

        [DataMember(Order = 43)]
        public short? LsSleepTrouble { get; set; }

        [DataMember(Order = 44)]
        public System.DateTime? OperTime { get; set; }

        [DataMember(Order = 45)]
        public int? OperId { get; set; }

        [DataMember(Order = 46)]
        public bool? IsActive { get; set; }

        [DataMember(Order = 47)]
        public short? IconIndex { get; set; }

        [DataMember(Order = 48)]
        public string PersonHistory { get; set; }

        [DataMember(Order = 100)]
        public int CloudPatientID { get; set; }
	}
}
