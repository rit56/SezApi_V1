using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstPackUQC")]
public class MstPackUQC
{
    [Key]
    public int? PackUQCID { get; set; }
    public string PackUQC { get; set; }
   
}

