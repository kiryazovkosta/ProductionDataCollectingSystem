

namespace CollectingProductionDataSystem.Models.Productions
{
    using System;
    using CollectingProductionDataSystem.Models.Abstract;
    using CollectingProductionDataSystem.Models.Contracts;
    using CollectingProductionDataSystem.Models.Nomenclatures;

    public partial class UnitsData : AuditInfo, IApprovableEntity, IEntity
    {
        public int Id { get; set; }
        public DateTime RecordTimestamp { get; set; }
        public int UnitConfigId { get; set; }
        public decimal? Value { get; set; }
        public int? EditReasonId { get; set; }
        public bool IsApproved { get; set; }
        public virtual UnitConfig Unit { get; set; }
        public virtual EditReason EditReason { get; set; }
        public virtual UnitsManualData UnitsManualData { get; set; }
    }
}
