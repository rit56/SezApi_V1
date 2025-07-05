using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstCHA")]
public class MstCHA
{
    [Key]
    public int? CHAID { get; set; }
    public string CHA { get; set; }
   
}

