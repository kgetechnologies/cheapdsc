using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cheapdscin.Models
{
	public class ContactUs
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string ContactNumber { get; set; }
		public int ZipCode { get; set; }
		public Products Product { get; set; }
		public bool AlreadyHavingUsbToken { get; set; }
		public string Message { get; set; }
		public bool Agreed { get; set; }
	}
}