//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiMedLab.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Laborant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Laborant()
        {
            this.ServiceRendered = new HashSet<ServiceRendered>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string IPAdress { get; set; }
        public System.DateTime Lastenter { get; set; }
        public int IDService { get; set; }
        public string IDRole { get; set; }
    
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceRendered> ServiceRendered { get; set; }
    }
}