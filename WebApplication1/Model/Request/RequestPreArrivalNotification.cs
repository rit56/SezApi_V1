namespace DpeApi.Model.Request
{
    public class RequestPreArrivalNotification
    {
        public int? PreArrivalNotificationId { get; set; }
        public DateTime PreArrivalDate { get; set; }
        public string? PreArrivalNo { get; set; }
        public string? ContainerNo { get; set; }
        public int Size { get; set; }
        public int Type { get; set; }
        public string? WTKg { get; set; }
        public string? Value { get; set; }
        public int Commodity { get; set; }
        public DateTime ExpectedArrivalDate { get; set; }
        public TimeSpan ExpectedArrivalTime { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public IFormFile? PackListPDF { get; set; } 
        public string? PackListPDFName { get; set; }
        public string? PackListPDF_GUID { get; set; } 
        public IFormFile? CheckListPDF { get; set; }
        public string? CheckListPDFName { get; set; }
        public string? CheckListPDF_GUID { get; set; } 

    }
}
