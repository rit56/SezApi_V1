using DpeApi.Model.DBModels;
using System.ComponentModel.DataAnnotations;

namespace DpeApi.Model.Response
{
    public class AddEditResponse
    {
        [Key]
        public string Response { get; set; }

    }
}
