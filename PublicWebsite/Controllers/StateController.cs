using System.Globalization;
using System.Web.Mvc;

namespace cheapdscin.Controllers
{
	public class StateController : Controller
	{

		public ActionResult Index(string stateName)
		{

			var prefix = "credit-card-to-cash-in-";
			if (stateName?.ToLower().StartsWith(prefix) ?? false)
			{
				stateName = stateName.Replace(prefix, "");
			}
			ViewBag.DisplayName = stateName?.Replace("-", " ");
			ViewBag.LinkValue = stateName?.Replace(" ", "-");
			ViewBag.Id = Helper.GetIdByName(stateName);
			ViewBag.CanonicalUri = "credit-card-to-cash-in-" + ViewBag.LinkValue;

			ViewBag.desc = string.Format("Credit card to Cash in {0}, Cheap card to cash service in {0},credit card to instant cash in {0},credit card to Spot cash in {0}", ViewBag.DisplayName);
			ViewBag.Title = string.Format("Credit Card to Cash in {0} | Spot Cash on Credit Card in {0}", ViewBag.DisplayName);


			return View();
		}

		public ActionResult ClassDscIn(string stateName)
		{
			var prefix = "Class-3-dsc-in-";
			var desc = "Class 3 Dsc in {0}, Cheap Class 3 Dsc Sales in {0}, Cheap Dsc in {0}";
			var title = "Class 3 Dsc in {0} | Cheap Class 3 Dsc Sales in {0} | Cheap Dsc in {0}";
			ViewBag.pageType = "Dsc";

			return Process(prefix, desc, title, stateName, "Index", "599*");
		}

		public ActionResult CheapClassDscIn(string stateName)
		{
			var prefix = "cheap-Class-3-dsc-in-";
			var desc = "Cheap Class 3 Dsc in {0}, Class 3 Dsc Sales in {0}, Cheap Dsc in {0}, Cheap Class 3 Dsc near {0}";
			var title = "Cheap Class 3 Dsc in {0} | Class 3 Dsc Sales in {0} | Cheap Dsc in {0} | Cheap Class 3 Dsc near {0}";
			ViewBag.pageType = "Dsc";

			return Process(prefix, desc, title, stateName, "Index", "599*");
		}


		private ActionResult Process(string prefix, string desc, string title, string stateName, string viewName, string price)
		{
			ViewBag.PageTitle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((prefix + stateName)?.Replace("-", " "));

			ViewBag.Prefix = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(prefix?.Replace("-in-", "")?.Replace("-", " "));

			ViewBag.Price = price;
			if (stateName?.ToLower().StartsWith(prefix) ?? false)
			{
				stateName = stateName.Replace(prefix, "");
			}

			ViewBag.DisplayName = stateName?.Replace("-", " ");
			ViewBag.LinkValue = stateName?.Replace(" ", "-");
			ViewBag.Id = Helper.GetIdByName(stateName);
			ViewBag.CanonicalUri = prefix + ViewBag.LinkValue;

			ViewBag.desc = string.Format(desc, ViewBag.DisplayName);
			ViewBag.Title = string.Format(title, ViewBag.DisplayName);


			return View(viewName);
		}
	}
}