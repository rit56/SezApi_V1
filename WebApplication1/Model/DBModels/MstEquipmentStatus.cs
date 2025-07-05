using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstEquipmentStatus")]
public class MstEquipmentStatus
{
    [Key]
    public int? EquipmentStatusID { get; set; }
    public string EquipmentStatus { get; set; }
   
}

