using System;
using System.Web;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;

namespace cheapdscin.Resources
{
	public class Get
	{
		internal static Assembly GetAssembly { get; set; }
		public static string UserLanguage
		{
			get
			{
				HttpCookie cookieObj = HttpContext.Current.Request.Cookies?["UserLang"];
				string val = cookieObj?["UserLang"];
				if (!string.IsNullOrEmpty(val))
				{
					HttpCookie cookie = new HttpCookie("UserLang");
					cookie["UserLang"] = "EN";
					cookie.Expires = DateTime.Now.AddMonths(1);
					HttpContext.Current.Response.Cookies.Add(cookie);
					return "EN";
				}

				return val;
			}
		}
		//public static string Content(string key, string defaultvalue, string lang)
		public static string Content(string key, string defaultValue, string userLanguage = "")
		{
			return defaultValue;

			//userLanguage = string.IsNullOrEmpty(userLanguage) ? (CultureInfo.CurrentCulture?.Name ?? "en-US") : userLanguage;

			//var val = GetContent(userLanguage, key);
			//if (userLanguage != "en-US" && string.IsNullOrEmpty(val))
			//{
			//	val = GetContent("en-US", key);
			//}
			//if (string.IsNullOrEmpty(val))
			//	return defaultValue;

			//return val;

		}

		private static string GetContent(string lang, string key)
		{
			ResourceManager rm = new ResourceManager($"cheapdscin.ResourceFile.{lang}", GetAssembly);
			return rm.GetString(key);
		}
	}
}