namespace SezApi.Model.Request
{
    public class RequestHTCharge
    {
        public int? HTChargesID { get; set; }
        public int? SacCodeId { get; set; }
        public int? OperationId { get; set; }
        public DateTime EffectiveDate { get; set; }

        public string Size { get; set; }
        public decimal? Rate { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


    }
}
