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
    
    public partial class InventoryObjectInentoryObjectDetails
    {
        public int ID { get; set; }
        public int IDInventoryObject { get; set; }
        public int IDInventoryObjectDetails { get; set; }
    
        public virtual InventoryObject InventoryObject { get; set; }
        public virtual InventoryObjectDetails InventoryObjectDetails { get; set; }
    }
}
