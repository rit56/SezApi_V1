using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstEquipmentSealType")]
public class MstEquipmentSealType
{
    [Key]
    public int? EquipmentSealTypeID { get; set; }
    public string EquipmentSealType { get; set; }
   
}

