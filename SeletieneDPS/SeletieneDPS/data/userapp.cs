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
    
    public partial class userapp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public userapp()
        {
            this.productservice = new HashSet<productservice>();
        }
    
        public int id { get; set; }
        public string id_card { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string lastname1 { get; set; }
        public string lastname2 { get; set; }
        public Nullable<System.DateTime> birthdate { get; set; }
        public System.DateTime registrationdate { get; set; }
        public int city { get; set; }
        public Nullable<int> collective { get; set; }
        public string telephone { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }
        public string passw { get; set; }
        public Nullable<int> active { get; set; }
        public Nullable<int> suspended { get; set; }
    
        public virtual city city1 { get; set; }
        public virtual collective collective1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productservice> productservice { get; set; }
        public virtual state state { get; set; }
        public virtual state state1 { get; set; }
    }
}
