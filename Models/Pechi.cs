using System.ComponentModel.DataAnnotations;

namespace GetDataFromDBApp.Models
{
    public class Pechi
    {
        [Key]
        public int ID_Dp { get; set; }
        
        public int DpName { get; set; }

    }
}
