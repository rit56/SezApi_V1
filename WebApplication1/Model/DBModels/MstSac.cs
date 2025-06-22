using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstsac")]
public class MstSac
{
    [Key]
    public int? SacId { get; set; }
    public string SacCode { get; set; }
    public string Description { get; set; }
}

