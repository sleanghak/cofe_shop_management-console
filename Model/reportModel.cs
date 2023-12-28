using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.Model
{
    class reportModel
    {
        public int re_id { get; set; }
        public DateTime date { get; set; }
        public int quantity { get; set; }
        public string report_type { get; set; }
        public double total_price { get; set; }
    }
}
