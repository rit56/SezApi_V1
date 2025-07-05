using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DpeApi.Model.Response
{
    public class ResponseGetIn
    {
        [Key]
        public int? GetInId { get; set; }
        public string CFSCode { get; set; }
        public string RefNo { get; set; }
        public DateTime EntryDate { get; set; }
        public TimeSpan EntryTime { get; set; }
        public DateTime SystemDate { get; set; }
        public TimeSpan SystemTime { get; set; }

        public string ContainerNo { get; set; }
        public string CustomSealNo { get; set; }
        public string Size { get; set; }
        public string ShippingLine { get; set; }
        public string CHA { get; set; }

    }
}
