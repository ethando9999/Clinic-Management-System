//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhongKham
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_PhieuKham
    {
        public int MaCtpk { get; set; }
        public int Mathuoc { get; set; }
        public int MaPK { get; set; }
        public int Soluong { get; set; }
        public string TinhTrang { get; set; }
    
        public virtual PhieuKham PhieuKham { get; set; }
        public virtual Thuoc Thuoc { get; set; }
    }
}
