//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCNLTHD2018.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETPHIEUMUON
    {
        public string SoPhieu { get; set; }
        public string MaSach { get; set; }
        public Nullable<System.DateTime> NgayHenTra { get; set; }
    
        public virtual SACH SACH { get; set; }
        public virtual MUONSACH MUONSACH { get; set; }
    }
}
