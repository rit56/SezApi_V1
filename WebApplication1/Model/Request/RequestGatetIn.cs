using System.ComponentModel;
using System.Drawing;
using System.Security.Principal;

namespace DpeApi.Model.Request
{
    public class RequestGetIn
    {
       
        public int? GetInId { get; set; }
        public string CFSCode { get; set; }
        public int RefNo { get; set; }
        public DateTime EntryDate { get; set; }
        public TimeSpan EntryTime { get; set; }
        public DateTime SystemDate { get; set; }
        public TimeSpan SystemTime { get; set; }

        public string ContainerNo { get; set; }
        public string CustomSealNo { get; set; }
        public int? Size { get; set; }
        public int? ShippingLine { get; set; }
        public int? CHA { get; set; }


      
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
