using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInventory.Model
{
   public class ResponseInventoryObject
    {
        public ResponseInventoryObject(InventoryObject inventoryObject)
        {
            this.ID = inventoryObject.ID;
            this.Title = inventoryObject.Title;
            this.InventoryNumber = inventoryObject.InventoryNumber;
            this.CommissioningDate = inventoryObject.CommissioningDate;
            this.DocumentationPath = inventoryObject.DocumentationPath;
            this.IDType = inventoryObject.IDType;
            this.IDSubType = inventoryObject.IDSubType;
            this.LifeTime = inventoryObject.LifeTime;
            this.IDInvoce = inventoryObject.IDInvoce;
            this.IDCurrentStatus = inventoryObject.IDCurrentStatus;
            this.Amount = inventoryObject.Amount;
            this.IDEmployee = inventoryObject.IDEmployee;
            this.IDInventoryObjectDetail = inventoryObject.IDInventoryObjectDetail;
        }
        public ResponseInventoryObject() { }
        public int ID { get; set; }
        public string Title { get; set; }
        public string InventoryNumber { get; set; }
        public System.DateTime CommissioningDate { get; set; }
        public string DocumentationPath { get; set; }
        public int IDType { get; set; }
        public int IDSubType { get; set; }
        public int LifeTime { get; set; }
        public int IDInvoce { get; set; }
        public int IDCurrentStatus { get; set; }
        public decimal Amount { get; set; }
        public int IDEmployee { get; set; }
        public int IDInventoryObjectDetail { get; set; }
    }
    
}
