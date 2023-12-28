using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.Model
{
    class orderModel
    {
        public int or_id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public DateTime date { get; set; }
        public int total_price { get; set; }
        public int re_id { get; set; }
    }
}
