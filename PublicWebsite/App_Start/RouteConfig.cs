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
			 new[] { "Card2cashin.Controllers" }
		);

			routes.MapRoute(
			name: "about",
			url: "about",
			defaults: new { controller = "Home", action = "about", id = UrlParameter.Optional },
			 new[] { "Card2cashin.Controllers" }
		);

			//	routes.MapRoute(
			//	name: "state",
			//	url: "credit-card-to-cash-in-{stateName}",
			//	defaults: new { controller = "state", action = "Index", stateName = UrlParameter.Optional },
			//new[] { "Card2cashin.Controllers" }
		//);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
			 new[] { "Card2cashin.Controllers" }
			);
		}
	}
}
