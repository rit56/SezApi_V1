using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstReferenceNo")]
public class MstReferenceNo
{
    [Key]
    public int? MstRefNo { get; set; }
    public string ReferenceNo { get; set; }
   
}

