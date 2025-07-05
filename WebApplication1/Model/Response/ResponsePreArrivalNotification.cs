using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DpeApi.Model.Response
{
    public class ResponsePreArrivalNotification
    {
        [Key]
        public int? PreArrivalNotificationId { get; set; }
        public DateTime? PreArrivalDate { get; set; }
        public string PreArrivalNo { get; set; }
        public string ContainerNo { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string WTKg { get; set; }
        public string Value { get; set; }
        public string Commodity { get; set; }
        public DateTime? ExpectedArrivalDate { get; set; }
        public TimeSpan? ExpectedArrivalTime { get; set; }


    }
}
