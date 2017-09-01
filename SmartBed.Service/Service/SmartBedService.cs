using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using SmartBed.Contract.Message;
using SmartBed.Contract.Service;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Xx.His.Core;
using Microsoft.Practices.Unity;
using SmartBed.Domain;
using Serialize.Linq.Nodes;
using System.ServiceModel;
using Xx.His.Service;
using System.ServiceModel.Activation;
using System.Data.Objects.SqlClient;
using SmartBed.Service.Message;
using Xx.His.Contract.Message;

namespace SmartBed.Service
{    
    [GlobalExceptionHandlerBehaviourAttribute(typeof(GlobalExceptionHandler))]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SmartBedService : Profile, ISmartBedService
    {
        private bool disposed = false;

        #region Properties
        public virtual ICommandWrapper CommandWrapper
        {
            get { return IoCContainer.Instance.Resolve<ICommandWrapper>(); }
        }        
        #endregion

        #region 获取医嘱
        public Response<List<BusAdviceDTO>> GetSosByPatientNo(string lastlyUpdateTime, string patientNo)
        {
            var response = new Response<List<BusAdviceDTO>>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");

            Utils.StringValidation(patientNo, "patientNo");
            #endregion

            Expression<Func<AdviceMessage, bool>> expression = x =>
                        (x.TempAdvice.IsCancel && x.TempAdvice.CancelOperTime.Value > _lastlyUpdateTime)
                        || (x.TempAdvice.IsAuth && x.TempAdvice.AuthOperTime.Value > _lastlyUpdateTime)
                        || (!x.TempAdvice.IsCancel && !x.TempAdvice.IsAuth && x.TempAdvice.AdviceTime > _lastlyUpdateTime)
                        ;

            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow =>
                {
                    var tempAdviceQueryable = BuildTempAdviveQueryable(uow)
                        .Where(x => x.Patient.InPatNo == patientNo)
                        .Where(expression)
                        ;

                    return tempAdviceQueryable.Convert2DTO().ToList();
                });                

                return response;
            }
        }

        public Response<List<BusAdviceDTO>> GetPrnByPatientNo(string lastlyUpdateTime, string patientNo)
        {
            var response = new Response<List<BusAdviceDTO>>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");

            Utils.StringValidation(patientNo, "patientNo");
            #endregion

            Expression<Func<AdviceMessage, bool>> expression = x =>
                       (x.LongAdvice.IsEnd && x.LongAdvice.EndOperTime.Value > _lastlyUpdateTime)
                       || (x.LongAdvice.IsAuth && x.LongAdvice.AuthOperTime.Value > _lastlyUpdateTime)
                       || (!x.LongAdvice.IsEnd && !x.LongAdvice.IsAuth && x.LongAdvice.AdviceTime > _lastlyUpdateTime)
                       ;

            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow =>
                {
                    var longAdviceQueryable = BuildLongAdviveQueryable(uow)
                        .Where(x => x.Patient.InPatNo == patientNo)
                        .Where(expression)
                        ;

                    return longAdviceQueryable.Convert2DTO().ToList();
                });                

                return response;
            }
        }

        private IQueryable<AdviceMessage> BuildTempAdviveQueryable(IUnitOfWork uow)
        {
            IQueryable<AdviceMessage> tempAdviceMessageQueryable =
                from patient in uow.Retrieve<BsPatient>()
                join hosinfo in uow.Retrieve<InHosInfo>() on patient.Id equals hosinfo.PatId
                join tempAdvice in uow.Retrieve<InAdviceTemp>() on hosinfo.Id equals tempAdvice.HospId
                join execution in uow.Retrieve<InExecute>() on tempAdvice.Id equals execution.AdviceId into execution_join
                from execution in execution_join.DefaultIfEmpty()
                join advice_doctor in uow.Retrieve<BsDoctor>() on tempAdvice.DoctorId equals advice_doctor.Id into advice_doctor_join
                from advice_doctor in advice_doctor_join.DefaultIfEmpty()
                join cancellationDoctor in uow.Retrieve<BsDoctor>() on tempAdvice.CancelOperId equals cancellationDoctor.Id into cancellationDoctor_join
                from cancellationDoctor in cancellationDoctor_join.DefaultIfEmpty()
                join usage in uow.Retrieve<BsUsage>() on tempAdvice.UsageId equals usage.Id into usage_join
                from usage in usage_join.DefaultIfEmpty()
                join frequency in uow.Retrieve<BsFrequency>() on tempAdvice.FrequencyId equals frequency.Id into frequency_join
                from frequency in frequency_join.DefaultIfEmpty()
                join signatureNurse in uow.Retrieve<BsUser>() on execution.ExecutedOperId equals signatureNurse.Id into signatureNurse_join
                from signatureNurse in signatureNurse_join.DefaultIfEmpty()
                join item in uow.Retrieve<BsItem>() on tempAdvice.ItemId equals item.Id into item_join
                from item in item_join.DefaultIfEmpty()
                join unitOfSingle in uow.Retrieve<BsUnit>() on tempAdvice.UnitTakeId equals unitOfSingle.Id into unitOfSingle_join
                from unitOfSingle in unitOfSingle_join.DefaultIfEmpty()
                join unitOfTotality in uow.Retrieve<BsUnit>() on tempAdvice.UnitInId equals unitOfTotality.Id into unitOfTotality_join
                from unitOfTotality in unitOfTotality_join.DefaultIfEmpty()
                select new AdviceMessage()
                {
                    Patient = patient,
                    TempAdvice = tempAdvice,
                    LongAdvice = null,
                    Frequency = frequency,
                    Execution = execution,
                    SignatureNurse = signatureNurse,
                    Usage = usage,
                    UnitOfSingle = unitOfSingle,
                    UnitOfTotality = unitOfTotality,
                    CancellationDoctor = cancellationDoctor
                };
            
            return tempAdviceMessageQueryable;
        }

        private IQueryable<AdviceMessage> BuildLongAdviveQueryable(IUnitOfWork uow)
        {
            IQueryable<AdviceMessage> longAdviceQueryable =
                from patient in uow.Retrieve<BsPatient>()
                join hosinfo in uow.Retrieve<InHosInfo>() on patient.Id equals hosinfo.PatId
                join longAdvice in uow.Retrieve<InAdviceLong>() on hosinfo.Id equals longAdvice.HospId
                join execution in uow.Retrieve<InExecute>() on longAdvice.Id equals execution.AdviceId into execution_join
                from execution in execution_join.DefaultIfEmpty()
                join advice_doctor in uow.Retrieve<BsDoctor>() on longAdvice.DoctorId equals advice_doctor.Id into advice_doctor_join
                from advice_doctor in advice_doctor_join.DefaultIfEmpty()
                join cancellationDoctor in uow.Retrieve<BsDoctor>() on longAdvice.EndOperId equals cancellationDoctor.Id into cancellationDoctor_join
                from cancellationDoctor in cancellationDoctor_join.DefaultIfEmpty()
                join usage in uow.Retrieve<BsUsage>() on longAdvice.UsageId equals usage.Id into usage_join
                from usage in usage_join.DefaultIfEmpty()
                join frequency in uow.Retrieve<BsFrequency>() on longAdvice.FrequencyId equals frequency.Id into frequency_join
                from frequency in frequency_join.DefaultIfEmpty()
                join signatureNurse in uow.Retrieve<BsUser>() on execution.ExecutedOperId equals signatureNurse.Id into signatureNurse_join
                from signatureNurse in signatureNurse_join.DefaultIfEmpty()
                join item in uow.Retrieve<BsItem>() on longAdvice.ItemId equals item.Id into item_join
                from item in item_join.DefaultIfEmpty()
                join unitOfSingle in uow.Retrieve<BsUnit>() on longAdvice.UnitTakeId equals unitOfSingle.Id into unitOfSingle_join
                from unitOfSingle in unitOfSingle_join.DefaultIfEmpty()
                join unitOfTotality in uow.Retrieve<BsUnit>() on longAdvice.UnitInId equals unitOfTotality.Id into unitOfTotality_join
                from unitOfTotality in unitOfTotality_join.DefaultIfEmpty()
                select new AdviceMessage()
                {
                    Patient = patient,
                    TempAdvice = null,
                    LongAdvice = longAdvice,
                    Frequency = frequency,
                    Execution = execution,
                    SignatureNurse = signatureNurse,
                    Usage = usage,
                    UnitOfSingle = unitOfSingle,
                    UnitOfTotality = unitOfTotality,
                    CancellationDoctor = cancellationDoctor
                };

            return longAdviceQueryable;
        }
        #endregion

        #region 获取部门科室
        public Response<List<SysDepartmentDTO>> GetAllDepartments(string lastlyUpdateTime)
        {
            var response = new Response<List<SysDepartmentDTO>>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");
            #endregion

            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow =>
                {
                    return DepartmentQueryable(uow)
                        .Where(x => x.LastlyUpdateTime > _lastlyUpdateTime)
                        .ToList();
                });

                return response;
            }    
        }

        public Response<SysDepartmentDTO> GetDepartmentByID(string lastlyUpdateTime, string departmentID)
        {
            var response = new Response<SysDepartmentDTO>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");
            int identifier = Utils.IdentifierValidation(departmentID, "departmentID");
            #endregion

            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow => 
                {
                    return DepartmentQueryable(uow)
                        .Where(x => x.ID == identifier)
                        .Where(x => x.LastlyUpdateTime > _lastlyUpdateTime)
                        .SingleOrDefault();
                });                
            }

            return response;
        }

        private IQueryable<SysDepartmentDTO> DepartmentQueryable(IUnitOfWork uow)
        {
            IQueryable<SysDepartmentDTO> departmentQueryable =
                from dept in uow.Retrieve<BsLocation>()
                select new SysDepartmentDTO()
                {
                    ID = dept.ID,
                    DeptCode = dept.Code,
                    DeptName = dept.Name,
                    IsDelete = !dept.IsActive,
                    LastlyUpdateTime = dept.LastlyUpdateTime
                };

            return departmentQueryable;
        }

        #endregion

        #region 获取员工
        public Response<SysStaffDTO> GetStaffByID(string lastlyUpdateTime, string staffID)
        {
            var response = new Response<SysStaffDTO>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");
            int identifier = Utils.IdentifierValidation(staffID, "staffID");
            #endregion

            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow =>
                {
                    return BuildStaffQueryable(uow)
                       .Where(x => x.User.Id == identifier)
                       .Where(x => x.User.LastlyUpdateTime > _lastlyUpdateTime)
                       .Convert2DTO()
                       .SingleOrDefault();
                });                

                return response;
            }
        }

        public Response<List<SysStaffDTO>> GetAllStaff(string lastlyUpdateTime)
        {
            var response = new Response<List<SysStaffDTO>>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");
            #endregion 
            
            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow =>
                {
                    return BuildStaffQueryable(uow)
                        .Where(x => x.User.LastlyUpdateTime > _lastlyUpdateTime)
                        .Convert2DTO()
                        .ToList()
                        ;
                });
                
                return response;
            }
        }

        private IQueryable<StaffMessage> BuildStaffQueryable(IUnitOfWork uow)
        {
            IQueryable<StaffMessage> staffMessageQueryable =
                from user in uow.Retrieve<BsUser>()
                join userRole in uow.Retrieve<BsUserRole>() on user.Id equals userRole.OperId into userRole_join
                from userRole in userRole_join.DefaultIfEmpty()
                join role in uow.Retrieve<GblRole>() on userRole.RoleId equals role.Id into role_join
                from role in role_join.DefaultIfEmpty()
                join userLocation in uow.Retrieve<BsUserLocation>() on user.Id equals userLocation.OperId into userLocation_join
                from userLocation in userLocation_join.DefaultIfEmpty()
                join location in uow.Retrieve<BsLocation>() on userLocation.LocationId equals location.ID into location_join
                from location in location_join.DefaultIfEmpty()
                join profession in uow.Retrieve<BsDocLevel>() on user.DocLevId equals profession.ID into profession_join
                from profession in profession_join.DefaultIfEmpty()
                join station in uow.Retrieve<BsUserLevel>() on user.UserLevelId equals station.Id into station_join
                from station in station_join.DefaultIfEmpty()
                select new StaffMessage
                {
                    User = user,
                    Role = role,
                    Department = location,
                    Profession = profession,
                    Station = station
                };            

            return staffMessageQueryable;
        }
        #endregion

        #region 体征三测单数据
        public Response<List<BusSignDataDTO>> GetVitalSignsByPatientNo(string lastlyUpdateTime, string patientNo)
        {
            var response = new Response<List<BusSignDataDTO>>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");
            Utils.StringValidation(patientNo, "patientNo");
            #endregion

            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow =>
                {
                    return BuildSignDataQueryable(uow)
                        .Where(x => x.Patient.InPatNo == patientNo)
                        .Where(x => x.Patient.LastlyUpdateTime > _lastlyUpdateTime)
                        .Convert2DTO()
                        .ToList();
                });

                return response;
            }
        }

        private IQueryable<VitalSignsMessage> BuildSignDataQueryable(IUnitOfWork uow)
        {
            var signDataQueryable = from patient in uow.Retrieve<BsPatient>()
                                    join hosinfo in uow.Retrieve<InHosInfo>() on patient.Id equals hosinfo.PatId
                                    join bodyHeat in uow.Retrieve<InBodyHeat>() on hosinfo.Id equals bodyHeat.HospId
                                    join user in uow.Retrieve<BsUser>() on bodyHeat.OperId equals user.Id into user_join
                                    from user in user_join.DefaultIfEmpty()
                                    select new VitalSignsMessage() 
                                    {
                                        Patient = patient,
                                        HosInfo = hosinfo,
                                        VitalSigns = bodyHeat,
                                        Operator = user,
                                    };                                
            return signDataQueryable;
        }
        #endregion

        #region 获取长者信息
        public Response<List<BusPatientInfoDTO>> GetAllPatientInfos(string lastlyUpdateTime)
        {
            var response = new Response<List<BusPatientInfoDTO>>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");
            #endregion 

            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow =>
                {
                    return BuildPatientQueryable(uow)
                        .Where(x => x.Patient.LastlyUpdateTime > _lastlyUpdateTime)
                        .Convert2DTO()
                        .ToList()
                        ;
                });

                return response;
            }
        }        

        public Response<BusPatientInfoDTO> GetPatientInfoByPatientNo(string lastlyUpdateTime, string patientNo)
        {
            var response = new Response<BusPatientInfoDTO>();

            #region argument validation
            DateTime _lastlyUpdateTime = Utils.DateTimeValidation(lastlyUpdateTime, "lastlyUpdateTime");
            Utils.StringValidation(patientNo, "patientNo");
            #endregion

            using (var command = CommandWrapper)
            {
                response.Body.Result = command.Execute(uow =>
                {
                    return BuildPatientQueryable(uow)
                        .Where(x => x.Patient.InPatNo == patientNo)
                        .Where(x => x.Patient.LastlyUpdateTime > _lastlyUpdateTime)
                        .Convert2DTO()
                        .SingleOrDefault()
                        ;
                });
                
                return response;
            }
        }

        private IQueryable<PatientMessage> BuildPatientQueryable(IUnitOfWork uow)
        {
            IQueryable<PatientMessage> patientMessageQueryable =
                from patient in uow.Retrieve<BsPatient>().Where(x => x.IsActive == true)
                join hosinfo in uow.Retrieve<InHosInfo>() on patient.Id equals hosinfo.PatId
                join nursingGrade in uow.Retrieve<BsNursingGrade>() on hosinfo.NursingGradeId equals nursingGrade.Id into nursingGrade_join
                from nursingGrade in nursingGrade_join.DefaultIfEmpty()
                join mealType in uow.Retrieve<BsMealType>() on hosinfo.MealTypeId equals mealType.Id into mealType_join
                from mealType in mealType_join.DefaultIfEmpty()
                join nation in uow.Retrieve<BsNation>() on patient.NationId equals nation.Id into nation_join
                from nation in nation_join.DefaultIfEmpty()
                join country in uow.Retrieve<BsCountry>() on patient.CountryId equals country.Id into country_join
                from country in country_join.DefaultIfEmpty()
                join firstRelation in uow.Retrieve<BsRelation>() on hosinfo.FirstRelationId equals firstRelation.Id into firstRelation_join
                from firstRelation in firstRelation_join.DefaultIfEmpty()
                join secondRelation in uow.Retrieve<BsRelation>() on hosinfo.SecondRelationId equals secondRelation.Id into secondRelation_join
                from secondRelation in secondRelation_join.DefaultIfEmpty()
                select new PatientMessage
                {
                    Patient = patient,
                    InHosInfo = hosinfo,
                    NursingGrade = nursingGrade,
                    MealType = mealType,
                    Nation = nation,
                    Country = country,
                    TheFirstRelation = firstRelation,
                    TheSecondRelation = secondRelation,
                };

            return patientMessageQueryable;
        }

        #endregion
      
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (CommandWrapper != null)
                    {
                        CommandWrapper.Dispose();
                    }
                }
            }

            this.disposed = true;
        }
        #endregion

    }
}