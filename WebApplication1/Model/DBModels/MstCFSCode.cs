using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstCFSCode")]
public class MstCFSCode
{
    [Key]
    public int? CFSCodeID { get; set; }
    public string CFSCode { get; set; }
   
}

