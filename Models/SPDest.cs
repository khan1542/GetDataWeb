using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GetDataWeb.Models
{
    public class SPDest
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }

        public double? sDP1 { get; set; }

        public double? sDP2 { get; set; }

        public double? sDP4 { get; set; }

        public double? sDP6 { get; set; }

        public double? sDP7 { get; set; }

        public double? sDP8 { get; set; }

        public double? sDP9 { get; set; }

        public double? sDP10 { get; set; }

        public double? sDP255 { get; set; }

        public double? sDPBegYear { get; set; }
    }
}
