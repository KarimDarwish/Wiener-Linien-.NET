//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WienerLinienApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Haltestellen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Haltestellen()
        {
            this.Steiges = new HashSet<Steige>();
        }
    
        public int Haltestellen_ID { get; set; }
        public string Typ { get; set; }
        public Nullable<int> Diva { get; set; }
        public string Name { get; set; }
        public string Gemeinde { get; set; }
        public Nullable<int> Gemeinde_ID { get; set; }
        public string WGS84_LAT { get; set; }
        public string WGS84_LON { get; set; }
        public string Stand { get; set; }
    
        public virtual BenutzerHaltestellen BenutzerHaltestellen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Steige> Steiges { get; set; }
    }
}