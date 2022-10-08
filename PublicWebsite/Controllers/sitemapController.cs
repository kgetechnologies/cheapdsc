using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace cheapdscin.Controllers
{
	public class sitemapController : Controller
	{
		// GET: sitemap
		public ActionResult Index(string id)
		{
			var op = new List<SitemapNode>();
			if (string.IsNullOrEmpty(id))
			{
				var citiesList = Pages();
				op = citiesList.Select(f => new SitemapNode()
				{
					Frequency = SitemapFrequency.Daily,
					LastModified = DateTime.UtcNow.AddDays(-1),
					Priority = 0.8,
					Url = $"https://www.cheapdsc.com{f}"
				}).ToList();
			}
			else
			{
				op = GenerateForProductPages(op, id);
			}
			
			return this.Content(GetSitemapDocument(op), "application/xml", Encoding.UTF8);
		}

		private List<SitemapNode> GenerateForProductPages(List<SitemapNode> op,string id)
		{
			var uri = string.Empty;//Class-3-dsc-in-
			switch (id)
			{
				case "ClassDscIn":
					{
						uri = "Class-3-dsc-in-";
						break;
					}
				case "CheapClassDscIn":
					{
						uri = "cheap-Class-3-dsc-in-";
						break;
					}
				case "CheapDgft":
					{
						uri = "cheap-dgft-in-";
						break;
					}
				case "Dgft":
					{
						uri = "dgft-in-";
						break;
					}
				case "CheapUsb":
					{
						uri = "cheap-usb-token-in-";
						break;
					}
				case "Usb":
					{
						uri = "usb-token-in-";
						break;
					}
			}
			if (!string.IsNullOrEmpty(uri))
			{
				foreach (var eachState in Helper.States)
				{
					op.Add(new SitemapNode()
					{
						Frequency = SitemapFrequency.Daily,
						LastModified = DateTime.UtcNow.AddDays(-1),
						Priority = 0.8,
						Url = $"https://www.cheapdsc.com/{uri}{eachState.Key}"
					});

					foreach (var eachCity in Helper.CitiesByStateName(eachState.Key,uri))
					{
						op.Add(new SitemapNode()
						{
							Frequency = SitemapFrequency.Daily,
							LastModified = DateTime.UtcNow.AddDays(-1),
							Priority = 0.8,
							Url = $"https://www.cheapdsc.com{eachCity.Key}"
						});
					}
				}
			}

			return op;
		}

		public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
		{
			XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
			XElement root = new XElement(xmlns + "urlset");

			foreach (SitemapNode sitemapNode in sitemapNodes)
			{
				XElement urlElement = new XElement(
					xmlns + "url",
					new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
					sitemapNode.LastModified == null ? null : new XElement(
						xmlns + "lastmod",
						sitemapNode.LastModified.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
					sitemapNode.Frequency == null ? null : new XElement(
						xmlns + "changefreq",
						sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
					sitemapNode.Priority == null ? null : new XElement(
						xmlns + "priority",
						sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
				root.Add(urlElement);
			}

			XDocument document = new XDocument(root);
			return document.ToString();
		}

		public List<String> Pages()
		{
			return new List<string>()
			{
				"/",
				"/contact",
				"/about",
				"/product/CheapClass3Dsc",
				"/product/CheapDgft",
				"/product/CheapUsbToken",
				"/Cheap-class-3-dsc-in-India",
				"/Cheap-Dgft-in-India",
				"/Cheap-usb-token-in-India",
			};

		}
	}

	public class SitemapNode
	{
		public SitemapFrequency? Frequency { get; set; }
		public DateTime LastModified { get; set; }
		public double? Priority { get; set; }
		public string Url { get; set; }
	}

	public enum SitemapFrequency
	{
		Never,
		Yearly,
		Monthly,
		Weekly,
		Daily,
		Hourly,
		Always
	}
}