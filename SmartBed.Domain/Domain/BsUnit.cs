using System;
using System.Collections.Generic;
using Xx.His.Domain;

namespace SmartBed.Domain
{
    public partial class BsUnit : EntityBase
    {
        public int Id { get; set; }
        ///<summary>
        /// 单位ID
        ///</summary>
        public string Code { get; set; }
        ///<summary>
        /// 单位
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        /// 打印/显示名
        ///</summary>
        public string PrintName { get; set; }
        ///<summary>
        /// 五笔码
        ///</summary>
        public string WbCode { get; set; }
        ///<summary>
        /// 拼音码
        ///</summary>
        public string PyCode { get; set; }
        ///<summary>
        /// 显示顺序
        ///</summary>
        public short OrderBy { get; set; }
        ///<summary>
        /// 有效标志
        ///</summary>
        public bool IsActive { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public short IconIndex { get; set; }
	}
}
