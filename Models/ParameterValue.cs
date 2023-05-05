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
        public DateTime DtFirstDay { get; set; }

        [ForeignKey("Parameter")]
        public int ParameterId { get; set; }

        public Parameter Parameter { get; set; }

        public int PechId { get; set; }

        public double? Value { get; set; }
    }
}
