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
    
    public partial class PhieuKham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuKham()
        {
            this.CT_PhieuKham = new HashSet<CT_PhieuKham>();
        }
    
        public int MaPK { get; set; }
        public int MaBN { get; set; }
        public string MaBenh { get; set; }
        public string TrieuChung { get; set; }
        public System.DateTime NgayLap { get; set; }
    
        public virtual Benh Benh { get; set; }
        public virtual BenhNhan BenhNhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuKham> CT_PhieuKham { get; set; }
    }
}
