namespace DpeApi.Model.Request
{
    public class RequestGroundRentCharge
    {
        public int? GroundRentId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int? SacCodeId { get; set; }
        public int? DaysRangeFrom { get; set; }
        public int? DaysRangeTo { get; set; }
        public int? ContainerType { get; set; }
        public int? CommodityType { get; set; }
        public string Size { get; set; }
        public string FclLcl { get; set; }
        public decimal? RentAmount { get; set; }
        public int? OperationType { get; set; }
        
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


    }
}
