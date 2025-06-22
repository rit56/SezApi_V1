using System.ComponentModel.DataAnnotations;

namespace SezApi.Model.Response
{
    public class ResponseHTCharge
    {
        [Key]
        public int HTChargesID { get; set; }
        public int? SacCodeId { get; set; }
        public int? OperationId { get; set; }
        public DateTime? EffectiveDate { get; set; }

        public string? Size { get; set; }
        public decimal? Rate { get; set; }
        public string? OperationDesc { get; set; }
        public string? SacCode { get; set; }
        
    }
}
