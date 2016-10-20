using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrains.Core.Model
{
    public class City : BaseModel
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public override string ToString()
        {
            return CityName;
        }
    }
}
