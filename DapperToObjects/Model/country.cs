using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperToObjects.Model
{
    public class country
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection city { get; set; }

    }

    public class city
    {
        public int id { get; set; }
        public string name { get; set; }
        public int country_id { get; set; }
    }
}
