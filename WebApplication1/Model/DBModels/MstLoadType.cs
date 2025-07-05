using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstLoadType")]
public class MstLoadType
{
    [Key]
    public int? LoadTypeID { get; set; }
    public string LoadType { get; set; }
   
}

