using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.Model
{
    class drinkModel
    {
        public int dr_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public int or_id { get; set; }
        public int emp_id { get; set; }
    }
}
