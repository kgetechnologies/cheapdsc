
using cheapdscin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace cheapdscin
{
	public class Helper
	{
		private const string CdnDomain = "https://raw.githubusercontent.com/kgetechnologies/cdn.cheapdsc.com/main{0}";
		public static string ReadAppSettings(string key, string value = "")
		{
			var val = ConfigurationManager.AppSettings[key];
			if (string.IsNullOrEmpty(val))
			{
				//	Logger.Error($"AppSettings Value is Not Valid for {key}");
			}
			return val;
		}

		public static bool TriggerWhatsApp(string message)
		{
			try
			{
				var param = string.Format("https://api.callmebot.com/whatsapp.php?phone=+919498393812&apikey={0}&text={1}", ReadAppSettings("WhatsAppURLKey"), message);

				using (var client = new HttpClient())
				{
					HttpResponseMessage response = client.GetAsync(param).Result;
				}
			}
			catch (Exception ex)
			{
				// Logger.Error("TriggerWhatsApp", ex);
				RunAsync(ex.Message, "Whatsapp Message Exception");
			}
			finally
			{
			}
			return true;
		}

		public static bool RunAsync(string message, string subject, string To = "kgetechnologies@gmail.com", List<string> CCMail = null, List<string> BccMail = null)
		{
			try
			{
				using (SmtpClient SmtpServer = new SmtpClient("mail.kgetechnologies.com"))
				{
					MailMessage mail = new MailMessage();
					mail.IsBodyHtml = true;
					mail.From = new MailAddress("monitoring@kgetechnologies.com");
					mail.To.Add(To);
					if (CCMail != null && CCMail.Count > 0)
						foreach (string cc in CCMail.Where(x => !string.IsNullOrEmpty(x)))
							mail.CC.Add(cc);

					if (BccMail != null && BccMail.Count > 0)
						foreach (string Bcc in BccMail.Where(x => !string.IsNullOrEmpty(x)))
							mail.Bcc.Add(Bcc);

					mail.Subject = subject;
					mail.Body = message;

					SmtpServer.Port = 587;
					SmtpServer.Credentials = new System.Net.NetworkCredential("monitoring@kgetechnologies.com", "Test11!!");
					SmtpServer.EnableSsl = false;


					SmtpServer.Send(mail);//.Wait();
				}
			}
			catch (Exception ex)
			{
				//Logger.Error("Email exception", ex);
			}
			return true;
		}

		public static List<StateGroupByAlpha> StatesGroupedByAlphabet
		{
			get
			{
				var grp = States.GroupBy(f => f.Key.Substring(0, 1));
				var op = new List<StateGroupByAlpha>();
				foreach (var g in grp)
				{
					var val = States.Where(w => w.Key.StartsWith(g.Key)).ToDictionary(s => s.Key, y => y.Value);
					op.Add(new StateGroupByAlpha() { Alpha = g.Key, Locations = val });
				}
				return op;
			}
		}
		public static Dictionary<string, String> States
		{
			get
			{
				var op = new Dictionary<string, String>();
				op.Add("Andaman-and-Nicobar-Islands", "Andaman and Nicobar Islands");
				op.Add("Andhra-Pradesh", "Andhra Pradesh");
				op.Add("Arunachal-Pradesh", "Arunachal Pradesh");
				op.Add("Assam", "Assam");
				op.Add("Bihar", "Bihar");
				op.Add("Chandigarh", "Chandigarh");
				op.Add("Chhattisgarh", "Chhattisgarh");
				op.Add("Dadra-and-Nagar-Haveli-and-Daman-and-Diu", "Dadra and Nagar Haveli and Daman and Diu");
				op.Add("Delhi", "Delhi");
				op.Add("Goa", "Goa");
				op.Add("Gujarat", "Gujarat");
				op.Add("Haryana", "Haryana");
				op.Add("Himachal-Pradesh", "Himachal Pradesh");
				op.Add("Jammu-and-Kashmir", "Jammu and Kashmir");
				op.Add("Jharkhand", "Jharkhand");
				op.Add("Karnataka", "Karnataka");
				op.Add("Kerala", "Kerala");
				op.Add("Ladakh", "Ladakh");
				op.Add("Lakshadweep", "Lakshadweep");
				op.Add("Madhya-Pradesh", "Madhya Pradesh");
				op.Add("Maharashtra", "Maharashtra");
				op.Add("Manipur", "Manipur");
				op.Add("Meghalaya", "Meghalaya");
				op.Add("Mizoram", "Mizoram");
				op.Add("Nagaland", "Nagaland");
				op.Add("Odisha", "Odisha");
				op.Add("Puducherry", "Puducherry");
				op.Add("Punjab", "Punjab");
				op.Add("Rajasthan", "Rajasthan");
				op.Add("Sikkim", "Sikkim");
				op.Add("Tamil-Nadu", "Tamil Nadu");
				op.Add("Telangana", "Telangana");
				op.Add("Tripura", "Tripura");
				op.Add("Uttar-Pradesh", "Uttar Pradesh");
				op.Add("Uttarakhand", "Uttarakhand");
				op.Add("West-Bengal", "West Bengal");
				return op;
			}
		}
		public static KeyValuePair<string, string> DisplayTitle(string stateName)
		{
			stateName = stateName ?? "Tamil Nadu";

			var IsState = States.Keys.Any(f => f.ToLower() == stateName.ToLower()) || States.Values.Any(f => f.ToLower() == stateName.ToLower());
			if (IsState)
			{
				return new KeyValuePair<string, string>("", string.Format("Areas In My {0} State", stateName));
			}
			else
			{
				var data = GetStateByCache();
				var CityStateName = data?.FirstOrDefault(x => x.cities.Any(y => y.name?.ToLower() == stateName?.ToLower()))?.name;
				if (string.IsNullOrEmpty(CityStateName))
				{
					if (data != null)
					{
						int len = stateName.Length;
						do
						{
							var searchText = stateName.ToLower().Clone().ToString().Substring(0, len--);
							if (data.Any(x => x.cities.Any(y => y.name.ToLower().StartsWith(searchText))))
							{
								CityStateName = data.FirstOrDefault(x => x.cities.Any(y => y.name.ToLower().StartsWith(searchText))).name;
								return new KeyValuePair<string, string>(CityStateName, string.Format("Servicing area's near by {0}", stateName)); ;
							}
						} while (len > 0);
					}

					CityStateName = "your Area";
				}
				return new KeyValuePair<string, string>(CityStateName, string.Format("Servicing area's near by {0}", stateName));
			}

		}
		internal static List<CityStateModel> LoadJson()
		{
			List<CityStateModel> op = new List<CityStateModel>();
			using (StreamReader sr = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/states-cities.json")))
			{
				op = JsonConvert.DeserializeObject<List<CityStateModel>>(sr.ReadToEnd());
			}
			return op;
		}
		public static string GetIdByName(string stateName)
		{
			stateName = stateName?.Replace(" ", "-")?.ToLower();
			List<CityStateModel> op = GetStateByCache();
			var id = op?.FirstOrDefault(f => f.name.Replace(" ", "-").ToLower() == stateName)?.id ?? "";
			if (string.IsNullOrEmpty(id))
				id = op.SelectMany(x => x.cities?.Where(f => !string.IsNullOrEmpty(f.name) && f.name?.Replace(" ", "-").ToLower() == stateName))?.FirstOrDefault()?.id ?? "";
			return id;
		}
		public static Dictionary<string, City> CitiesByStateName(string stateName, string uriPrefix = "cheap-Class-3-dsc-in-")
		{
			List<CityStateModel> op = GetStateByCache();
			var result = new Dictionary<string, City>();

			if (op == null || !op.Any())
				return result;

			if (!string.IsNullOrEmpty(stateName))
			{
				op.ForEach(f =>
				{
					f.name = RemoveSpecialCharacters(f.name);
					if (f.name.Replace(" ", "-").ToLower() == stateName.ToLower())
					{
						if (f.cities != null && f.cities.Any())
						{
							f.cities.ForEach(c =>
							{
								c.name = RemoveSpecialCharacters(c.name);
							});
						}
					}
				});

				var op1 = op.FirstOrDefault(f => f.name.Replace(" ", "-").ToLower() == stateName.Replace(" ", "-").ToLower())?.cities;
				if (op1 != null)
				{
					op1.ForEach(a =>
					{
						var key = $"/{uriPrefix}{a.name.Replace(" ", "-")}";
						if (!result.ContainsKey(key))
							result.Add(key, a);
					});
				}
			}
			return result;
		}

		private static string RemoveSpecialCharacters(string input)
		{
			Regex r = new Regex("(?:[^a-zA-Z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
			return r.Replace(input, String.Empty);
		}
		public static List<CityStateModel> GetStateByCache()
		{
			var CacheKey = "StateJson";
			ObjectCache cache = MemoryCache.Default;

			if (cache.Contains(CacheKey))
				return (List<CityStateModel>)cache.Get(CacheKey);
			else
			{
				var availableStocks = Helper.LoadJson();
				// Store data in the cache    
				CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
				cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
				cache.Add(CacheKey, availableStocks, cacheItemPolicy);
				return availableStocks;
			}
		}

		public static string LoadCdn(string uri)
		{
			return string.Format(CdnDomain, uri);
		}

		public static List<ProductList> ProductList
		{
			get
			{
				return new List<ProductList>()
				{
					new ProductList()
					{
						 H2="Class 3",
						 Title="Individual Signature",
						  Description="Cheap Class 3 Individual Signature Certificate",
						   Details="Cheap Class 3 Individual Signature Certificate",
							HrefId="Class3-Indi-Sign",
							 Price="₹312.00"
					},
					new ProductList()
					{
						 H2="Class 3",
						 Title="Individual Encryption",
						  Description="Cheap Class 3 Individual Encryption",
						   Details="Cheap Class 3 Individual Encryption",
							HrefId="Class3-Indi-Encrypt",
							 Price="₹312.00"
					},
					new ProductList()
					{
						 H2="Class 3",
						 Title="Individual Combo",
						  Description="Cheap Class 3 Individual Combo",
						   Details="Cheap Class 3 Individual Combo",
							HrefId="Class3-Indi-Combo",
							 Price="₹312.00"
                    },

					new ProductList()
					{
						 H2="Class 3",
						 Title="Organization Signature",
						  Description="Cheap Class 3 Organization Signature Certificate",
						   Details="Cheap Class 3 Organization Signature Certificate",
							HrefId="Class3-Org-Sign",
							 Price="₹312.00"
                    },
					new ProductList()
					{
						 H2="Class 3",
						 Title="Organization Encryption",
						  Description="Cheap Class 3 Organization Encryption",
						   Details="Cheap Class 3 Organization Encryption",
							HrefId="Class3-Org-Encrypt",
							 Price="₹312.00"
                    },
					new ProductList()
					{
						 H2="Class 3",
						 Title="Organization Combo",
						  Description="Cheap Class 3 Organization Combo",
						   Details="Cheap Class 3 Organization Combo",
							HrefId="Class3-Org-Combo",
							 Price="₹312.00"
                    },


					new ProductList()
					{
						 H2="DGFT",
						 Title="Import & Export",
						  Description="Cheap DGFT Certificate",
						   Details="Cheap Class 3 Individual Signature Certificate",
							HrefId="Dgft",
							 Price="₹312.00"
                    },


					new ProductList()
					{
						 H2="Usb Token",
						 Title="USB Token",
						  Description="Usb Token For Storing Certificate",
						   Details="Usb Token For Storing Certificate",
							HrefId="Usb-token",
							 Price="₹312.00"
					},

				};
			}

		}
	}
}