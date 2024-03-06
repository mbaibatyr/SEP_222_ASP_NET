using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperToObjects.Model
{
    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<City> city { get; set; }

    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public int country_id { get; set; }

        public static implicit operator List<object>(City v)
        {
            throw new NotImplementedException();
        }
    }
}
