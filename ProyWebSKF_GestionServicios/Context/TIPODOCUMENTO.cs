//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyWebSKF_GestionServicios.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIPODOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPODOCUMENTO()
        {
            this.PERSONAS = new HashSet<PERSONA>();
        }
    
        public int id { get; set; }
        public string descripcionLarga { get; set; }
        public string descripcionCorta { get; set; }
        public Nullable<int> longitud { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERSONA> PERSONAS { get; set; }
    }
}
