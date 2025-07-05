using System.ComponentModel;
using System.Drawing;
using System.Security.Principal;

namespace DpeApi.Model.Request
{
    public class RequestCCINEntry
    {
       
        public int? CCINEntryId { get; set; }
        public int CFSCode { get; set; }
        public string ContainerNo { get; set; }
        public int Size { get; set; }
        public string SBNO { get; set; }
        public DateTime SBDate { get; set; }



        public int CargoType { get; set; }
        public int LoadType { get; set; }
   
        public string CustomSealNo { get; set; }
        public int PackageType { get; set; }
        public int EquipmentSealType { get; set; }
        public int EquipmentStatus { get; set; }
        public int EquipmentQUC { get; set; }
        public int PackUQC { get; set; }
        public string CargoDescription { get; set; }
        public int NoofUnit { get; set; }
        public string GRWT { get; set; }
        public string FOBVAL { get; set; }
        public string Vessel { get; set; }
        public string Voyage { get; set; }
        public string Rotation { get; set; }
        public string SBEIRNo { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
