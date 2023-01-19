using System;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Web.Mvc;

namespace cheapdscin.Controllers
{
	public class ImageController : Controller
	{

		public FileResult Index(string product = "", string location = "")
		{
			var fileName = "";
			if (string.IsNullOrEmpty(location))
				location = "India";
			else
				location = string.Join(" ", location.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries));

			MemoryStream op;
			switch (product?.ToLower() ?? "")
			{
				case "dsc":
					{
						fileName = "/Banner/Class3.jpg";
						op = CreateDemoCertificate(location, fileName, Color.DarkViolet, 30, 250, 225);
						break;
					}
				case "dgft":
					{
						fileName = "/Banner/Dgft.jpg";
						op = CreateDemoCertificate(location, fileName, Color.DarkBlue, 30, 270, 350);
						break;
					}
				case "usb":
					{
						fileName = "/Banner/UsbToken.jpg";
						op = CreateDemoCertificate(location, fileName, Color.DarkBlue, 30, 250, 235);
						break;
					}
				default:
					{
						fileName = "/Page/HomeSlider/Banner1.jpg";
						op = CreateDemoCertificate(location, fileName, Color.DarkBlue, 30, 270, 350, true);
						break;
					}
			}

			op.Position = 0;
			return File(op, "image/jpg");
		}

		public MemoryStream CreateDemoCertificate(string sText, string sampleFilePath, Color color, int fontSize = 30, int x = 250, int y = 225, bool ignoreText = false)
		{
			MemoryStream memory;
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
							if (!ignoreText)
								oGraphic.DrawString(sText, oFont, oBrushBlack, oPoint);

							memory = new MemoryStream();
							oBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
							//byte[] bytesArray = memory.ToArray();
							//return Convert.ToBase64String(bytesArray, 0, bytesArray.Length);

							return memory;

						}
					}
				}
			}
			catch (Exception ex)
			{
				return new MemoryStream() { Position = 0 };
			}
		}
	}
}