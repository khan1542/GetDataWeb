using Microsoft.EntityFrameworkCore;

namespace GetDataWeb.Models
{
    [Keyless]
    public class SPModel
    {
        public string Descr { get; set; }
        public string sDp1 { get; set; }
        public string sDp2 { get; set; }
        public string sDp4 { get; set; }
        public string sDp6 { get; set; }
        public string sDp7 { get; set; }
        public string sDp8 { get; set; }
        public string sDp9 { get; set; }
        public string sDp10 { get; set; }
        public string sDp255 { get; set; }
        public string sDpBegYear { get; set; }
    }
}
