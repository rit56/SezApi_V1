using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstShippingLine")]
public class MstShippingLine
{
    [Key]
    public int? ShippingLineID { get; set; }
    public string ShippingLine { get; set; }
   
}

