using cheapdscin.Models;
using System;
using System.Collections.Specialized;
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
        public JsonResult ContactUsForm()
        {
            var req = this.Request;
            var form = req.Form;
            var model = new Models.ContactUs();
            try
            {
                var _product = ReadFormPropertyValue(form, "Product");
                bool sent = false;
                if (!string.IsNullOrEmpty(_product) && Enum.TryParse(_product, out Models.Products product))
                {
                    model.Name = ReadFormPropertyValue(form, "Name");
                    model.Email = ReadFormPropertyValue(form, "Email");
                    model.ContactNumber = ReadFormPropertyValue(form, "ContactNumber");
                    model.Message = ReadFormPropertyValue(form, "Message");
                    model.ZipCode = Convert.ToInt32(ReadFormPropertyValue(form, "ZipCode", "0"));
                    model.AlreadyHavingUsbToken = ReadFormPropertyValue(form, "AlreadyHavingUsbToken", "false").ToLower()?.Contains("true") ?? false;
                    model.Agreed = ReadFormPropertyValue(form, "Agreed", "false").ToLower()?.Contains("true") ?? false;
                    model.Product = product;

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
                    sent = Helper.TriggerWhatsApp(whatsAppMsg);
                }


                ViewBag.DisplayName = "Contact";
                ViewBag.LinkValue = "Contact";

                ViewBag.CanonicalUri = "contact";
                ViewBag.desc = "Contact Instant Dsc | Contact Spot DSC | Contact Class 3 DSC | Contact DGFT | Contact USB Token";
                ViewBag.Title = "Contact Instant Dsc | Contact Spot DSC | Contact Class 3 DSC | Contact DGFT | Contact USB Token";
                return Json(sent, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var msg = $"{ex.Message}</br/>{Newtonsoft.Json.JsonConvert.SerializeObject(model)}<br />{Newtonsoft.Json.JsonConvert.SerializeObject(form)}";
                Helper.RunAsync(msg, "Cheap DSC ContactUsForm Exception");
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        private string ReadFormPropertyValue(NameValueCollection form, string key, string defaultValue = "")
        {
            return form[key]?.ToString() ?? defaultValue;
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