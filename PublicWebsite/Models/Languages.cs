using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cheapdscin.Models
{
	public class Languages
	{
		public static Dictionary<int,string> AvailableList { get; set; }
	}
}