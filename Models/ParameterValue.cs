using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDataFromDBApp.Models
{
    public class ParameterValue
    {
        [Key]
        public DateTime dtFistDay { get; set; }

        [ForeignKey("Parameter")]
        public int ID_Parameter { get; set; }
        public Parameter Parameter { get; set; }
        public int ID_Pech { get; set; }
        public double Value { get; set; }
    }
}
