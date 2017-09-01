using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBed.Domain;

namespace SmartBed.Service.Message
{
    public class PatientMessage
    {
        public BsPatient Patient { get; set; }

        public InHosInfo InHosInfo { get; set; }
        
        public BsMealType MealType { get; set; }
        
        public BsNursingGrade NursingGrade { get; set; }
        
        public BsNation Nation { get; set; }
        
        public BsRelation TheFirstRelation { get; set; }
        
        public BsRelation TheSecondRelation { get; set; }
        
        public BsCountry Country { get; set; }
    }
}
