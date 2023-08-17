using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string ContractNumber { get; set; }
        public string ProjectName { get; set; }
        public string UserCreate { get; set; }
        public string UserEdit { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public DateTime GoLiveDate { get; set; }
        public DateTime? MaintenanceEndDate { get; set; }
        public DateTime? MaintenanceDateStart { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int WarrantyTime { get; set; }
        public int MaintenanceTime { get; set; }
        public bool Active { get; set; }
        public bool IsDel { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateEdit { get; set; }

    }
    public class DropdownItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
