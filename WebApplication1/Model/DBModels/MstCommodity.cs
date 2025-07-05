using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstCommodity")]
public class MstCommodity
{
    [Key]
    public int? CommodityId { get; set; }
    public string CommodityName { get; set; }
    public string CommodityType { get; set; }
    public string Alias { get; set; }
}

