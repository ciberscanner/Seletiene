//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeletieneDPS.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class productservice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public productservice()
        {
            this.qualificationps = new HashSet<qualificationps>();
        }
    
        public int id { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<int> idcategory { get; set; }
        public Nullable<int> idowner { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime dateup { get; set; }
        public int dpsvalidation { get; set; }
        public string schedule { get; set; }
        public Nullable<int> state { get; set; }
    
        public virtual category category { get; set; }
        public virtual state state1 { get; set; }
        public virtual state state2 { get; set; }
        public virtual userapp userapp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<qualificationps> qualificationps { get; set; }
    }
}