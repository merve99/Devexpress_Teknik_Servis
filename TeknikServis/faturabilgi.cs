//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis
{
    using System;
    using System.Collections.Generic;
    
    public partial class faturabilgi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public faturabilgi()
        {
            this.faturadetay = new HashSet<faturadetay>();
        }
    
        public int id { get; set; }
        public string seri { get; set; }
        public string sirano { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
        public string saat { get; set; }
        public string vergidaire { get; set; }
        public Nullable<int> cariId { get; set; }
        public Nullable<int> personel { get; set; }
    
        public virtual cari cari { get; set; }
        public virtual personel personel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<faturadetay> faturadetay { get; set; }
    }
}
