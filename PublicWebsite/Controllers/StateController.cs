using System.Web.Mvc;

namespace cheapdscin.Controllers
{
	public class StateController : Controller
    {
       
        public ActionResult Index(string stateName)
        {

            var prefix = "credit-card-to-cash-in-";
            if (stateName?.ToLower().StartsWith(prefix)??false) {
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
    }
}