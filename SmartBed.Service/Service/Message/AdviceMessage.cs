using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBed.Domain;

namespace SmartBed.Service.Message
{
    public class AdviceMessage
    {
        public BsPatient Patient { get; set; }        

        public InAdviceTemp TempAdvice { get; set; }

        public InAdviceLong LongAdvice { get; set; }

        public InExecute Execution { get; set; }

        public BsFrequency Frequency { get; set; }

        public BsUser SignatureNurse { get; set; }

        public BsUsage Usage { get; set; }

        public BsUnit UnitOfSingle { get; set; }

        public BsUnit UnitOfTotality { get; set; }

        public BsDoctor CancellationDoctor { get; set; }
    }
}
