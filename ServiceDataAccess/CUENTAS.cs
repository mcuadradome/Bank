//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUENTAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUENTAS()
        {
            this.SALDO = new HashSet<SALDO>();
        }
    
        public int id { get; set; }
        public int id_user { get; set; }
        public string cuenta { get; set; }
        public Nullable<bool> state_account { get; set; }
    
        public virtual USUARIOS USUARIOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALDO> SALDO { get; set; }
    }
}
