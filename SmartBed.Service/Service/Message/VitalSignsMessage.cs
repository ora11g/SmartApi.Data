using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBed.Domain;

namespace SmartBed.Service.Message
{
    public class VitalSignsMessage
    {
        public BsPatient Patient { get; set; }

        public InHosInfo HosInfo { get; set; }

        public InBodyHeat VitalSigns { get; set; }

        public BsUser Operator { get; set; } 
    }
}
