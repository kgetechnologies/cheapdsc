using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cheapdscin
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			//routes.RouteExistingFiles = true;

			//	routes.IgnoreRoute("");

			routes.MapRoute(
			name: "contact",
			url: "contact",
			defaults: new { controller = "Home", action = "contact", id = UrlParameter.Optional },
			 new[] { "cheapdscin.Controllers" }
		);

			routes.MapRoute(
			name: "about",
			url: "about",
			defaults: new { controller = "Home", action = "about", id = UrlParameter.Optional },
			 new[] { "cheapdscin.Controllers" }
		);

			routes.MapRoute(
		name: "sitemap",
		url: "sitemap/{id}",
		defaults: new { controller = "sitemap", action = "Index", id = UrlParameter.Optional },
		 new[] { "cheapdscin.Controllers" }
	);


			Register(routes, "state1", "Class-3-dsc-in-{stateName}", "ClassDscIn");

			Register(routes, "state2", "cheap-Class-3-dsc-in-{stateName}", "CheapClassDscIn");

			Register(routes, "state3", "cheap-dgft-in-{stateName}", "CheapDgft");

			Register(routes, "state4", "dgft-in-{stateName}", "Dgft");

			Register(routes, "state5", "cheap-usb-token-in-{stateName}", "CheapUsb");

			Register(routes, "state6", "usb-token-in-{stateName}", "Usb");


			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
			 new[] { "cheapdscin.Controllers" }
			);
		}

		private static void Register(RouteCollection routes, string routeName, string customUrl, string actionMethod)
		{
			routes.MapRoute(
				name: routeName,
				url: customUrl,
				defaults: new { controller = "state", action = actionMethod, stateName = UrlParameter.Optional },
			 new[] { "cheapdscin.Controllers" }
			);


			//	routes.MapRoute(
			//	name: "state",
			//	url: "credit-card-to-cash-in-{stateName}",
			//	defaults: new { controller = "state", action = "Index", stateName = UrlParameter.Optional },
			//new[] { "Card2cashin.Controllers" }
			//);
		}
	}
}
