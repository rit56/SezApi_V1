using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mstPackageType")]
public class MstPackageType
{
    [Key]
    public int? PackageTypeID { get; set; }
    public string PackageType { get; set; }
   
}

