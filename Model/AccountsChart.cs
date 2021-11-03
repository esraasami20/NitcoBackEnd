using System;
using System.Collections.Generic;

#nullable disable

namespace NitcoBackEnd.Model
{
    public partial class AccountsChart
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Number { get; set; }
        public short FkTransactionTypeId { get; set; }
        public bool AllowEntry { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? Status { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentNumber { get; set; }
        public short ChartLevelDepth { get; set; }
        public short? FkCostCenterTypeId { get; set; }
        public long BranchId { get; set; }
        public long OrgId { get; set; }
        public Guid? FkWorkFieldsId { get; set; }
        public short? NoOfChilds { get; set; }
    }
}
