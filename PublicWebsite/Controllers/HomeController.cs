using System;
using System.Net.Http;
using System.Threading.Tasks;
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
		[ValidateAntiForgeryToken]
		public async Task<JsonResult> ContactUsForm()
		{
			var req = this.Request;
			var form = req.Form;
            try
            {
				var model = new Models.ContactUs()
				{
					Name = form["Name"]?.ToString() ?? "",
					Email = form["Email"]?.ToString() ?? "",
					ContactNumber = form["ContactNumber"]?.ToString() ?? "",
					Message = form["Message"]?.ToString() ?? "",
					ZipCode = Convert.ToInt32(form["ZipCode"]?.ToString() ?? "0"),
					AlreadyHavingUsbToken = form["AlreadyHavingUsbToken"]?.ToString()?.ToLower()?.Contains("true") ?? false,
					Agreed = form["Agreed"]?.ToString()?.ToLower()?.Contains("true") ?? false,
					Product = (Models.Products)Convert.ToInt32(form["Product"].ToString())
				};
				var usbStatus = model.AlreadyHavingUsbToken ? "Yes" : "No";
				var paymentMsg = ($"\n\n*Customer Details*" +
			  $"\nName: {model?.Name}" +
			  $"\nLooking for Product: *{model?.Product.ToString()}*" +
			  $"\nContact Number: *{model?.ContactNumber}*" +
				$"\nEmail: *{model?.Email}*" +
			  $"\nMessage: {model?.Message}" +
			  $"\nAlready Having USB Token: *{usbStatus}*" +
			  $"\nZipCode: *{model?.ZipCode}*");
				var whatsAppMsg =
				$"CheapDSC New Enquired Via Website {paymentMsg}";
				Helper.RunAsync(paymentMsg, "Cheap DSC Enquiry");
				var sent = Helper.TriggerWhatsApp(whatsAppMsg);
				ViewBag.DisplayName = "Contact";
				ViewBag.LinkValue = "Contact";

				ViewBag.CanonicalUri = "contact";
				ViewBag.desc = "Contact Instant Dsc | Contact Spot DSC | Contact Class 3 DSC | Contact DGFT | Contact USB Token";
				ViewBag.Title = "Contact Instant Dsc | Contact Spot DSC | Contact Class 3 DSC | Contact DGFT | Contact USB Token";
				return Json(new { Status = sent }, JsonRequestBehavior.AllowGet);
			}
            catch (Exception ex)
            {
				Helper.RunAsync(ex.Message, "Cheap DSC ContactUsForm Exception");			
            }
			return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
		}

		private async Task<bool> TriggerWhatsApp(string message)
		{
			try
			{
				var param = string.Format("https://api.callmebot.com/whatsapp.php?phone=+919498393812&apikey={0}&text={1}", Helper.ReadAppSettings("WhatsAppURLKey"), message);

				using (var client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(param);
				}
				return true;
			}
			catch (Exception ex)
			{
				//TODO: send email to kge gmail
				return false;
			}
			finally
			{

			}

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