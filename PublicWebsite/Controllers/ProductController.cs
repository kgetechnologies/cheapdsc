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
        public ActionResult CheapClass3Dsc()
        {
            ViewBag.DisplayName = "Credit Card to Cash Support & Services";
            ViewBag.LinkValue = "";

            ViewBag.CanonicalUri = "Services on ";
            ViewBag.desc = "Services on  Instant Cash on Credit Card | Services on  Spot Cash on Credit Card | Services on  Credit Card to Cash | Services on  Cash on Credit card";
            ViewBag.Title = "Services on  Instant Cash | Services on  Spot Cash | Services on  Credit Card to Cash | Services on  Cash on Credit Card";



            return View("CheapClass3Dsc");
        }

        public ActionResult CheapDgft()
        {
            ViewBag.DisplayName = "Instant Cash on Credit Card";
            ViewBag.LinkValue = "";

            ViewBag.CanonicalUri = "/services/InstantCashOnCreditCard";
            ViewBag.desc = "Instant Cash on Credit Card | Instant Cash on Card | Credit Card Instant Cash | Card to Instant Cash";
            ViewBag.Title = "Instant Cash on Credit Card | Instant Cash on Card | Credit Card Instant Cash | Card to Instant Cash";

            return View("CheapDgft");
        }
        public ActionResult CheapUsbToken()
        {
            ViewBag.DisplayName = "Spot Cash on Credit Card";
            ViewBag.LinkValue = "";

            ViewBag.CanonicalUri = "/services/InstantCashOnCreditCard";
            ViewBag.desc = "Spot Cash on Credit Card | Spot Cash on Card | Credit Card Spot Cash | Card to Spot Cash";
            ViewBag.Title = "Spot Cash on Credit Card | Spot Cash on Card | Credit Card Spot Cash | Card to Spot Cash";
            
            return View("CheapUsbToken");
        }

    }
}