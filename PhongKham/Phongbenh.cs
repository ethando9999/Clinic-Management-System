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
    
    public partial class Phongbenh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phongbenh()
        {
            this.BenhNhans = new HashSet<BenhNhan>();
        }
    
        public string MaPhongbenh { get; set; }
        public string TenPhongbenh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BenhNhan> BenhNhans { get; set; }
    }
}