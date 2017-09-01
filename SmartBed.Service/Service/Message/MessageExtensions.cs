using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBed.Contract.Message;

namespace SmartBed.Service.Message
{
    public static class MessageExtensions
    {
        public static IEnumerable<BusPatientInfoDTO> Convert2DTO(this IEnumerable<PatientMessage> patientMessageQueryable)
        {
            var result = patientMessageQueryable.Select(x => new BusPatientInfoDTO
            {
                ID = x.InHosInfo.Id,
                PatientNo = x.InHosInfo.InPatNo,
                PatientName = x.InHosInfo.Name,
                Sex = x.InHosInfo.Sex,
                Birthday = x.Patient.BirthDate,

                //TODO: ************************************
                DepartmentID = string.Empty,
                Department = string.Empty,

                BedNo = string.Empty,
                OutPatientDocID = string.Empty,
                OutPatientDoc = string.Empty,
                DoctorID = string.Empty,
                DoctorName = string.Empty,
                PNurseID = string.Empty,
                PNurseName = string.Empty,
                NurseID = string.Empty,
                NurseName = string.Empty,
                CostType = string.Empty,
                SecurityNo = x.InHosInfo.YbRegNo,
                MedicalType = string.Empty,
                CareLevel = (x.NursingGrade == null) ? string.Empty : x.NursingGrade.Name,
                DietaryGrade = (x.MealType == null) ? string.Empty : x.MealType.Name,
                InDiagnosis = string.Empty,

                MaritalStatus = (x.InHosInfo.LsMarriage == null) ? MaritalStatus.其他.ToString() : GetMaritalStatus(x.InHosInfo.LsMarriage),

                Homeplace = string.Empty,
                Volk = (x.Nation == null) ? string.Empty : x.Nation.Name,
                Nationality = (x.Country == null) ? string.Empty : x.Country.Name,
                ////TODO: ************************************

                PhoneNo = x.Patient.Mobile,
                Address = x.Patient.HouseholdRegisterAddress,
                DeptName = x.Patient.Company,
                Work = x.Patient.Occupation,
                FamilyName = string.Join(",", x.InHosInfo.FirstLinkmanName, x.InHosInfo.SecondLinkmanName),
                FamilyRelationship = GetFamilyReleationShip(x),
                FamilyPhoneNo = string.Join(",", x.InHosInfo.FirstLinkmanPhone, x.InHosInfo.SecondLinkmanPhone),
                FamilyAddress = string.Join(",", x.InHosInfo.FirstLinkmanFamilyAddress, x.InHosInfo.SecondLinkmanFamilyAddress),
                FamilyDeptName = string.Join(",", x.InHosInfo.FirstLinkManWorkUnit, x.InHosInfo.SecondLinkManWorkUnit),

                FamilyWork = null,
                Stature = null,
                NurseOnDutyID = null,
                EnterDate = x.InHosInfo.InTime,
                DischargeTime = x.InHosInfo.OutTime
            });

            return result;
        }       

        private static string GetFamilyReleationShip(PatientMessage patientMessage)
        {
            var relationShip = string.Empty;

            if (patientMessage.TheSecondRelation == null)
            {
                if (patientMessage.TheFirstRelation != null)
                {
                    relationShip = patientMessage.TheFirstRelation.Name;
                }
            }
            else
            {
                if (patientMessage.TheFirstRelation != null)
                {
                    relationShip = string.Join(",", patientMessage.TheFirstRelation.Name, patientMessage.TheSecondRelation.Name);
                }

                relationShip = patientMessage.TheSecondRelation.Name;
            }

            return relationShip;
        }

        public static IEnumerable<SysStaffDTO> Convert2DTO(this IEnumerable<StaffMessage> staffMessageQueryable) 
        {
            var result = staffMessageQueryable.GroupBy(x => x.User)
                .Select(x => new SysStaffDTO()
                {
                    ID = x.Key.Id,
                    StaffNo = x.Key.Code,
                    DeptID = string.Join(",", x.Select(y => (y.Role == null ? string.Empty : y.Role.Name)).ToArray().Distinct()),
                    StaffName = x.Key.Name,
                    Sex = null,
                    Profession = string.Join(",", x.Select(y => (y.Profession == null ? string.Empty : y.Profession.Name)).ToArray().Distinct()),
                    RoleID = string.Join(",", x.Select(y => (y.Department == null ? string.Empty : y.Department.Name)).ToArray().Distinct()),
                    UserName = x.Key.Name,
                    Password = x.Key.Password,
                    Station = string.Join(",", x.Select(y => (y.Station == null ? string.Empty : y.Station.Name)).ToArray().Distinct()),
                    Stature = null,
                    NursingHeight = null,
                    IsDelete = !x.Key.IsActive,
                    LastlyUpdateTime = x.Key.LastlyUpdateTime
                });

            return result;
        }

