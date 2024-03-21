using System.Drawing;
using System;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using System.Net;
using System.Security.Policy;

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
			ViewBag.CanonicalUri = ("credit-card-to-cash-in-" + stateName?.Replace(" ", "-")).ToLower();

			ViewBag.desc = string.Format("Credit card to Cash in {0}, Cheap card to cash service in {0},credit card to instant cash in {0},credit card to Spot cash in {0}", ViewBag.DisplayName);
			ViewBag.Title = string.Format("Credit Card to Cash in {0} | Spot Cash on Credit Card in {0}", ViewBag.DisplayName);


			return View();
		}

		public ActionResult ClassDscIn(string stateName)
		{
			var prefix = "Class-3-DSC-in-";
			var desc = "Class 3 Dsc in {0}, Class 3 Dsc Sales in {0}, Class 3 Dsc near {0}";
			var title = "Class 3 Dsc in {0} | Class 3 Dsc Sales in {0} | Class 3 Dsc near {0}";
			ViewBag.pageType = "Dsc";
			ViewBag.CdnFolder = "Class3Individual";
			ViewBag.TestImage = CreateDemoCertificate(stateName, "/Banner/Class3.jpg", Color.DarkViolet, 30, 250, 225);
			return Process(prefix, desc, title, stateName, "Index", "599*");
		}

		public ActionResult CheapClassDscIn(string stateName)
		{
			var prefix = "cheap-Class-3-DSC-in-";
			var desc = "Cheap Class 3 Dsc in {0}, Cheap Class 3 Dsc Sales in {0}, Cheap Class 3 Dsc near {0}";
			var title = "Cheap Class 3 Dsc in {0} | Cheap Class 3 Dsc Sales in {0} | Cheap Class 3 Dsc near {0}";
			ViewBag.pageType = "Dsc";
			ViewBag.CdnFolder = "Class3Individual";
			ViewBag.TestImage = CreateDemoCertificate(stateName, "/Banner/Class3.jpg", Color.DarkViolet, 30, 250, 225);
			return Process(prefix, desc, title, stateName, "Index", "599*");
		}


		public ActionResult Dgft(string stateName)
		{
			var prefix = "Dgft-in-";
			var desc = "DGFT in {0}, DGFT Sales in {0}, DGFT near {0}";
			var title = "DGFT in {0} | DGFT Sales in {0} | DGFT near {0}";
			ViewBag.pageType = "Dgft";
			ViewBag.CdnFolder = "Class3Individual";
			ViewBag.TestImage = CreateDemoCertificate(stateName, "/Banner/Dgft.jpg", Color.DarkBlue, 30, 270, 350);
			return Process(prefix, desc, title, stateName, "Index", Models.PriceList.Dgft);
		}

		public ActionResult CheapDgft(string stateName)
		{
			var prefix = "cheap-DGFT-in-";
			var desc = "Cheap DGFT in {0}, Cheap DGFT Sales in {0}, Cheap DGFT near {0}";
			var title = "Cheap DGFT in {0} | Cheap DGFT Sales in {0} | Cheap DGFT near {0}";
			ViewBag.pageType = "Dgft";
			ViewBag.CdnFolder = "Class3Individual";
			ViewBag.TestImage = CreateDemoCertificate(stateName, "/Banner/Dgft.jpg", Color.DarkBlue, 30, 270, 350);
			return Process(prefix, desc, title, stateName, "Index", Models.PriceList.Dgft);
		}


		public ActionResult Usb(string stateName)
		{
			var prefix = "Usb-Token-in-";
			var desc = "Usb Token in {0}, Usb Token Sales in {0}, Usb Token near {0}";
			var title = "Usb Token in {0} | Usb Token Sales in {0} | Usb Token near {0}";
			ViewBag.pageType = "Usb";
			ViewBag.CdnFolder = "Class3Individual";
			ViewBag.TestImage = CreateDemoCertificate(stateName, "/Banner/UsbToken.jpg", Color.DarkBlue, 30, 250, 235);
			return Process(prefix, desc, title, stateName, "Index", "312*");
		}

		public ActionResult CheapUsb(string stateName)
		{
			var prefix = "cheap-Usb-Token-in-";
			var desc = "Cheap Usb Token in {0}, Cheap Usb Token Sales in {0}, Cheap Usb Token near {0}";
			var title = "Cheap Usb Token in {0} | Cheap Usb Token Sales in {0} | Cheap Usb Token near {0}";
			ViewBag.pageType = "Usb";
			ViewBag.CdnFolder = "Class3Individual";
			ViewBag.TestImage = CreateDemoCertificate(stateName, "/Banner/UsbToken.jpg", Color.DarkBlue, 30, 250, 235);
			return Process(prefix, desc, title, stateName, "Index", "312*");
		}





		private ActionResult Process(string prefix, string desc, string title, string stateName, string viewName, string price)
		{

			ViewBag.UriPrefix = prefix;
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
			ViewBag.CanonicalUri = (prefix + stateName?.Replace(" ", "-")).ToLower();

			ViewBag.desc = string.Format(desc, ViewBag.DisplayName);
			ViewBag.Title = string.Format(title, ViewBag.DisplayName);


			return View(viewName);
		}


		public string CreateDemoCertificate(string sText, string sampleFilePath, Color color, int fontSize = 30, int x = 250, int y = 225)
		{
			try
			{
				sampleFilePath = Helper.LoadCdn(sampleFilePath);

				using (var client = new WebClient())
				{
					var content = client.DownloadData(sampleFilePath);
					using (var stream = new MemoryStream(content))
					{

						using (Bitmap oBitmap = new Bitmap(Image.FromStream(stream)))
						{
							Graphics oGraphic = Graphics.FromImage(oBitmap);

							PointF oPoint = default(PointF);
							SolidBrush oBrushBlack = new SolidBrush(color);
							Font oFont = new Font("Arial", fontSize, FontStyle.Bold);

							oPoint = new PointF(x, y);
							oGraphic.DrawString(sText, oFont, oBrushBlack, oPoint);

							using (MemoryStream memory = new MemoryStream())
							{
								oBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
								byte[] bytesArray = memory.ToArray();
								return Convert.ToBase64String(bytesArray, 0, bytesArray.Length);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				return sampleFilePath;
			}
			return string.Empty;
		}

	
	}
}