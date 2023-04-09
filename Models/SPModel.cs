using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GetDataWeb.Models
{
    [Keyless]
    public class SPModel
    {
        public string Descr { get; set; }
        public string sDP1 { get; set; }
        public string sDP2 { get; set; }
        public string sDP4 { get; set; }
        public string sDP6 { get; set; }
        public string sDP7 { get; set; }
        public string sDP8 { get; set; }
        public string sDP9 { get; set; }
        public string sDP10 { get; set; }
        public string sDP255 { get; set; }
        public string sDPBegYear { get; set; }
    }
}
