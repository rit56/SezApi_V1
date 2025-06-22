using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstoperation")]
public class MstOperation
{
    [Key]
    public int? OperationId { get; set; }
    public string OperationType { get; set; }
    public string OperationSDesc { get; set; }
    public string OperationDesc { get; set; }
    public int SacId { get; set; }
}

