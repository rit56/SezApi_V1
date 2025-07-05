using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstEquipmentQUC")]
public class MstEquipmentQUC
{
    [Key]
    public int? EquipmentQUCID { get; set; }
    public string EquipmentQUC { get; set; }
   
}

