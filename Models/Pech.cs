using System.ComponentModel.DataAnnotations;

namespace GetDataFromDBApp.Models
{
    public class Pech
    {
        [Key]
        public int PechId { get; set; }
        
        public string Name { get; set; }

    }
}
