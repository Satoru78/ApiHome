//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiInventory.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CurrentStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CurrentStatus()
        {
            this.InventoryObject = new HashSet<InventoryObject>();
        }
    
        public int ID { get; set; }
        public int IDStatus { get; set; }
        public string NumberAct { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryObject> InventoryObject { get; set; }
    }
}
