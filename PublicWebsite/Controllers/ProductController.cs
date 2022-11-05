using System.Web.Mvc;

namespace cheapdscin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
          return  Redirect("/CheapClass3Dsc");
        }
        public ActionResult CheapClass3IndividualSignature()
        {
			ViewBag.DisplayName = "Cheap Class 3 Individual Signature";
			ViewBag.LinkValue = "";

			ViewBag.CanonicalUri = "cheap-class3-individual-signature";
			ViewBag.desc = "Cheap Class 3 Individual Signature, Class 3 Individual Signature, Class 3 Individual Signature DSC";
			ViewBag.Title = "Cheap Class 3 Individual Signature, Class 3 Individual Signature";

			return View();
        }
		public ActionResult CheapClass3Dsc()
        {
            ViewBag.DisplayName = "Cheap Class 3 DSC";
            ViewBag.LinkValue = "";

            ViewBag.CanonicalUri = "product/CheapClass3Dsc";
            ViewBag.desc = "Class 3 DSC, Cheap Class 3 DSC, Cheap Class 3, Class 3 Digital Signature Certificate";
            ViewBag.Title = "Class 3 DSC, Cheap Class 3 DSC, Cheap Class 3, Class 3 Digital Signature Certificate";



            return View("CheapClass3Dsc");
        }

        public ActionResult CheapDgft()
        {
            ViewBag.DisplayName = "Cheap DGFT Certificate";
            ViewBag.LinkValue = "";

            ViewBag.CanonicalUri = "product/CheapDgft";
            ViewBag.desc = "Cheap DGFT Certificate, DFGT Certificate, Cheap DGFT";
            ViewBag.Title = "Cheap DGFT Certificate, DFGT Certificate, Cheap DGFT";

            return View("CheapDgft");
        }
        public ActionResult CheapUsbToken()
        {
            ViewBag.DisplayName = "Cheap USB Token";
            ViewBag.LinkValue = "";

            ViewBag.CanonicalUri = "/product/CheapUsbToken";
            ViewBag.desc = "Cheap Usb Token, Usb Token, Cheap Dsc Usb Token, DSC Usb Token";
            ViewBag.Title = "Cheap Usb Token, Usb Token, Cheap Dsc Usb Token, DSC Usb Token";
            
            return View("CheapUsbToken");
        }

    }
}