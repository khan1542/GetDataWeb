using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace GetDataFromDBApp.Models
{
    public class Parameter
    {
        [Key]
        public int ParameterId { get; set; }

        public string Name { get; set; }
    }


}
