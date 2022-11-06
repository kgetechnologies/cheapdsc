using System.Web.Mvc;

namespace cheapdscin.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			ViewBag.DisplayName = "India";
			ViewBag.LinkValue = "Home";

			ViewBag.CanonicalUri = "";
			ViewBag.desc = "Cheap DSC, Cheap Class 3 DSC, Class 3 DSC, DGFT Certificate, Usb Token";
			ViewBag.Title = "Cheap DSC, Cheap Class 3 DSC, Class 3 DSC, DGFT Certificate, Usb Token";

		//	Resources.Get.Content();
			return View();
		}

		public ActionResult AboutUs()
		{
			
			ViewBag.DisplayName = "About";
			ViewBag.LinkValue = "About";

			ViewBag.CanonicalUri = "About";
			ViewBag.desc = "About Instant Dsc | About Spot DSC | About Class 3 DSC | About DGFT | About USB Token";
			ViewBag.Title = "About Instant Dsc | About Spot DSC | About Class 3 DSC | About DGFT | About USB Token";
			return View();
		}

		public ActionResult ContactUs()
		{
			ViewBag.DisplayName = "Contact Us";
			ViewBag.LinkValue = "ContactUs";

			ViewBag.CanonicalUri = "ContactUs";
			ViewBag.desc = "Contact Us | Contact Cheap Dsc | Contact Cheap Usb Token | Contact Cheap DGFT";
			ViewBag.Title = "Contact Us | Contact Cheap Dsc | Contact Cheap Usb Token";
			return View();
		}
        [HttpPost]
		public ActionResult ContactUsForm()
		{
			var req = this.Request;
			var a = req.Form;
			ViewBag.DisplayName = "Contact";
			ViewBag.LinkValue = "Contact";

			ViewBag.CanonicalUri = "contact";
			ViewBag.desc = "Contact Instant Dsc | Contact Spot DSC | Contact Class 3 DSC | Contact DGFT | Contact USB Token";
			ViewBag.Title = "Contact Instant Dsc | Contact Spot DSC | Contact Class 3 DSC | Contact DGFT | Contact USB Token";
			return View();
		}

		public ActionResult Error()
		{
			ViewBag.DisplayName = "Error";
			ViewBag.LinkValue = "Error";

			ViewBag.CanonicalUri = "home/error";
			ViewBag.desc = "Error page on Cheap DSC, cheapdsc.com error page";
			ViewBag.Title = "Error page on Cheap DSC, cheapdsc.com error page";
			return View();
		}

		public ActionResult NotFound()
		{
			ViewBag.DisplayName = "Not Found";
			ViewBag.LinkValue = "Not Found";

			ViewBag.CanonicalUri = "home/notfound";
			ViewBag.desc = "Page Not found on Cheap DSC, cheapdsc.com Page Not found";
			ViewBag.Title = "Page Not found on Cheap DSC, cheapdsc.com Page Not found";
			return View();
		}
	}
}