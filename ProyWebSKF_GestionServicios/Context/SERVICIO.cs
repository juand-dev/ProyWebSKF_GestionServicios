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
    
    public partial class SERVICIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICIO()
        {
            this.DETALLEPAQUETEs = new HashSet<DETALLEPAQUETE>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int tipoServicio_id { get; set; }
        public Nullable<decimal> costo { get; set; }
    
        public virtual TIPOSERVICIO TIPOSERVICIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLEPAQUETE> DETALLEPAQUETEs { get; set; }
    }
}
