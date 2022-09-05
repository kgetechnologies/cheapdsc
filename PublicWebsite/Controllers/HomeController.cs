using System.Web.Mvc;

namespace cheapdscin.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.DisplayName = "India";
			ViewBag.LinkValue = "Home";

			ViewBag.CanonicalUri = "";
			ViewBag.desc = "Instant Cash on Credit Card | Spot Cash on Credit Card | Credit Card to Cash | Cash on Credit card";
			ViewBag.Title = "Instant Cash | Spot Cash | Credit Card to Cash | Cash on Credit Card";


			return View();
		}

		public ActionResult About()
		{
			
			ViewBag.DisplayName = "About";
			ViewBag.LinkValue = "About";

			ViewBag.CanonicalUri = "About";
			ViewBag.desc = "About Instant Cash on Credit Card | About Spot Cash on Credit Card | About Credit Card to Cash | About Cash on Credit card";
			ViewBag.Title = "About Instant Cash | About Spot Cash | About Credit Card to Cash | About Cash on Credit Card";
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.DisplayName = "Contact";
			ViewBag.LinkValue = "Contact";

			ViewBag.CanonicalUri = "contact";
			ViewBag.desc = "Contact Instant Cash on Credit Card | Contact Spot Cash on Credit Card | Contact Credit Card to Cash | Contact Cash on Credit card";
			ViewBag.Title = "Contact Instant Cash | Contact Spot Cash | Contact Credit Card to Cash | Contact Cash on Credit Card";
			return View();
		}

		public ActionResult Error()
		{
			ViewBag.DisplayName = "Error";
			ViewBag.LinkValue = "Error";

			ViewBag.CanonicalUri = "home/error";
			ViewBag.desc = "Error page on Credit card to Cash, card2cash.in error page";
			ViewBag.Title = "Credit card to cash Error page, card2cash.in error page";
			return View();
		}

		public ActionResult NotFound()
		{
			ViewBag.DisplayName = "Not Found";
			ViewBag.LinkValue = "Not Found";

			ViewBag.CanonicalUri = "home/notfound";
			ViewBag.desc = "Not Found page on Credit card to Cash, card2cash.in Not Found page";
			ViewBag.Title = "Credit card to cash Not Found page, card2cash.in Not Found page";
			return View();
		}
	}
}