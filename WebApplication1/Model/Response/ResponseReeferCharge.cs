using System.ComponentModel.DataAnnotations;

namespace SezApi.Model.Response
{
    public class ResponseReeferCharge
    {
        [Key]
        public int? ReeferChrgId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int? SacCodeId { get; set; }
        public string? SacCode { get; set; }
        public string? Hours { get; set; }
        public string? Size { get; set; }
        public decimal? Rate { get; set; }

    }
}
