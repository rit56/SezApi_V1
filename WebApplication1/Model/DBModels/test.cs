using System.ComponentModel.DataAnnotations;

namespace DpeApi.Model.DBModels
{
    public class test
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
