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
    
    public partial class CabinetInventoryObject
    {
        public int ID { get; set; }
        public int IDInventoryObject { get; set; }
        public int IDCabinet { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Cabinet Cabinet { get; set; }
        public virtual InventoryObject InventoryObject { get; set; }
    }
}