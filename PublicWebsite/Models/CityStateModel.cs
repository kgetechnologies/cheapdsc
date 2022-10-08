using Microsoft.SqlServer.Server;
using System.Collections.Generic;

namespace cheapdscin.Models
{  
    public class City: LocationBase
	{
      
    }

    public class CityStateModel: LocationBase
	{
        public string state_code { get; set; }
        public List<City> cities { get; set; }
    }

    public class LocationBase
    {
		public string name { get; set; }
		public string id { get; set; }
	}


    public class StateGroupByAlpha
    {
        public string Alpha { get; set; }
        public Dictionary<string, string> Locations { get; set; }
	}
}