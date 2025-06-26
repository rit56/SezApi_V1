using System.ComponentModel.DataAnnotations;

namespace SezApi.Model.Response
{
    public class ResponseMISCCharge
    {
        [Key]
        public int? MiscellaneousId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int? SacCodeId { get; set; }
        public string? SacCode { get; set; }
         public string? OperationDesc { get; set; }
        public string? Size { get; set; }
        public decimal? Rate { get; set; }
    }
}
