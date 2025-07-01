using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DpeApi.Model.Response
{
    public class ResponseGroundRentCharge
    {
        [Key]
        public int GroundRentId { get; set; }
        public int? SacCodeId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string? SacCode { get; set; }
        public string? DaysRange { get; set; }
        public string? ContainerType { get; set; }
        public string? ContainerDetails { get; set; }
        public string? Size { get; set; }
        public string? FclLcl { get; set; } 
        public decimal? Amount { get; set; }
        public string? OperationType { get; set; }
    }
}
