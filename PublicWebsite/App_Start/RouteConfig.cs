﻿using Microsoft.Win32;
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
		
			Register(routes, "state1", "Class-3-dsc-in-{stateName}", "Index");

			Register(routes, "state2", "cheap-Class-3-dsc-in-{stateName}", "Index");

			Register(routes, "state3", "cheap-dgft-in-{stateName}", "Index");

			Register(routes, "state4", "dgft-in-{stateName}", "Index");

			Register(routes, "state5", "cheap-usb-token-in-{stateName}", "Index");

			Register(routes, "state6", "usb-token-in-{stateName}", "Index");


			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
			 new[] { "cheapdscin.Controllers" }
			);
		}

		private static void Register(RouteCollection routes, string name, string url, string action)
		{
			routes.MapRoute(
				name: name,
				url: url,
				defaults: new { controller = "state", action = action, id = UrlParameter.Optional },
			 new[] { "cheapdscin.Controllers" }
			);
		}
	}
}
