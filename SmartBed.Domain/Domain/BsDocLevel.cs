using System;
using System.Collections.Generic;
using Xx.His.Domain;

namespace SmartBed.Domain
{
    public partial class BsDocLevel : EntityBase
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PyCode { get; set; }
        public string WbCode { get; set; }
        public int OrderBy { get; set; }
        public bool IsActive { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public short IconIndex { get; set; }
    }
}