        public static IEnumerable<BusAdviceDTO> Convert2DTO(this IEnumerable<AdviceMessage> tempAdviceMessageQueryable)
        {
            var result = tempAdviceMessageQueryable
                .Select(x => new BusAdviceDTO()
                {
                    ID = x.TempAdvice.Id,
                    PatientNo = x.Patient.InPatNo,
                    BeginTime = x.TempAdvice.AdviceTime.Value,
                    BeginDoctorID = x.TempAdvice.DoctorId,
                    BeginDoctor = (x.CancellationDoctor == null) ? string.Empty : x.CancellationDoctor.Name,
                    EndTime = x.TempAdvice.CancelOperTime,
                    EndDoctorID = x.TempAdvice.CancelOperId,
                    EndDoctor = (x.CancellationDoctor == null) ? string.Empty : x.CancellationDoctor.Name,

                    //TODO: dragon luo
                    AdviceContent = string.Empty,

                    Dosage = string.Format("{0} {1}", Convert.ToString(x.TempAdvice.Dosage), x.UnitOfSingle.Name),
                    Total = string.Format("{0} {1}", Convert.ToString(x.TempAdvice.Totality), x.UnitOfTotality.Name),

                    Usage = (x.Usage == null) ? string.Empty : x.Usage.Name,
                    Frequency = (x.Frequency == null) ? string.Empty : x.Frequency.PrintName,
                    IsExecuted = (x.Execution == null) ? false : x.Execution.IsExecuted,
                    SignNurseID = (x.Execution == null) ? null : x.Execution.ExecutedOperId,
                    SignNurse = (x.SignatureNurse == null) ? null : x.SignatureNurse.Name,
                    IsExtended = false,
                    LastlyUpdateTime = x.TempAdvice.IsCancel ? x.TempAdvice.CancelOperTime.Value : 
                    (x.TempAdvice.IsAuth ? x.TempAdvice.AuthOperTime.Value : x.TempAdvice.AdviceTime.Value)
                });

            return result;
        }

        public static IEnumerable<BusSignDataDTO> Convert2DTO(this IEnumerable<VitalSignsMessage> vitalSignsMessageQueryable)
        {
            var result = vitalSignsMessageQueryable.Select(x => new BusSignDataDTO()
                {
                    ID = x.VitalSigns.Id,
                    PatientNo = x.Patient.InPatNo,

                    SDate = (x.VitalSigns.RecordTime == null) ? string.Empty : x.VitalSigns.RecordTime.Value.ToShortDateString(),
                    STime = (x.VitalSigns.RecordTime == null) ? string.Empty : x.VitalSigns.RecordTime.Value.ToShortTimeString(),

                    OperationExplain = string.Empty,

                    HospitalizedTimeAxis = (x.VitalSigns.RecordTime == null || x.HosInfo.OutTime == null) ? string.Empty : DateTime.Compare(x.VitalSigns.RecordTime.Value, x.HosInfo.OutTime.Value).ToString(),

                    Temperature = x.VitalSigns.AnimalHeat,
                    TemperatureKind = x.VitalSigns.HeatType,
                    Pulse = x.VitalSigns.Pulse,
                    HeartRate = x.VitalSigns.Heart,
                    TemperatureAfterHandle = null,
                    Breathe = x.VitalSigns.Breath,
                    ShitTime = x.VitalSigns.Stool,
                    PeeTime = x.VitalSigns.Urine,
                    BloodPressureDown = x.VitalSigns.Bldpress1,
                    BloodPressureUp = x.VitalSigns.Bldpress0,
                    Weight = x.VitalSigns.Weight,
                    OtherOutput = x.VitalSigns.OtherM,
                    DrugTest = x.VitalSigns.SpinTest,
                    InducedFlow = x.VitalSigns.FluidM,
                    TotalInput = x.VitalSigns.TotalIn,
                    TotalOutput = x.VitalSigns.TotalOut,

                    //TODO: ********************************************
                    CircumferenceOfAbdomen = null,
                    UPD = x.VitalSigns.UrineM,
                    Remark = null,
                    Remark2 = null,
                    Other1 = null,
                    Other2 = null,
                    Other3 = null,
                    //TODO: ********************************************

                    CreateTime = x.VitalSigns.OperTime,
                    CreateUserID = (x.Operator == null) ? string.Empty : x.Operator.Name,
                    LastlyUpdateTime = x.VitalSigns.LastlyUpdateTime
                });

            return result;
        }

        private static string GetMaritalStatus(short? maritalStatus)
        {
            int _maritalStatus = (int)MaritalStatus.其他;

            if (maritalStatus.HasValue)
            {
                _maritalStatus = maritalStatus.Value;
            }

            return ((MaritalStatus)_maritalStatus).ToString();
        } 
    }
}
