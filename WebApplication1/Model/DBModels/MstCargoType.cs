using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstCargoType")]
public class MstCargoType
{
    [Key]
    public int? CargoTypeID { get; set; }
    public string CargoType { get; set; }
   
}

