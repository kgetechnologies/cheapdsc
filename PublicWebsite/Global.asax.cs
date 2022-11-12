using System.Globalization;
using System.Threading;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using cheapdscin.Models;
using cheapdscin.Resources;
using System.Text.RegularExpressions;

namespace cheapdscin
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			Resources.Get.GetAssembly = Assembly.GetExecutingAssembly();

			Languages.AvailableList = new System.Collections.Generic.Dictionary<int, string>();
			Languages.AvailableList.Add(0, "en-US");
			Languages.AvailableList.Add(1, "en-US");
		}

		//protected void Appl(object sender, EventArgs e)
		//{
		//	CultureInfo ci = new CultureInfo("en-US");
		//	Thread.CurrentThread.CurrentUICulture = ci;
		//	Thread.CurrentThread.CurrentCulture = ci;
		//}

		protected void Session_Start(object sender,EventArgs e)
		{
			CultureHelper.CurrentCulture = 0;
		}
	}
}
