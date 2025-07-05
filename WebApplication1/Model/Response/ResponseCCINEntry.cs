using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Principal;

namespace DpeApi.Model.Request
{
    public class ResponseCCINEntry
    {
        [Key]
        public int? CCINEntryId { get; set; }
        public string CFSCode { get; set; }
        public string ContainerNo { get; set; }
        public string Size { get; set; }
        public string SBNO { get; set; }
        public DateTime? SBDate { get; set; }



        public string CargoType { get; set; }
        public string LoadType { get; set; }

        public string CustomSealNo { get; set; }
        public string PackageType { get; set; }
        public string EquipmentSealType { get; set; }
        public string EquipmentStatus { get; set; }
        public string EquipmentQUC { get; set; }
        public string PackUQC { get; set; }
        public string CargoDescription { get; set; }
        public int NoofUnit { get; set; }
        public string GRWT { get; set; }
        public string FOBVAL { get; set; }
        public string Vessel { get; set; }
        public string Voyage { get; set; }
        public string Rotation { get; set; }
        public string SBEIRNo { get; set; }
        

    }
}
