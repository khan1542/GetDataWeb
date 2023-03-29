using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace GetDataFromDBApp.Models
{
    public class Parameter
    {
        [Key]
        public int ID_Parameter { get; set; }

        public string ParameterName { get; set; }
    }


}
